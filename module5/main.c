#include <stdio.h>
#include "mylib.h"
#include <dlfcn.h>

int main() {

	printf("%d\n", f1(1, 3));
	printf("%d\n", f2(1, 3));
	return 0;
}
