#include <iostream>

using namespace std;

void Merge(int A[], int low, int mid, int high) {
    int size = high - low + 1;
    int* T = new int[size];
    int i = low, j = mid + 1, k = 0;
    
    while (i <= mid && j <= high) {
        if (A[i] < A[j]) T[k++] = A[i++];
        else T[k++] = A[j++];
    }

    while (i <= mid) T[k++] = A[i++];
    while (j <= high) T[k++] = A[j++];

    for (int i = 0; i < size; i++) cout << T[i] << " ";
    cout << endl;
    
    for (i = low, j = 0; j < size; i++, j++) A[i] = T[j];
    delete T;
}

void Display(int A[], int size) {
    for (int i = 0; i < size; i++) cout << A[i] << " ";
    cout << endl;
}

void IterativeMergeSort(int A[], int n) {
    int p;

    for (p = 2; p <= n; p *= 2) {
        for (int i = 0; i + p - 1 < n; i += p) {
            int l = i, h = i + p - 1;
            int m = (l + h) / 2;
            Merge(A, l, m, h);
        }
    }

    if (p / 2 < n) Merge(A, 0, p / 2 - 1, n - 1);
}

void RecursiveMergeSort(int A[], int l, int h) {
    if (h > l) {
        int m = (h + l - 1) / 2;
        RecursiveMergeSort(A, l, m);
        RecursiveMergeSort(A, m + 1, h);
        Merge(A, l, m, h);
    }
}

int main()
{
    std::cout << "Hello World!\n";
    int A[] = { 8, 3, 7, 4, 9, 2, 6, 5, 10 };
    IterativeMergeSort(A, 9);
    Display(A, 9);
}