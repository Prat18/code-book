#include <iostream>

using namespace std;

template <class T>
class Node {
public:
    Node<T>* lchild;
    T data;
    T height;
    Node<T>* rchild;
};

template <class T>
class AVLTree {
public:
    Node<T>* root;
    AVLTree() { root = nullptr; }

    int NodeHeight(Node<T>* node);
    int BalanceFactor(Node<T>* node);
    Node<T>* LLRotation(Node<T>* node);
    Node<T>* LRRotation(Node<T>* node);
    Node<T>* RRRotation(Node<T>* node);
    Node<T>* RLRotation(Node<T>* node);
    Node<T>* RecursiveInsert(int key) { return RecursiveInsert(root, key); }
    Node<T>* RecursiveInsert(Node<T>* node, int key);
    void Display() { Display(root); cout << endl; }
    void Display(Node<T>* node);
};

template <class T>
int AVLTree<T>::NodeHeight(Node<T>* node) {
    int hl, hr;
    hl = node && node->lchild ? node->lchild->height : 0;
    hr = node && node->rchild ? node->rchild->height : 0;

    return hl > hr ? hl + 1 : hr + 1;
}

template <class T>
int AVLTree<T>::BalanceFactor(Node<T>* node) {
    int hl, hr;
    hl = node && node->lchild ? node->lchild->height : 0;
    hr = node && node->rchild ? node->rchild->height : 0;

    return hl - hr;
}

template <class T>
Node<T>* AVLTree<T>::LLRotation(Node<T>* node) {
    Node<T>* A = node->rchild;
    Node<T>* B = node->lchild->rchild;
    Node<T>* C = node->lchild;

    node->lchild->rchild = node;
    node->lchild = B;

    node->height = NodeHeight(node);
    node->height = NodeHeight(C);

    if (root == node) root = C;
    return C;
}

template <class T>
Node<T>* AVLTree<T>::LRRotation(Node<T>* node) {
    Node<T>* A = node->lchild->rchild->lchild;
    Node<T>* B = node->lchild->rchild->rchild;
    Node<T>* D = node->lchild;
    Node<T>* C = node->lchild->rchild;

    C->lchild = node->lchild;
    C->rchild = node;
    node->lchild = B;
    D->rchild = A;

    D->height = NodeHeight(D);
    node->height = NodeHeight(node);
    C->height = NodeHeight(C);

    if (node == root) root = C;

    return C;
}

template <class T>
Node<T>* AVLTree<T>::RRRotation(Node<T>* node) {
    Node<T>* A = node->lchild;
    Node<T>* B = node->rchild->lchild;
    Node<T>* C = node->rchild;

    node->rchild->lchild = node;
    node->rchild = B;

    node->height = NodeHeight(node);
    node->height = NodeHeight(C);

    if (root == node) root = C;
    return C;
}

template <class T>
Node<T>* AVLTree<T>::RLRotation(Node<T>* node) {
    Node<T>* A = node->rchild->lchild->rchild;
    Node<T>* B = node->rchild->lchild->lchild;
    Node<T>* D = node->rchild;
    Node<T>* C = node->rchild->lchild;

    C->rchild = node->rchild;
    C->lchild = node;
    node->rchild = B;
    D->lchild = A;

    D->height = NodeHeight(D);
    node->height = NodeHeight(node);
    C->height = NodeHeight(C);

    if (node == root) root = C;

    return C;
}

template <class T>
void AVLTree<T>::Display(Node<T>* node) {
    if (node) {
        Display(node->lchild);
        cout << "Data: " << node->data << " Height: " << node->height << endl;
        Display(node->rchild);
    }
}

template <class T>
Node<T>* AVLTree<T>::RecursiveInsert(Node<T>* node, int key) {
    if (!node) {
        Node<T>* p = new Node<T>;
        p->lchild = p->rchild = nullptr;
        p->data = key;
        p->height = 1;
        node = p;
        return node;
    }
    else if (key > node->data) node->rchild = RecursiveInsert(node->rchild, key);
    else if (key < node->data) node->lchild = RecursiveInsert(node->lchild, key);

    node->height = NodeHeight(node);

    if (BalanceFactor(node) == 2 && BalanceFactor(node->lchild) == 1) return LLRotation(node);
    else if (BalanceFactor(node) == 2 && BalanceFactor(node->lchild) == -1) return LRRotation(node);
    else if (BalanceFactor(node) == -2 && BalanceFactor(node->rchild) == 1) return RLRotation(node);
    else if (BalanceFactor(node) == -2 && BalanceFactor(node->rchild) == -1) return RRRotation(node);

    return node;
}

int main()
{
    std::cout << "Hello World!\n";
    
    AVLTree<int> t;
    t.root = t.RecursiveInsert(1);
    t.RecursiveInsert(2);
    t.RecursiveInsert(3);
    t.RecursiveInsert(4);
    t.RecursiveInsert(5);
    t.RecursiveInsert(6);
    t.RecursiveInsert(7);
    t.RecursiveInsert(8);
    t.RecursiveInsert(9);
    t.RecursiveInsert(10);
    t.Display();
}