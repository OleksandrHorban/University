#include<iostream>
using namespace std;
int main() {
	int rows, cols;
	cout << "Enter rows and cols" << endl;
	cin >> rows >> cols;
	int** arr = new int* [rows];
	for (int i = 0; i < rows; i++)
	{
		arr[i] = new int[cols];
	}
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			arr[i][j] = rand()%10;
			if (i == j) {
				arr[i][j] += 10;
			}
		}
	}
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}


}
