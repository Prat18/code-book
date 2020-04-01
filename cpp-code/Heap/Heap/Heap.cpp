#include <iostream>

using namespace std;

void Insert(int H[], int index) {
    int temp = H[index];

    while (H[index / 2] < temp && index / 2 > 0) {
        H[index] = H[index / 2];
        index = index / 2;
    }

    H[index] = temp;
}

int Delete(int H[], int size) {
    int x = H[1], temp;
    H[1] = H[size];
    H[size] = x;
    int i = 1, j = i * 2;
    
    while (j <= size - 1) {
        if (j < size - 1 && H[j] < H[j + 1]) j = j + 1;
        
        if (H[i] < H[j]) {
            temp = H[i];
            H[i] = H[j];
            H[j] = temp;
            i = j;
            j = 2 * i;
        }
        else break;
    }

    return x;
}

void Display(int H[], int size) {
    for (int i = 1; i < size; i++) cout << H[i] << " ";
    cout << endl;
}

int main()
{
    std::cout << "Hello World!\n";
    int H[] = { 0, 2, 5, 8, 9, 4, 10, 7 };
    Insert(H, 1);
    Insert(H, 2);
    Insert(H, 3);
    Insert(H, 4);
    Insert(H, 5);
    Insert(H, 6);
    Insert(H, 7);
    cout << Delete(H, 7) << endl;
    cout << Delete(H, 6) << endl;
    cout << Delete(H, 5) << endl;
    cout << Delete(H, 4) << endl;
    cout << Delete(H, 3) << endl;
    cout << Delete(H, 2) << endl;
    cout << Delete(H, 1) << endl;
}
