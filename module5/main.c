#include <stdio.h>
#include "mylib.h"
#include <dlfcn.h>

int main(int argc, char* argv[]) {
	void *ext_library = dlopen("./libfsdyn.so",RTLD_LAZY);
	if (!ext_library){
		//если ошибка, то вывести ее на экран
		fprintf(stderr, "dlopen() error: %s\n", dlerror());
		return 1;
	}
	int (*powerfunc1)(int x, int y);
	powerfunc1 = dlsym(ext_library, "f1");

	int (*powerfunc2)(int x, int y);
	powerfunc2 = dlsym(ext_library, "f2");

	//выводим результат работы процедуры
	printf("%d\n", (*powerfunc1)(5, 8));
	printf("%d\n", (*powerfunc2)(5, 8));

	//закрываем библиотеку
	dlclose(ext_library);
	//printf("%d\n", f1(1, 3));
	//printf("%d\n", f2(1, 3));
	return 0;
}