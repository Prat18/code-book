#include <iostream>

using namespace std;

void Swap(int* a, int* b) {
    int t = *a;
    *a = *b;
    *b = t;
}

void Display(int A[], int size) {
    for (int i = 0; i < size; i++) cout << A[i] << " ";
    cout << endl;
}

void SelectionSort(int A[], int size) {
    int i, j, k;

    for (i = 0; i < size; i++) {
        for (j = k = i; j < size; j++) {
            if (A[k] > A[j]) k = j;
        }

        Swap(&A[i], &A[k]);
    }

    Display(A, size);
}

int main()
{
    std::cout << "Hello World!\n";
    int A[] = { 2, 4, 7, 5, 3, 6, 9, 10 };
    SelectionSort(A, 8);
}