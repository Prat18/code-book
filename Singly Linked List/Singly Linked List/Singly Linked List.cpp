#include <iostream>

using namespace std;

class Node {
public:
	int data;
	Node* next;
};

class LinkedList {
private:
	Node* first;
public:
	LinkedList() { first = NULL; }
	LinkedList(int A[], int size);
	~LinkedList();

	void Display();
	void Insert(int index, int x);
	int Delete(int Index);
	int isSorted();
	int Length();
	int* MaxMinData();
	//Node* RecursiveMaxData(Node* p, int key);
	Node* LinearSearch(int key);
	Node* RecursiveSearch(int key) { return RecursiveSearch(first, key);  }
	Node* RecursiveSearch(Node* p, int key);
	Node* GetFirstNode();
	void RemoveDuplicate();
	void SortedInsert(int key);
	void MergeLists(Node* b);
	void Destructor();
	void ReverseList();
};

LinkedList::LinkedList(int A[], int size) {
	Node* last, * p;
	first = new Node;

	first->data = A[0];
	first->next = nullptr;
	last = first;

	for (int i = 1; i < size; i++) {
		p = new Node;
		p->data = A[i];
		p->next = nullptr;
		last->next = p;
		last = last->next;
	}
}

LinkedList::~LinkedList() {
	Node* p = first;

	while (first) {
		first = first->next;
		delete p;
		p = first;
	}
}

void LinkedList::Display() {
	Node* p = first;

	while (p) {
		cout << p->data << " ";
		p = p->next;
	}

	cout << endl;
}

void LinkedList::Insert(int pos, int x) {
	if (pos < 0 || pos > Length()) {
		cout << "Invalid Argument." << endl;
		return;
	}

	Node* t = new Node;
	t->data = x;

	if (pos == 0) {
		t->next = first;
		first = t;
	}
	else {
		Node* p = first;
		for (int i = 0; i < pos - 1; i++) p = p->next;
		t->next = p->next;
		p->next = t;
	}
}

int LinkedList::Length() {
	Node* p = first;
	int length = 0;

	while (p) {
		length++;
		p = p->next;
	}

	return length;
}

int LinkedList::Delete(int pos) {
	Node* p = first, * q = nullptr;
	int x = -1;

	if (pos < 0 || pos > Length()) {
		cout << "Invalid Argument." << endl;
		return x;
	}

	if (pos == 1) {
		first = first->next;
		x = first->data;
		delete p;
	}
	else {
		for (int i = 0; i < pos - 1; i++) {
			q = p;
			p = p->next;
		}
		q->next = p->next;
		x = p->data;
		delete p;
	}

	return x;
}

int* LinkedList::MaxMinData() {
	Node* p = first;
	int max = first->data;
	int min = first->data;

	while (p) {
		int x = p->data;
		if (x > max) max = x;
		else if(x < min) min = x;
		p = p->next;
	}

	int res[] = { max, min };
	return res;
}

Node * LinkedList::LinearSearch(int key) {
	Node* p = first;
	
	while (p) {
		if (p->data == key) return p;
		p = p->next;
	}

	return nullptr;
}

Node* LinkedList::RecursiveSearch(Node* p, int key) {
	if (!p) return nullptr;
	else if (p->data == key) return p;
	else return RecursiveSearch(p->next, key);
}

Node* LinkedList::GetFirstNode() {
	return first;
}

int LinkedList::isSorted() {
	if (!first->next) return 0;
	Node* p = first, * q = first->next;
	
	while (q) {
		if (q->data < p->data) return 0;
		p = q;
		q = q->next;
	}
	return 1;
}

void LinkedList::MergeLists(Node* second) {
	Node* third, * last;
	if (!second) return;

	if (first->data > second->data) {
		last = third = second;
		second = second->next;
	}
	else {
		last = third = first;
		first = first->next;
	}
	last->next = nullptr;

	while (first && second) {
		if (first->data > second->data) {
			last->next = second;
			last = second;
			second = second->next;
		}
		else {
			last->next = first;
			last = first;
			first = first->next;
		}
		last->next = nullptr;
	}
	if (!first) last->next = second;
	else if (!second) last->next = first;
	first = third;
}

void LinkedList::RemoveDuplicate() {
	if (!isSorted() || !first) {
		cout << "Invalid List";
		return;
	}
	Node* p = first, * q = first->next;
	while (q) {
		if (p->data == q->data) {
			p->next = q->next;
			delete q;
			q = p->next;
		}
		else {
			p = q;
			q = q->next;
		}
	}
}

void LinkedList::ReverseList() {
	Node* p, * q, * r = first;
	p = q = nullptr;
	while (r) {
		p = q;
		q = r;
		r = r->next;
		q->next = p;
	}

	first = q;
}

void LinkedList::SortedInsert(int key) {
	if (!isSorted() || !first) cout << "Invalid list." << endl;
	Node* p = first, * q = first->next;
	int index = 0;

	while (p) {
		if (p->data < key) {
			index++;
			p = p->next;
		}
		else break;
	}

	Insert(index, key);
}

void LinkedList::Destructor() {
	Node* p = first, * q;
	while (p) {
		q = p;
		p = p->next;
		q = nullptr;
	}
}

int main()
{
	cout << "Hello World!\n";
	int A[] = { 1, 2, 2, 4, 5, 5, 18 };
	LinkedList l(A, 7);
	l.Display();
	l.SortedInsert(0);
	l.Display();
	return 0;
}