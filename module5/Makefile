all: f1.o f2.o static_lib shared_lib start

f1.o: f1.c
	gcc -fPIC -c f1.c

f2.o: f2.c
	gcc -fPIC -c f2.c

static_lib:
	ar rc libfstat.a f1.o f2.o

shared_lib:
	gcc -shared -o libfsdyn.so f1.o f2.o
start:
	gcc main.c f1.c f2.c -o start.o -ldl
	./start.o
clean:
	rm -rf f1.o f2.o libfstat.a libfsdyn.so start.o