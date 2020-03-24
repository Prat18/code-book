#include <iostream>
#include "Stack.h"

using namespace std;

int isOperand(char x) {
    if (x == '+' || x == '-' || x == '/' || x == '*') return 0;
    else return 1;
}

int priority(char x) {
    if (x == '+' || x == '-') return 1;
    else if (x == '*' || x == '/') return 2;
    else return 0;
}

string intopost(string infix) {
    StackLL<char> stack;
    string postfix = "";
    int i = 0;

    while(i < infix.length()) {
        if (isOperand(infix[i])) postfix += infix[i];
        else if (priority(stack.peek()) < priority(infix[i])) stack.push(infix[i]);
        else {
            postfix += stack.peek();
            stack.pop();
            continue;
        }
        i++;
    }

    while (!stack.isEmpty()) {
        postfix += stack.peek();
        stack.pop();
    }

    return postfix;
}

int main()
{
    std::cout << "Hello World!\n";
    
    string infix = "a+b*c-d/e";
    cout << intopost(infix) << endl;

    infix = "a+b*c";
    cout << intopost(infix) << endl;
}