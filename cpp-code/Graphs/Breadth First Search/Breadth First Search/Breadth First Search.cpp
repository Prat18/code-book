#include <iostream>
#include "Queue.h"

using namespace std;

void BFS(int G[][8], int n, int u) {
    int* visited = new int[n];
    for (int i = 0; i < n; i++) visited[i] = 0;
    QueueLL<int> Q;
    visited[u] = 1;
    cout << u << " ";
    Q.enqueue(u);

    while (!Q.isEmpty()) {
        u = Q.dequeue();
        for (int i = 1; i < n; i++) {
            if (G[u][i] == 1 && visited[i] == 0) {
                cout << i << " ";
                visited[i] = 1;
                Q.enqueue(i);
            }
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

    BFS(G, 8, 1);
}