#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/msg.h>
#include <string.h>
#include <stdio.h>
#include <stdlib.h>

int main()
{

int msqid; /* IPC дескриптор для очереди сообщений */

char pathname[] = "09-1a.c"; /* Имя файла, использующееся для генерации ключа.
Файл с таким именем должен существовать в текущей директории */

key_t key; /* IPC ключ */

int i,len; /* Cчетчик цикла и длина информативной части сообщения */

/* Ниже следует пользовательская структура для сообщения */

struct mymsgbuf
{
long mtype;
char mtext[81];
} mybuf;

/* Генерируем IPC ключ из имени файла 09-1a.c в текущей директории
и номера экземпляра очереди сообщений 0. */

if((key = ftok(pathname,0)) < 0){
printf("Can\'t generate key\n");
exit(-1);
}

/* Пытаемся получить доступ по ключу к очереди сообщений, если она существует,
или создать ее, если она еще не существует, с правами доступа
read & write для всех пользователей */

if((msqid = msgget(key, 0666 | IPC_CREAT)) < 0){
printf("Can\'t get msqid\n");
exit(-1);
}

mybuf.mtype = 1;
strcpy(mybuf.mtext, "2");
len = strlen(mybuf.mtext)+1;

/* Отсылаем сообщение. В случае ошибки сообщаем об этом и удаляем очередь сообщений из системы. */

if (msgsnd(msqid, (struct msgbuf *) &mybuf, len, 0) < 0){
printf("Can\'t send message to queue\n");
msgctl(msqid, IPC_RMID, (struct msqid_ds *) NULL);
exit(-1);
}

while(1) {
int maxlen = 81;

if(len = msgrcv(msqid, (struct msgbuf *) &mybuf, maxlen, 0, 0) < 0){
printf("Can\'t receive message from queue\n");
exit(-1);
}

if (mybuf.mtype == 2){
printf("message type = %ld, info = %s\n", mybuf.mtype, mybuf.mtext);
exit(0);

}

}

return 0;
}

