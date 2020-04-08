#include <iostream>
#define I INT_MAX
#define SIZE 8

using namespace std;

int cost[SIZE][SIZE] = {
        {I, I, I, I, I, I, I, I},
        {I, I, 25, I, I, I, 5, I},
        {I, 25, I, 12, I, I, I, 10},
        {I, I, 12, I, 8, I, I, I},
        {I, I, I, 8, I, 16, I, 14},
        {I, I, I, I, 16, I, 20, 18},
        {I, 5, I, I, I, 29, I, I},
        {I, I, 10, I, 14, 18, I, I}
};
int near[SIZE];
int tree[2][SIZE - 1];

int main()
{
    std::cout << "Hello World!\n";
    for (int i = 0; i < SIZE; i++) near[i] = I;
    int minweight = I, u, v, k;
    for (int i = 1; i < SIZE; i++) {
        for (int j = i; j < SIZE; j++) {
            if (cost[i][j] < minweight) {
                minweight = cost[i][j];
                u = i;
                v = j;
            }
        }
    }

    tree[0][0] = u;
    tree[1][0] = v;
    near[u] = near[v] = 0;

    for (int i = 1; i < SIZE; i++) {
        if (near[i] == 0) continue;
        if (cost[i][u] < cost[i][v]) near[i] = u;
        else near[i] = v;
    }

    for (int i = 1; i < SIZE - 2; i++) {
        minweight = I;
        for (int j = 1; j < SIZE; j++) {
            if (near[j] == 0) continue;
            if (cost[j][near[j]] < minweight) {
                minweight = cost[j][near[j]];
                k = j;
            }
        }

        tree[0][i] = k;
        tree[1][i] = near[k];
        near[k] = 0;
        
        for (int j = 1; j < SIZE; j++) {
            if (near[j] == 0) continue;
            if (cost[j][k] < cost[j][near[j]]) near[j] = k;
        }
    }

    for (int i = 0; i < SIZE - 2; i++) {
        for (int j = 0; j < 2; j++) {
            cout << tree[j][i] << " ";
        }
        cout << endl;
    }
}