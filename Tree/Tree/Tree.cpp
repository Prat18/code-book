#include <iostream>
#include "Queue.h"
#include "Stack.h"

using namespace std;

template <class T>
class TreeNode {
public:
    TreeNode* lchild;
    T data;
    TreeNode* rchild;
};

template <class T>
class Tree {
private:
    TreeNode<T>* root;
public:
    Tree() { root = nullptr; }

    void CreateTree();
    void PreOrder() { PreOrder(root); }
    void PreOrder(TreeNode<T>* node);
    void PostOrder() { PostOrder(root); }
    void PostOrder(TreeNode<T>* node);
    void InOrder() { InOrder(root); }
    void InOrder(TreeNode<T>* node);
    void IterativePreorder();
    void IterativePostorder();
    void IterativeInorder();
    void LevelOrder();
    int Height() { int height = Height(root); return (height-1); }
    int Height(TreeNode<T>* node);
    int CountNodes() { int count = CountNodes(root); return count; }
    int CountNodes(TreeNode<T>* node);
};

template <class T>
void Tree<T>::CreateTree() {
    QueueLL<TreeNode<T>*> queue;
    TreeNode<T>* t = new TreeNode<T>;
    cout << "Enter the root value: " << endl;
    T x; cin >> x;
    root = t;
    root->data = x;
    root->lchild = root->rchild = nullptr;
    queue.enqueue(root);
    while (!queue.isEmpty()) {
        t = queue.dequeue();
        cout << "Enter the left child of " << t->data << ": " << endl;
        cin >> x;
        if (x != -1) {
            TreeNode<T>* p = new TreeNode<T>;
            p->data = x;
            p->lchild = p->rchild = nullptr;
            t->lchild = p;
            queue.enqueue(p);
        }

        cout << "Enter the right child of " << t->data << ": " << endl;
        cin >> x;
        if (x != -1) {
            TreeNode<T>* p = new TreeNode<T>;
            p->data = x;
            p->lchild = p->rchild = nullptr;
            t->rchild = p;
            queue.enqueue(p);
        }
    }
}

template <class T>
void Tree<T>::PreOrder(TreeNode <T>* node) {
    if (node) {
        cout << node->data << " ";
        PreOrder(node->lchild);
        PreOrder(node->rchild);
    }
}

template <class T>
void Tree<T>::PostOrder(TreeNode <T>* node) {
    if (node) {
        PostOrder(node->lchild);
        PostOrder(node->rchild);
        cout << node->data << " ";
    }
}

template <class T>
void Tree<T>::InOrder(TreeNode <T>* node) {
    if (node) {
        InOrder(node->lchild);
        cout << node->data << " ";
        InOrder(node->rchild);
    }
}

template <class T>
void Tree<T>::IterativePreorder() {
    StackLL<TreeNode<T>*> stack;
    TreeNode<T>* t = root;
    while (t || !stack.isEmpty()) {
        if (t) {
            cout << t->data << " ";
            stack.push(t);
            t = t->lchild;
        }
        else {
            t = stack.pop();
            t = t->rchild;
        }
    }
}

template <class T>
void Tree<T>::IterativePostorder() {
    StackLL<long> stack;
    TreeNode<T>* t = root;
    while (t || !stack.isEmpty()) {
        if (t) {
            stack.push((long)t);
            t = t->lchild;
        }
        else {
            long addr;
            addr = stack.pop();
            if (addr < 0) {
                addr *= -1;
                cout << ((TreeNode<T>*)addr)->data << " ";
            }
            else {
                stack.push(addr * (-1));
                t = ((TreeNode<T>*) addr)->rchild;
            }
        }
    }
}

template <class T>
void Tree<T>::IterativeInorder() {
    StackLL<TreeNode<T>*> stack;
    TreeNode<T>* t = root;
    while (t || !stack.isEmpty()) {
        if (t) {
            stack.push(t);
            t = t->lchild;
        }
        else {
            t = stack.pop();
            cout << t->data << " ";
            t = t->rchild;
        }
    }
}

template <class T>
void Tree<T>::LevelOrder() {
    QueueLL<TreeNode<T>*> queue;
    TreeNode<T>* t = root;
    queue.enqueue(t);
    cout << t->data << " ";
    while (!queue.isEmpty()) {
        t = queue.dequeue();
        if (t->lchild) {
            queue.enqueue(t->lchild);
            cout << t->lchild->data << " ";
        }
        if (t->rchild) {
            queue.enqueue(t->rchild);
            cout << t->rchild->data << " ";
        }
    }
}

template <class T>
int Tree<T>::Height(TreeNode<T>* node) {
    int x, y;
    if (node) {
        x = Height(node->lchild);
        y = Height(node->rchild);
        if (x >= y) return x + 1;
        else return y + 1;
    }
    else return 0;
}

template <class T>
int Tree<T>::CountNodes(TreeNode<T>* node) {
    int x, y;
    if (node) {
        x = CountNodes(node->lchild);
        y = CountNodes(node->rchild);
        return x + y + 1;
    }
    else return 0;
}

int main()
{
    std::cout << "Hello World!\n";
    Tree<int> t;
    t.CreateTree();

    cout << "Iterative Preorder Traversal: ";
    t.IterativePreorder();
    cout << endl;

    cout << "Iterative Postorder Traversal: ";
    t.IterativePostorder();
    cout << endl;

    cout << "Iterative Inorder Traversal: ";
    t.IterativeInorder();
    cout << endl;

    cout << "Level Order Traversal: ";
    t.LevelOrder();
    cout << endl;

    cout << "Number of nodes: " << t.CountNodes() << endl;
    cout << "Height of tree: " << t.Height() << endl;
}