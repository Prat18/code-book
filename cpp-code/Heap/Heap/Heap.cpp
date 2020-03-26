#include <iostream>

using namespace std;

void Insert(int H[], int index) {
    int  i = index, temp;
    temp = H[index];

    while (i > 1 && H[i/2] < temp) {
        H[i] = H[i / 2];
        i = i / 2;
    }

    H[i] = temp;
}

int main()
{
    std::cout << "Hello World!\n";
    int H[] = { 0, 2, 5, 8, 9, 4, 10, 7 };
    Insert(H, 2);
    Insert(H, 3);
    Insert(H, 4);
    Insert(H, 5);
}
