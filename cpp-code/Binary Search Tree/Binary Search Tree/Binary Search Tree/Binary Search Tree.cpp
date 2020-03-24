#include <iostream>

using namespace std;

template <class T>
class Node {
public:
	Node* lchild;
	T data;
	Node* rchild;
};

template <class T>
class BST {
private:
	Node<T>* root;
public:
	BST() { root = nullptr; }

	void IterativeInsert(T key);
	void RecursiveInsert(int key) { RecursiveInsert(root, key); }
	Node<T>* RecursiveInsert(Node<T>* node, T key);
	Node<T>* Search(T key);
	void Inorder() { Inorder(root); cout << endl; }
	void Inorder(Node<T>* node);
	int Height(Node<T>* node);
	Node<T>* InorderPredecessor(Node<T>* node);
	Node<T>* InorderSuccessor(Node<T>* node);
	void Delete(T key) { Delete(root, key); }
	Node<T>* Delete(Node<T>* node, T key);
};

template <class T>
void BST<T>::IterativeInsert(T key) {
	Node<T>* p = new Node<T>;
	Node<T>* t, * u = nullptr;
	p->lchild = p->rchild = nullptr;
	p->data = key;

	if (!root) {
		root = p;
	}
	else {
		t = root;
		while (t) {
			if (key == t->data) {
				cout << "Duplicate Key." << endl;
				return;
			}
			else if (key > t->data) {
				u = t;
				t = t->rchild;
			}
			else {
				u = t;
				t = t->lchild;
			}
		}
		if (u->data > key) u->lchild = p;
		else u->rchild = p;
	}
}

template <class T>
Node<T>* BST<T>::RecursiveInsert(Node<T>* node, T key) {
	if (!node) {
		Node<T>* p = new Node<T>;
		p->rchild = p->lchild = nullptr;
		p->data = key;
		return p;
	}

	if (key > node->data) node->rchild = RecursiveInsert(node->rchild, key);
	else if (key < node->data) node->lchild = RecursiveInsert(node->lchild, key);
	else return nullptr;

	return node;
}

template <class T>
Node<T>* BST<T>::Search(T key) {
	Node<T>* p = root;
	while (p) {
		if (p->data == key) {
			cout << "Key is found" << endl;
			return p;
		}
		else if (p->data > key) p = p->lchild;
		else p = p->rchild;
	}

	cout << "Key not found." << endl;
	return nullptr;
}

template <class T>
void BST<T>::Inorder(Node<T>* node) {
	if (node) {
		Inorder(node->lchild);
		cout << node->data << " ";
		Inorder(node->rchild);
	}
}

template <class T>
Node<T>* BST<T>::Delete(Node<T>* node, T key) {
	if (!node) return nullptr;
	
	if (!node->lchild && !node->rchild) {
		if (!root) root = nullptr;
		delete node;
		return nullptr;
	}

	if (key < node->data) node->lchild = Delete(node->lchild, key);
	else if (key > node->data) node->rchild = Delete(node->rchild, key);
	else {
		if (Height(node->lchild) > Height(node->rchild)) {
			Node<T>* q = InorderPredecessor(node->lchild);
			node->data = q->data;
			node->lchild = Delete(node->lchild, q->data);
		}
		else {
			Node<T>* q = InorderSuccessor(node->rchild);
			node->data = q->data;
			node->rchild = Delete(node->rchild, q->data);
		}
	}

	return node;
}

template <class T>
int BST<T>::Height(Node<T>* node) {
	int x, y;
	if (node) {
		x = Height(node->lchild);
		y = Height(node->rchild);

		return x > y ? (x + 1) : (y + 1);
	}
	else return 0;
}

template <class T>
Node<T>* BST<T>::InorderPredecessor(Node<T>* node) {
	while (node && node->rchild) { node = node->rchild; }
	return node;
}

template <class T>
Node<T>* BST<T>::InorderSuccessor(Node<T>* node) {
	while (node && node->lchild) { node = node->lchild; }
	return node;
}

int main()
{
	std::cout << "Hello World!\n";
	BST<char> bst;
	bst.IterativeInsert('a');
	bst.IterativeInsert('b');
	bst.IterativeInsert('e');
	bst.IterativeInsert('c');
	bst.RecursiveInsert('d');
	bst.Inorder();
	bst.Delete('a');
	bst.Delete('e');
	bst.Inorder();
	bst.Search('a');
	bst.Search('e');
	bst.Search('A');
}