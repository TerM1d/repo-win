#include <stdio.h>
#include <stdlib.h>
#include <assert.h>
#include <signal.h>
#include <sys/time.h>
#include <sys/wait.h>
#include <unistd.h>
#include <string.h>
#include <math.h>
#include <errno.h>

#define TRUE 1
#define FALSE 0
#define SIZE 128
#define ANULL 0.0
#define MAX_STROKE_LEN 168

unsigned int count = 0; //счётчик тиков таймера

typedef struct alarm_limit_data
{
    float limitUsedRam;
    float limitFreeRam;
    float limitUsedSwap;
    float limitUsedDirectory;
    char *directoryName;

} AlarmLimits;

typedef struct output_for_free_mem
{
    float kb;
    char *mem_for_free;

} Freeing;

extern void printInLog(const char *text_error, const char *param_name,
                       const char *limit_param_name, const char *directory_name,
                       float param, float limit_param);

extern void forkForWindow(int cnt);

/* Функции для парсинга конфиг файла в структуру */
size_t alarm_conf_len(char *stroke)
{
    size_t i;
    for (i = 0; stroke[i] != '\0'; i++)
        ;
    return (i + 1);
}

int get_index_by_param(char *stroke, char param)
{
    if (!strcmp("", stroke))
        return -1;

    if (strlen(stroke) > MAX_STROKE_LEN)
        return -2;

    int flag = FALSE;
    int j;

    for (j = 0; stroke[j] != '\0'; j++)
    {
        if (stroke[j] == param)
        {
            flag = TRUE;
            break;
        }
    }

    if (flag)
    {
        for (j = 0; stroke[j] != param; j++)
            ;
    }
    else
        return -3;

    return j;
}

char *alarm_read_conf()
{
    char cwd[1024];

    if (getcwd(cwd, sizeof(cwd)) == NULL)
    {
        printInLog("Function getcwd() error", NULL, NULL, NULL, 0.0, 0.0);
    }
    char *pathToConf = (char *)calloc(strlen(cwd) + strlen("/config.conf") + 1, sizeof(char));

    strcat(pathToConf, cwd);
    strcat(pathToConf, "/config.conf"); // bin/config.conf
    printInLog(pathToConf, NULL, NULL, NULL, 0.0, 0.0);

    FILE *cp = fopen(pathToConf, "r");

    if (cp == NULL)
    {
        printInLog("Error for opening file..", NULL, NULL, NULL, 0.0, 0.0);
        return (char *)-1;
    }

    int lines;
    while (!feof(cp))
    {
        if (fgetc(cp) == '\n')
            lines++;
    }
    lines++;
    fclose(cp);

    char *buffer = (char *)malloc(sizeof(char) * MAX_STROKE_LEN * lines);
    memset(buffer, 0, sizeof(buffer));

    cp = fopen(pathToConf, "r");
    if (cp == NULL)
    {
        printInLog("Error for opening file..", NULL, NULL, NULL, 0.0, 0.0);
        return (char *)-1;
    }

    while (fread(buffer, sizeof(char), MAX_STROKE_LEN * lines, cp))
        ;

    return buffer;
}

void nullable_structure(AlarmLimits *param)
{
    param->limitUsedRam = ANULL;
    param->limitFreeRam = ANULL;
    param->limitUsedSwap = ANULL;
    param->limitUsedDirectory = ANULL;
    param->directoryName = (char *)malloc(sizeof(char) * MAX_STROKE_LEN);
    param->directoryName = NULL;
}

// не используется в main-е, но может быть использовано для записи в лог-файл.
void print_AlarmLimits(const AlarmLimits *const param, int len)
{
    float to_print;
    for (int i = 0; i < len; i++)
    {
        to_print = ANULL;

        if ((to_print = param[i].limitUsedRam) != ANULL)
        {
            printf("Limit Used Ram: %f\tindex of list: %d\n", to_print, i);
        }
        if ((to_print = param[i].limitFreeRam) != ANULL)
        {
            printf("Limit Free Ram: %f\tindex of 5.13.0-48-genericlist: %d\n", param[i].limitFreeRam, i);
        }
        if ((to_print = param[i].limitUsedSwap) != ANULL)
        {
            printf("Limit Used Swap: %f\tindex of list: %d\n", to_print, i);
        }
        if ((to_print = param[i].limitUsedDirectory) != ANULL)
        {
            printf("Limit Used Directory: %f\tindex of list: %d\n", to_print, i);
        }
        if (param[i].directoryName != NULL)
        {
            printf("Scanning directory: %s\tindex of list: %d\n", param[i].directoryName, i);
        }
    }
}

double get_num_kb(char *buffer)
{
    int i = 0;
    int j = 0;
    int k = 0;
    int num = 0;
    int num_dec = 0;
    int kb = 0;
    int dec = 0;

    while (buffer[i])
    {
        if (k == 0 && buffer[i] >= 48 && buffer[i] <= 57)
        {
            num = num * 10 + buffer[i] - 48;
        }
        if (buffer[i] == '.' || buffer[i] == ',')
        {
            k = 1;
            j = i;
        }
        if ((buffer[i] == 'G' || buffer[i] == 'g') && (buffer[i + 1] == 'b' || buffer[i + 1] == 'B'))
        {
            kb = 2;
        }
        if ((buffer[i] == 'M' || buffer[i] == 'm') && (buffer[i + 1] == 'b' || buffer[i + 1] == 'B'))
        {
            kb = 1;
        }
        i++;
    }
    if (k == 1)
    {
        while (buffer[j])
        {
            if (buffer[j] >= 48 && buffer[j] <= 57)
            {
                num_dec = num_dec * 10 + buffer[j] - 48;
                dec++;
            }
            j++;
        }
    }
    double num_res = (double)num * pow(1024, kb) + (double)num_dec * pow(0.1, dec) * pow(1024, kb);

    return num_res;
}

/* Функции мониторинга */
// Свободный объём ОЗУ
int get_mem_free()
{
    FILE *fd;
    char buff[128] = {0};
    fd = fopen("/proc/meminfo", "r");
    fgets(buff, sizeof(buff), fd);
    while (strncmp(buff, "MemFree", 7) != 0)
        fgets(buff, sizeof(buff), fd);

    fclose(fd);
    return get_num_kb(buff);
}

// Общий объём ОЗУ
int get_mem_total()
{
    FILE *fd;
    char buff[128] = {0};
    fd = fopen("/proc/meminfo", "r");
    fgets(buff, sizeof(buff), fd);
    while (strncmp(buff, "MemTotal", 8) != 0)
        fgets(buff, sizeof(buff), fd);

    fclose(fd);
    return get_num_kb(buff);
}

// Свободный объём файла подкачки
int get_swap_free(void)
{
    FILE *file;
    char buffer[128] = {0};
    file = fopen("/proc/meminfo", "r");
    while (strncmp(buffer, "SwapFree", 8) != 0)
    {
        fgets(buffer, sizeof(buffer), file);
    }
    fclose(file);
    return get_num_kb(buffer);
}

// Общий объём файла покачки
int get_swap_total(void)
{
    FILE *file;
    char buffer[128] = {0};
    file = fopen("/proc/meminfo", "r");
    while (strncmp(buffer, "SwapTotal", 9) != 0)
    {
        fgets(buffer, sizeof(buffer), file);
    }
    fclose(file);
    return get_num_kb(buffer);
}

char *mem_info_about_directory(const char *directory_name)
{
    int filedes[2];
    char buffer[SIZE];
    memset(buffer, 0, sizeof(buffer));

    if (pipe(filedes) == -1)
    {
        printInLog("Cant create pipe in function mem_info_about_directory()", NULL, NULL, NULL, 0.0, 0.0);
        exit(1);
    }
    pid_t pid = fork();

    if (pid < 0)
    {
        printInLog("Cant fork child process in function mem_info_about_directory()", NULL, NULL, NULL, 0.0, 0.0);
        exit(1);
    }
    else if (pid == 0)
    {
        // close(filedes[0]);
        while ((dup2(filedes[1], STDOUT_FILENO) == -1) && (errno == EINTR))
        {
        };

        execl("/usr/bin/du", "/usr/bin/du", "-s", directory_name, NULL);
        perror("execl");
        _exit(1);
    }
    else
    {
        close(filedes[1]);

        ssize_t count = read(filedes[0], buffer, sizeof(buffer));

        if (count == -1)
        {
            perror("read");
            exit(1);
        }
        wait(0);

        close(filedes[0]);
    }
    char *return_buffer = (char *)malloc(sizeof(char) * SIZE);
    memset(return_buffer, 0, sizeof(return_buffer));
    strcpy(return_buffer, buffer);
    return return_buffer;
}

Freeing get_used_Kb_by_directory(const char *directory_name)
{
    char *result = mem_info_about_directory(directory_name);
    Freeing output;
    output.kb = atof(result);
    output.mem_for_free = result;
    return output;
}

// Handler таймера
void handler(int signo)
{
    // TODO Убрать отладочную информацию и расскоментировать строку
    //printf("Get a SIGALRM, %d counts!\n", ++count);
    ++count;
}

/* Вызываемый демон */
int main(int argc, void *argv[])
{
    /* Данные мониторинга */
    float usedRam = 0.0;
    float freeRam = 0.0;
    float usedSwap = 0.0;
    float usedDirectory = 0.0;

    /* Парсинг конфиг-файла и занесение его в динамическую структуру */
    int before = 0, after = 0, i = 0, j = 0, counter;
    int flag = FALSE;
    char *dir;
    char before_value[SIZE];
    size_t size_of_line;
    char *tmp;

    AlarmLimits *limits = (AlarmLimits *)malloc(sizeof(AlarmLimits) * SIZE);
    memset(limits, 0, sizeof(limits));
    int len_of_list = 0;

    char *buffer = alarm_read_conf();

    if (-1 == (int)buffer)
    {
        printInLog("Error for opening configuration file!", NULL, NULL, NULL, 0.0, 0.0);
        return -1;
    }

    while (!flag)
    {
        for (i = before; buffer[i] != '\n'; i++)
        {
            if (buffer[i] == '\0')
            {
                flag = TRUE;
            }
        }

        after = i;
        size_of_line = sizeof(char) * after;

        char *tmp = (char *)malloc(size_of_line);
        memset(tmp, 0, sizeof(tmp));

        counter = 0;
        for (j = before; j < after; j++)
            tmp[counter++] = buffer[j];
        tmp[counter] = '\0';

        if (alarm_conf_len(tmp) > MAX_STROKE_LEN)
        {
            printInLog("Length of stroke in configuration file very long!", NULL, NULL, NULL, 0.0, 0.0);
            return -1;
        }

        // skipping \n for normal work
        before = after + 1;

        memset(before_value, 0, sizeof(before_value));

        int index = get_index_by_param(tmp, ':');

        if (0 > index)
            continue;

        int k;
        // in result before_value is parameter without value
        for (k = 0; k != index; k++)
            before_value[k] = tmp[k];
        before_value[k] = '\0';

        // parse value (segment of data with some number) here
        int local_counter = 0;

        char *slice_after_delimeter = (char *)malloc(sizeof(char) * size_of_line);
        memset(slice_after_delimeter, 0, sizeof(slice_after_delimeter));

        for (int i = index + 2; tmp[i] != '\0'; i++)
        {
            slice_after_delimeter[local_counter++] = tmp[i];
        }

        AlarmLimits elem;
        nullable_structure(&elem);
        double value = ANULL;

        if (!strcmp(before_value, "limitUsedRam"))
        {
            if (value = get_num_kb(slice_after_delimeter))
            {
                elem.limitUsedRam = value;
            }
            else
                elem.limitUsedRam = ANULL;

            limits[len_of_list++] = elem;
        }

        if (!strcmp(before_value, "limitFreeRam"))
        {
            if (value = get_num_kb(slice_after_delimeter))
            {
                elem.limitFreeRam = value;
            }
            else
                elem.limitFreeRam = ANULL;

            limits[len_of_list++] = elem;
        }

        if (!strcmp(before_value, "limitUsedSwap"))
        {
            if (value = get_num_kb(slice_after_delimeter))
            {
                elem.limitUsedSwap = value;
            }
            else
                elem.limitUsedSwap = ANULL;

            limits[len_of_list++] = elem;
        }
        if (!strcmp(before_value, "limitUsedDirectory"))
        {
            int flag = FALSE;
            for (int ii = 0; ii < SIZE; ii++)
            {
                if (limits[ii].directoryName != NULL && limits[ii].limitUsedDirectory == ANULL && ((value = get_num_kb(slice_after_delimeter)) != ANULL))
                {
                    flag = TRUE;
                    limits[ii].limitUsedDirectory = value;
                    break;
                }
            }
            if ((0 == flag) && ((value = get_num_kb(slice_after_delimeter)) != ANULL))
            {
                elem.limitUsedDirectory = value;
                limits[len_of_list] = elem;
                ++len_of_list;
            }
        }
        if (!strcmp(before_value, "directoryName"))
        {
            int flag = FALSE;
            for (int jj = 0; jj < SIZE; jj++)
            {
                if (limits[jj].limitUsedDirectory != 0 && limits[jj].directoryName == NULL && ((int)tmp[index + 2] > 0))
                {
                    flag = TRUE;
                    dir = (char *)malloc(sizeof(char) * MAX_STROKE_LEN);
                    memset(dir, 0, sizeof(dir));
                    counter = 0;

                    for (int i = index + 2; tmp[i] != '\0'; i++)
                    {
                        dir[counter] = tmp[i];
                        counter++;
                    }
                    limits[jj].directoryName = dir;

                    break;
                }
            }
            if ((0 == flag) && ((int)tmp[index + 2] > 0))
            {
                dir = (char *)malloc(sizeof(char) * MAX_STROKE_LEN);
                memset(dir, 0, sizeof(dir));
                counter = 0;

                for (int i = index + 2; tmp[i] != '\0'; i++)
                    dir[counter++] = tmp[i];
                elem.directoryName = dir;

                limits[len_of_list] = elem;

                ++len_of_list;
            }
        }
        free(slice_after_delimeter);
        free(tmp);
    }
    free(buffer);

    /* Инициализация таймера */
    struct itimerval tick;
    signal(SIGALRM, handler);
    memset(&tick, 0, sizeof(tick));
    tick.it_value.tv_sec = 1; // таймаут таймера в секундах
    tick.it_value.tv_usec = 0;
    tick.it_interval.tv_sec = 1; // интервал повторения таймера
    tick.it_interval.tv_usec = 0;
    if (setitimer(ITIMER_REAL, &tick, NULL) < 0)
        printInLog("Set timer failed!\n", NULL, NULL, NULL, 0.0, 0.0);

    /* Переменные для реализации гистерезиса */
    //  Логические переменные: 1 - значение в гистерезисе, 0 - значение не в гистерезисе
    int *boolGist = (int *)malloc(len_of_list * sizeof(int));
    //  Время окончания гистерезиса
    int *endGist = (int *)malloc(len_of_list * sizeof(int));
    for (int i = 0; i < len_of_list; i++)
    {
        boolGist[i] = 0;
        endGist[i] = 0;
    }

    // Настройка мониторинга
    int delayMonitoring = 10; // частота мониторинга в секундах
    int delayGist = 60;       // добавление задержки гистерезиса в секундах

    /* Главный цикл работы демона*/
    while (1)
    {

        // Проверка параметров окончания гистерезиса
        for (int i = 0; i < len_of_list; i++)
        {
            if (count >= endGist[i])
            {
                endGist[i] = 0;
                boolGist[i] = 0;
            }
        }
        

        /* Мониторинг проводится один раз в delayMonitoring секунд */
        if (count != 0 && count % delayMonitoring == 0)
        {
            //printf("PROCESS MONITORING EVERY 10 SECONDS\n"); // TODO Убрать отладочную информацию

            /* Далее текущие данные сравниваются с предельными значениями */
            int cnt = 0; // переменная счётчик вывода кол-ва строк во всплывающее окно
            for (int i = 0; i < len_of_list; i++)
            {
                if (limits[i].limitUsedRam != ANULL)
                {
                    usedRam = get_mem_total() - get_mem_free();
                    if (usedRam >= limits[i].limitUsedRam && !boolGist[i])
                    {
                        // Запись в лог данной аварии
                        printInLog(NULL, "used-ram", "limit-used-ram", NULL, usedRam, limits[i].limitUsedRam);

                        // Всплывающее окно об аварии
                        cnt++;

                        // Реализация гистерезиса
                        endGist[i] = count + delayGist;
                        boolGist[i] = 1;
                    }
                }
                if (limits[i].limitFreeRam != ANULL)
                {
                    freeRam = get_mem_free();
                    if (freeRam >= limits[i].limitFreeRam && !boolGist[i])
                    {

                        // Запись в лог данной аварии
                        printInLog(NULL, "free-ram", "limit-free-ram", NULL, freeRam, limits[i].limitFreeRam);

                        // Всплывающее окно об аварии
                        cnt++;

                        // Реализация гистерезиса
                        endGist[i] = count + delayGist;
                        boolGist[i] = 1;
                    }
                }
                if (limits[i].limitUsedSwap != ANULL)
                {
                    usedSwap = get_swap_total() - get_swap_free();
                    if (usedSwap >= limits[i].limitUsedSwap && !boolGist[i])
                    {

                        // Запись в лог данной аварии
                        printInLog(NULL, "used-swap", "limit-used-swap", NULL, usedSwap, limits[i].limitUsedSwap);
                        
                        // Всплывающее окно об аварии
                        cnt++;
 
                        // Реализация гистерезиса
                        endGist[i] = count + delayGist;
                        boolGist[i] = 1;
                    }
                }
                if (NULL != limits[i].directoryName && limits[i].limitUsedDirectory != ANULL)
                {
                    Freeing result;
                    result = get_used_Kb_by_directory(limits[i].directoryName);
                    usedDirectory = result.kb;
                    free(result.mem_for_free);
                    if (usedDirectory >= limits[i].limitUsedDirectory && !boolGist[i])
                    {

                        // Запись в лог данной аварии
                        printInLog(NULL, "used-directory", "limit-used-directory", limits[i].directoryName, usedDirectory, limits[i].limitUsedDirectory);

                        // Всплывающее окно об аварии
                        cnt++;

                        // Реализация гистерезиса
                        endGist[i] = count + delayGist;
                        boolGist[i] = 1;
                    }
                }
            }
            forkForWindow(cnt);
        }
        pause();
    }

    free(dir);
    free(limits);
    free(endGist);
    free(boolGist);
    return 0;
}