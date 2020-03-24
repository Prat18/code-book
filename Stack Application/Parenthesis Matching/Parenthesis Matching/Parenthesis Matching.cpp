#include <iostream>
#include "Stack.h"

int isBalanced(string exp) {
    StackLL<char> stack;

    for (char i : exp) {
        if (i == '(') stack.push(i);
        else if (i == ')') {
            if (stack.isEmpty()) return 0;
            //else if (stack.peek() == ')') return 0;
            else stack.pop();
        }
    }

    if (stack.isEmpty()) return 1;
    else return 0;
}

int main()
{
    string exp = "()(((())))()";
    if (isBalanced(exp)) cout << "Parenthesis are balanced!";
    else cout << "Invalid Expression!";
}