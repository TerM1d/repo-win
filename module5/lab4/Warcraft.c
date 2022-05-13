#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
  
pthread_t tid[10];
int counter;
pthread_mutex_t lock;
  
void* trythis(void* arg)
{
    pthread_mutex_lock(&lock);
  
    unsigned long i = 0;
    counter += 1;
    printf("\n Unit %d mines gold\n", counter);
  
    for (i = 0; i < (0xFFFFFFFF); i++);
  
    printf("\n Unit %d has finished mining gold\n", counter);
  
    pthread_mutex_unlock(&lock);
  
    return NULL;
}
  
int main(int argc, char * argv[])
{
	int d = 0;
	for (int i = 0; i < argc; i++) {
		if ((int)argv[1][i] - 48 < 0) break;
		d = d * 10 + ((int)argv[1][i] - 48);
	}
    int i = 0;
    int error;
  
    if (pthread_mutex_init(&lock, NULL) != 0) {
        printf("\n mutex init has failed\n");
        return 1;
    }
  
    while (i < d) {
        error = pthread_create(&(tid[i]),
                               NULL,
                               &trythis, NULL);
        if (error != 0)
            printf("\nThread can't be created :[%s]",
                   strerror(error));
        i++;
    }
	for (int j = 0; j < d; j++) {
		pthread_join(tid[j], NULL);
	}
    pthread_mutex_destroy(&lock);
  
    return 0;
}
