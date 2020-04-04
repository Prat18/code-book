#include <iostream>

using namespace std;

void Swap(int* a, int* b) {
    int t = *a;
    *a = *b;
    *b = t;
}

int Partition(int A[], int low, int high) {
    int pivot = A[low];
    int i = low, j = high;

    do {
        do {
            i++;
        } while (pivot <= A[i]);

        do {
            j--;
        } while (pivot > A[j]);

        if (i < j) Swap(&A[i], &A[j]);
    } while (i < j);

    Swap(&A[j], &A[low]);
    
    return j;
}

void QuickSort(int A[], int low, int high) {
    int pivot;

    if (low < high) {
        pivot = Partition(A, low, high);
        QuickSort(A, low, pivot);
        QuickSort(A, pivot + 1, high);
    }
}

void Display(int A[], int size) {
    for (int i = 0; i < size; i++) cout << A[i] << " ";
    cout << endl;
}

int main()
{
    std::cout << "Hello World!\n";
    int A[] = { 4, 8, 3, 6, 1, 5, 2 };
    QuickSort(A, 0, 7);
    Display(A, 7);
}