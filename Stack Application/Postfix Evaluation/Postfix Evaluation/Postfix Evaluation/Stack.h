#pragma once
#include <iostream>

using namespace std;

template <class L>
class Node {
public:
    L data;
    Node* next;
};

template <class L>
class StackLL {
private:
    Node<L>* top;
public:
    StackLL() { top = nullptr; }

    void push(L x);
    L pop();
    L peek();
    void Display();
    int isEmpty();
};

template <class L>
void StackLL<L>::push(L x) {
    Node<L>* p = new Node<L>;
    if (!p) cout << "Stack overflow." << endl;
    else {
        p->data = x;
        p->next = top;
        top = p;
    }
}

template <class L>
L StackLL<L>::pop() {
    L x = -1;
    if (!top) cout << "Stack is Empty" << endl;
    else {
        x = top->data;
        Node<L>* p = top;
        top = top->next;
        delete p;
    }

    return x;
}

template <class L>
int StackLL<L>::isEmpty() {
    return (top == nullptr);
}

template <class L>
void StackLL<L>::Display() {
    for (Node<L>* p = top; p != nullptr; p = p->next) cout << p->data << " ";
    cout << endl;
}

template <class L>
L StackLL<L>::peek() {
    if (!top) return -1;
    return top->data;
}

template <class T>
class Stack {
private:
    int top;
    int size;
    T* st;
public:
    Stack() { size = 10; top = -1; st = new T[size]; }
    Stack(int size) { this->size = size; top = -1; st = new T[size]; }

    void push(T x);
    T pop();
    T peek(int index);
    T stacktop();
    int isEmpty();
    int isFull();
    void Display();
};

template <class T>
int Stack<T>::isFull() {
    return (top == size - 1);
}

template <class T>
int Stack<T>::isEmpty() {
    return (top == -1);
}

template <class T>
void Stack<T>::push(T x) {
    if (isFull()) cout << "Stack overflow." << endl;
    else st[++top] = x;
}

template <class T>
T Stack<T>::pop() {
    if (isEmpty()) cout << "Stack is empty." << endl;
    else return st[top--];
}

template <class T>
T Stack<T>::stacktop() {
    return st[top];
}

template <class T>
void Stack<T>::Display() {
    if (isEmpty()) return;
    for (int i = 0; i <= top; i++) cout << st[i] << " ";
    cout << endl;
}

template <class T>
T Stack<T>::peek(int index) {
    if (index > top || index < 0) return -1;
    else return st[index];
}

