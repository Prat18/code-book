#include <iostream>

using namespace std;

int findMax(int A[], int size) {
    int max = INT_MIN;

    for (int i = 0; i < size; i++) if (A[i] > max) max = A[i];
    return max;
}

void CountSort(int A[], int size) {
    int max = findMax(A, size), i, j;
    int* T = new int[max + 1];

    for (i = 0; i <= max; i++) T[i] = 0;
    for (i = 0; i < size; i++) T[A[i]]++;

    i = 0, j = 0;
    while (i <= max) {
        if (T[i] > 0) {
            A[j++] = i;
            T[i]--;
        }
        else i++;
    }

    delete T;
}

void Display(int A[], int size) {
    for (int i = 0; i < size; i++) cout << A[i] << " ";
    cout << endl;
}

int main()
{
    std::cout << "Hello World!\n";
    int A[] = { 5, 5, 2, 1, 3, 3, 4, 9, 1, 7 };
    CountSort(A, 10);
    Display(A, 10);
}