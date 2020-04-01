#include <iostream>

using namespace std;

void Swap(int* a, int* b) {
    int t = *b;
    *b = *a;
    *a = t;
}

void Display(int A[], int size) {
    for (int i = 0; i < size; i++) cout << A[i] << " ";
}

void BubbleSort(int A[], int size) {
    int flag;

    for (int i = 0; i < size; i++) {
        flag = 0;
        for (int j = 0; j < size - 1 - i; j++) {
            if (A[j] > A[j + 1]) Swap(&A[j], &A[j + 1]);
            flag = 1;
        }

        if (!flag) break;
    }

    Display(A, size);
}

int main()
{
    std::cout << "Hello World!\n";
    int A[] = { 5, 4, 3, 8, 1, 9, 100, 0 };
    BubbleSort(A, 8);
}