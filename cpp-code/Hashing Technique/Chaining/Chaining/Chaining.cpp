#include <iostream>

using namespace std;

class Node {
public:
	int data;
	Node* next;
};

int Hash(int key) {
	return key % 10;
}

void SortedInsert(Node** H, int x) {
    Node* t, * q = nullptr, * p = *H;

    t = new Node;
    t->data = x;
    t->next = nullptr;

    if (*H == NULL)
        *H = t;
    else
    {
        while (p && p->data < x)
        {
            q = p;
            p = p->next;
        }
        if (p == *H)
        {
            t->next = *H;
            *H = t;
        }
        else
        {
            t->next = q->next;
            q->next = t;
        }
    }
}

Node* Search(Node* p, int key)
{
    while (p != NULL)
    {
        if (key == p->data)
        {
            return p;
        }
        p = p->next;
    }
    return NULL;

}

void Insert(Node* HT[], int key) {
	int index = Hash(key);
	SortedInsert(&HT[index], key);
}

int main()
{
    std::cout << "Hello World!\n";
	Node* HT[10];
    for (int i = 0; i < 10; i++) HT[i] = nullptr;
    Insert(HT, 12);
    Insert(HT, 22);
    Insert(HT, 42);

    Node* temp = Search(HT[Hash(22)], 22);

    if (temp) printf("%d ", temp->data);
    else cout << "Key not found.";

    return 0;
}