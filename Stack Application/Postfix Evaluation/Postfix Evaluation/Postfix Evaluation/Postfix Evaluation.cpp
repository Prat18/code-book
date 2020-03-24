#include <iostream>
#include "Stack.h"
#include "Intopost.h"

using namespace std;

int EvaluatePostfix(string postfix) {
    StackLL<int> stack;
    for (int i = 0; i < postfix.length(); i++) {
        if (isOperand(postfix[i])) stack.push(postfix[i] - '0');
        else {
            int x = stack.pop();
            int y = stack.pop();
            int result;
            if (postfix[i] == '*') result = x * y;
            else if (postfix[i] == '+') result = x + y;
            else if (postfix[i] == '/') result = y / x;
            else result = y - x;
            stack.push(result);
        }
    }

    return stack.peek();
}

int main()
{
    std::cout << "Hello World!\n";
    string infix = "4+1*6-8/2";
    string postfix = intopost(infix);
    cout << postfix << endl;
    cout << EvaluatePostfix("234*+82/-") << endl;
    return 0;
}