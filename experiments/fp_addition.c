
#include <stdio.h>

int test(int size)
{
    int arr[size];
    arr[1] = 5;
    arr[2] = 6;
    printf("%d, %d\n", arr[1], arr[2]);
}

int array_search()
{
    int k = 1;
    int arr[] = { 1, 1, 1, 5, 6, 7, 8, 9, 11, 11 };
    int a = 0;
    int b = 10;
    int x = 0;
    while (a < b)
    {
        x = (a + b) / 2;
        if (k >= arr[x])
        {
            a = x + 1;
        }
        else
        {
            b = x - 1;
        }
    }

    printf("index %i, value %i", x, arr[x-1]);
}

int main()
{
    float x = 1e10;
    float y = -1e10;
    float z = 1;
    float a = z + x;
    a += y;
    float b = x + y;
    b += z;
    printf("a: %f b: %f\n", a, b);

    x = 2e20;
    y = 2e20;
    z = 2e-37;
    
    a = x * y;
    a *= z;

    b = x * z;
    b *= y;
    printf("a: %f b: %f\n", a, b);
    test(10);
    array_search();
}

