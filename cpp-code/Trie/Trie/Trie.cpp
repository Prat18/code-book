#include <iostream>

using namespace std;

const int ALPHABET_SIZE = 26;

class TrieNode {
public:
    TrieNode* children[ALPHABET_SIZE] = { nullptr };
    int count = 0;
    bool isEndOfWord = false;
};

class Trie {
private:
    TrieNode* root = nullptr;
public:
    void Insert(string word);
    string Delete(string word);
    bool Search(string word);
};

void Trie::Insert(string word) {
    if (root == nullptr) {
        TrieNode* node = new TrieNode;
        root = node;
    }

    TrieNode* current = root;

    for (int i = 0; i < word.length(); i++) {
        int index = word[i] - 'a';
        if (current->children[index] == nullptr) {
            TrieNode* node = new TrieNode;
            current->children[index] = node;
            current = node;
        }
        else current = current->children[index];
    }

    current->isEndOfWord = true;
    current->count++;
}

bool Trie:: Search(string word) {
    if (root == nullptr) return 0;
    
    TrieNode* current = root;
    
    for (int i = 0; i < word.length(); i++) {
        int index = word[i] - 'a';
        if (current->children[index]) current = current->children[index];
        else return 0;
    }

    if (current->isEndOfWord) return 1;
    else return 0;
    return true;
}

int main()
{
    std::cout << "Hello World!\n";
    Trie t;
    t.Insert("abc");
    cout << t.Search("abc") << endl;
    cout << t.Search("abcd");
}