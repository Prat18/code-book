#include <iostream>

using namespace std;

static int visited[8] = { 0 };

void DFS(int G[][8], int n, int u) {
    if (visited[u] == 0) {
        cout << u << " ";
        visited[u] = 1;
        for (int i = 1; i < n; i++) {
            if (G[u][i] == 1) DFS(G, n, i);
        }
    }
}

int main()
{
    std::cout << "Hello World!\n";

    int G[8][8] = {
        {0,0,0,0,0,0,0,0},
        {0,0,1,1,1,0,0,0},
        {0,1,0,1,0,0,0,0},
        {0,1,1,0,1,0,0,0},
        {0,1,0,1,0,1,0,0},
        {0,0,0,1,1,0,1,1},
        {0,0,0,0,0,1,0,0},
        {0,0,0,0,0,1,0,0}
    };

    DFS(G, 8, 6);
}