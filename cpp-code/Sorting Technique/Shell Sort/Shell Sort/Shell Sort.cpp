#include <iostream>

using namespace std;

void Display(int A[], int size) {
    for (int i = 0; i < size; i++) cout << A[i] << " ";
    cout << endl;
}

void ShellSort(int A[], int size) {
    int i, j, gap, temp;

    for (gap = size / 2; gap >= 1; gap /= 2) {
        for (i = gap; i < size; i++) {
            temp = A[i];
            j = i - gap;
            while (j >= 0 && A[j] < temp) {
                A[j + gap] = A[j];
                j = j - gap;
            }

            A[j + gap] = temp;
        }
    }
}

int main()
{
    std::cout << "Hello World!\n";
    int A[] = { 2, 4, 1, 0, 7, 6, 3, 5, 9, 8 };
    ShellSort(A, 10);
    Display(A, 10);
}