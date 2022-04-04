#include<stdio.h>
#include<sys/types.h>
#include<sys/stat.h>
#include<unistd.h>
#include<fcntl.h>

int main()
{
	char *s="hello";
	char *name="FIFO.fifo";
	int fd;
//	umask(0);
	if(mknod(name,S_IFIFO | 0666,0)<0)
	{
		printf("Error: Can't create FIFO.\n");
	}
	if((fd=open(name,O_WRONLY))<0)
	{
		printf("Error: Can't open FIFO for writting.\n");
	}
	write(fd,s,5);
	close(fd);
}
