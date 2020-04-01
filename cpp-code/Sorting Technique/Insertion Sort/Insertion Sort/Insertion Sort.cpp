#include <iostream>

using namespace std;

void Display(int A[], int size) {
    for (int i = 0; i < size; i++) cout << A[i] << " ";
    cout << endl;
}

void InsertionSort(int A[], int size) {
    for (int i = 1; i < size; i++) {
        int j = i - 1, temp = A[i];
        while(j > -1 && temp > A[j]) {
            A[j + 1] = A[j];
            j--;
        }
        A[j + 1] = temp;
    }

    Display(A, size);
}

int main()
{
    std::cout << "Hello World!\n";
    int A[] = { 4, 7, 5, 2, 3, 6, 1, 100 };
    InsertionSort(A, 7);
}