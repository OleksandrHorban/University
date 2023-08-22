#include<iostream>
using namespace std;
int main() {
	int n, i, j, k;
	cout << "Enter the number of rows = ";
	cin >> n;
	int m = n;
	for (i = 1; i < n; i++) {
		for (j = 1; j < m - 1; j++) {
			cout << " ";
		}
		for (k = 1; k <= 2 * i - 1; k++) {
			cout << "*";
		}
		m--;
		cout << endl;
	}
}
