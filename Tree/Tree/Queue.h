#include <iostream>

using namespace std;

template <class L>
class QueueNode {
public:
    L data;
    QueueNode* next;
};

template <class L>
class QueueLL {
private:
    QueueNode<L>* front;
    QueueNode<L>* rear;
public:
    QueueLL() { front = rear = nullptr; }

    void enqueue(L x);
    L dequeue();
    void display();
    int isEmpty();
};

class QueueArray {
private:
    int front;
    int rear;
    int size;
    int* Q;
public:
    QueueArray() { front = rear = -1; size = 10; Q = new int[size]; }
    QueueArray(int size);

    void enqueue(int x);
    int dequeue();
    void Display();
};

QueueArray::QueueArray(int size) {
    front = rear = -1;
    this->size = size;
    Q = new int[size];
}

void QueueArray::Display() {
    for (int i = front + 1; i <= rear; i++) {
        cout << Q[i] << " ";
        cout << endl;
    }
}

void QueueArray::enqueue(int x) {
    if (rear == size - 1) cout << "Queue is full." << endl;
    else Q[++rear] = x;
}

int QueueArray::dequeue() {
    if (front == rear) {
        cout << "Queue is empty." << endl;
        return 0;
    }
    else {
        int x = Q[front + 1];
        front++;
    }
}

template <class L>
void QueueLL<L>::display() {
    for (QueueNode<L>* q = front; q != nullptr; q = q->next) cout << q->data << " ";
    cout << endl;
}

template <class L>
void QueueLL<L>::enqueue(L x) {
    QueueNode<L>* p = new QueueNode<L>;
    if (!p) cout << "Queue is full." << endl;
    else {
        p->data = x;
        p->next = nullptr;
        if (!front) {
            rear = front = p;
        }
        else {
            rear->next = p;
            rear = p;
        }
    }
}

template <class L>
L QueueLL<L>::dequeue() {
    L x = 0;
    if (!front) cout << "Queue is empty." << endl;
    else {
        QueueNode<L>* p = front->next;
        x = front->data;
        delete front;
        front = p;
    }

    return x;
}

template <class L>
int QueueLL<L>::isEmpty() {
    return (front == nullptr);
}
