#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <stdio.h>
#include <errno.h>
#include <stdlib.h>
#include <string.h>

int main()
{
char *array; /* Указатель на разделяемую память */
char text[]="vsem privet";
int shmid; /* IPC дескриптор для области разделяемой памяти */

char pathname[] = "06-1a.c"; /* Имя файла, использующееся для генерации ключа. Файл с таким именем должен существовать в текущей директории */

key_t key; /* IPC ключ */


/* Генерируем IPC ключ из имени файла 06-1a.c в текущей директории и номера экземпляра области разделяемой памяти 0 */

if((key = ftok(pathname,0)) < 0){
printf("Can\'t generate key\n");
exit(-1);
}

/* Пытаемся эксклюзивно создать разделяемую память для сгенерированного ключа */

if((shmid = shmget(key, 100*sizeof(char), 0666|IPC_CREAT|IPC_EXCL)) < 0){


/* В случае возникновения ошибки пытаемся определить: возникла ли она из-за того, что сегмент разделяемой памяти уже существует или по другой причине */

if(errno != EEXIST){

/* Если по другой причине - прекращаем работу */

printf("Can\'t create shared memory\n");
exit(-1);
} else {

/* Если из-за того, что разделяемая память уже существует пытаемся получить ее IPC дескриптор и, в случае удачи, сбрасываем флаг необходимости инициализации элементов массива */

if((shmid = shmget(key, 100*sizeof(char), 0)) < 0){
printf("Can\'t find shared memory\n");
exit(-1);
}

}
}


/* Пытаемся отобразить разделяемую память в адресное пространство текущего процесса. */

if((array = (int *)shmat(shmid, NULL, 0)) == (int *)(-1)){
printf("Can't attach shared memory\n");
exit(-1);
}

strcpy(array, text);


if(shmdt(array) < 0){
printf("Can't detach shared memory\n");
exit(-1);
}
return 0;
} 
