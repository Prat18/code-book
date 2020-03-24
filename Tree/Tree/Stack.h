#pragma once
#include <iostream>

using namespace std;

template <class S>
class StackNode {
public:
    S data;
    StackNode* next;
};

template <class S>
class StackLL {
private:
    StackNode<S>* top;
public:
    StackLL() { top = nullptr; }

    void push(S x);
    S pop();
    S peek();
    void Display();
    int isEmpty();
};

template <class S>
void StackLL<S>::push(S x) {
    StackNode<S>* p = new StackNode<S>;
    if (!p) cout << "Stack overflow." << endl;
    else {
        p->data = x;
        p->next = top;
        top = p;
    }
}

template <class S>
S StackLL<S>::pop() {
    S x = 0;
    if (!top) cout << "Stack is Empty" << endl;
    else {
        x = top->data;
        StackNode<S>* p = top;
        top = top->next;
        delete p;
    }

    return x;
}

template <class S>
int StackLL<S>::isEmpty() {
    return (top == nullptr);
}

template <class S>
void StackLL<S>::Display() {
    for (StackNode<S>* p = top; p != nullptr; p = p->next) cout << p->data << " ";
    cout << endl;
}

template <class S>
S StackLL<S>::peek() {
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

