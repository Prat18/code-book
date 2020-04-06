#include <iostream>
#define SIZE 10

using namespace std;

int Hash(int key) {
    return key % SIZE;
}

int Probe(int H[], int key) {
    int index = Hash(key);
    while (H[index % SIZE] != 0) index++;
    return index % SIZE;
}

void Insert(int H[], int key) {
    int index = Hash(key);

    if (H[index] != 0) index = Probe(H, key);
    H[index] = key;
}

void Search(int H[], int key) {
    int index = Hash(key), halt = 0;

    while (H[index%SIZE] != key && halt != SIZE) {
        halt++;
        if (H[index%SIZE] == 0) {
            cout << "Key not found." << endl;
            return;
        }
        index++;
    }

    if(halt == SIZE) cout << "Key not found." << endl;
    else cout << H[index%SIZE] << " is found." << endl;
}

int main()
{
    std::cout << "Hello World!\n";
    int HT[10] = { 0 };
    Insert(HT, 22);
    Insert(HT, 23);
    Insert(HT, 42);
    Insert(HT, 32);
    Insert(HT, 72);
    Insert(HT, 43);
    Insert(HT, 44);
    Insert(HT, 41);
    Insert(HT, 52);
    Insert(HT, 62);

    Search(HT, 42);
    Search(HT, 21);
    Search(HT, 62);
}