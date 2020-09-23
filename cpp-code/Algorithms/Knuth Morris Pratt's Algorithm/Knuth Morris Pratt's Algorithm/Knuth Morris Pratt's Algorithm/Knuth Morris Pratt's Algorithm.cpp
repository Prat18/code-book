#include <iostream>

using namespace std;

int* buildPieTable(string p) {
	int* pie = new int[p.size()];
	int i = 0, j = 1;
	pie[i] = 0;
	while (j < p.size()) {
		if (p[i] == p[j]) {
			pie[j] = i + 1;
			i++;
			j++;
		}
		else {
			if(i == 0) {
				pie[j] = 0;
				i++;
				j++;
			}

			i = pie[i - 1];
		}
	}

	return pie;
}

int KMPAlgo(int* pie, string text, string pattern) {
	int i = 0, j = 0;
	while (i < text.size()) {
		if (j == pattern.size()) return i - pattern.size();
		if (text[i] == pattern[j]) {
			i++;
			j++;
		}
		else {
			if (j == 0) i++;
			else j = pie[j-1];
		}
	}
	if (j == pattern.size()) return i - pattern.size();
	return -1;
}

int main()
{
	string text, pattern;
	cout << "Enter text: ";
	cin >> text;
	cout << "Enter pattern: ";
	cin >> pattern;
	cout << endl;
	
	int *pie = buildPieTable(pattern);
	for (int i = 0; i < pattern.size(); i++) cout << pie[i] << " ";
	cout << endl;
	cout << KMPAlgo(pie, text, pattern);
}