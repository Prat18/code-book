#include <iostream>
#define I INT_MAX

using namespace std;

int edges[3][9] = {
    {1, 1, 2, 2, 3, 4, 4, 5, 5},
    {2, 6, 3, 7, 4, 5, 7, 7, 6},
    {25, 5, 12, 10, 8, 16, 14, 16, 20}
};

int set[] = { -1, -1, -1, -1, -1, -1, -1, -1 };
int included[9] = { 0 };
int tree[2][6];

void Union(int u, int v) {
    if (set[u] > set[v]) {
        set[v] = set[u] + set[v];
        set[u] = v;
    }
    else {
        set[u] = set[u] + set[v];
        set[v] = u;
    }
}

int Find(int u) {
    int index = u;
    u = set[u];
    while (u > 0) {
        index = u;
        u = set[u];
    }

    return index;
}

int main()
{
    std::cout << "Hello World!\n";
    int i = 0;
    while(i < 6) {
        int minweight = I, k;
        for (int j = 0; j < 9; j++) {
            if (edges[2][j] < minweight && included[j] != 1) {
                minweight = edges[2][j];
                k = j;
            }
        }
        included[k] = 1;
        int u = edges[0][k], v = edges[1][k];
        if (Find(u) != Find(v)) {
            Union(Find(u), Find(v));
            tree[0][i] = edges[0][k];
            tree[1][i] = edges[1][k];
            i++;
        }
    }

    for (int i = 0; i < 6; i++) cout << tree[0][i] << "--" << tree[1][i] << endl;
}