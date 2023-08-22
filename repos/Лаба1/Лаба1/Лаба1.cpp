#include <iostream>
#include <Windows.h>
using namespace std;
HANDLE c;

void print(int** arr, int x, int y)
{
	for (int i = 0; i < x; i++)
	{
		for (int j = 0; j < y; j++)
		{
			cout << *(*(arr + i) + j) << " ";
		}
		cout << endl;
	}
}

void func_AND(int** arr, int n, int x, int z, int num)
{
	for (int i = 0; i < n; i++)
	{
		if (arr[i][x] == 1 && arr[i][z] == 1)
		{
			arr[i][num] = 1;
		}
		else
		{
			arr[i][num] = 0;
		}
	}
}

void func_OR(int** arr, int n, int x, int z, int num)
{
	for (int i = 0; i < n; i++)
	{
		if (arr[i][x] == 1 && arr[i][z] == 1 || arr[i][x] == 1 && arr[i][z] == 0 || arr[i][x] == 0 && arr[i][z] == 1)
		{
			arr[i][num] = 1;
		}
		else
		{
			arr[i][num] = 0;
		}
	}
}

void func_NO(int** arr, int n, int x, int num)
{
	for (int i = 0; i < n; i++)
	{
		if (arr[i][x] == 0)
		{
			arr[i][num] = 1;
		}
		else
		{
			arr[i][num] = 0;
		}
	}
}

void func_Impl(int** arr, int n, int x, int z, int num)
{
	for (int i = 0; i < n; i++)
	{
		if (arr[x][i] <= arr[z][i])
		{
			arr[i][num] = 1;
			arr[2][4] = 1;
		}
		else
		{
			arr[i][num] = 0;
		}
	}
}
void type(int** arr, int n, int m)
{
	string s; string p;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (arr[i][m - 1] == 0)
			{
				s = "Тип таблиці:";
				p = " суперечність";
			}
			if (arr[i][m - 1] == 1)
			{
				s = "Тип таблиці:";
				p = " тавтологія";
			}
			if (arr[i][m - 1] != 0)
			{
				s = "Тип таблиці:";
				p = " виконувана";
			}
			if (arr[i][m - 1] != 1 && arr[i][m - 1] != 0)
			{
				s = "Тип таблиці:";
				p = " нейтральна";
			}
		}
	}
	SetConsoleTextAttribute(c, 15);
	cout << endl << s;
	SetConsoleTextAttribute(c, 4);
	cout << p;
	SetConsoleTextAttribute(c, 15);
}

int main()
{
	c = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	const int n = 16;
	const int m = 8;
	int** arr = new int* [n];
	for (int i = 0; i < n; i++)
	{
		*(arr + i) = new int[m];
	}
	cout << "Y" << " Z " << "X" << " K" << endl;
	arr[0][0] = 0; arr[0][1] = 0; arr[0][2] = 0; arr[0][3] = 0;
	arr[1][0] = 0; arr[1][1] = 0; arr[1][2] = 0; arr[1][3] = 1;
	arr[2][0] = 0; arr[2][1] = 0; arr[2][2] = 1; arr[2][3] = 0;
	arr[3][0] = 0; arr[3][1] = 0; arr[3][2] = 1; arr[3][3] = 1;
	arr[4][0] = 0; arr[4][1] = 1; arr[4][2] = 0; arr[4][3] = 0;
	arr[5][0] = 0; arr[5][1] = 1; arr[5][2] = 0; arr[5][3] = 1;
	arr[6][0] = 0; arr[6][1] = 1; arr[6][2] = 1; arr[6][3] = 0;
	arr[7][0] = 0; arr[7][1] = 1; arr[7][2] = 1; arr[7][3] = 1;
	arr[8][0] = 1; arr[8][1] = 0; arr[8][2] = 0; arr[8][3] = 0;
	arr[9][0] = 1; arr[9][1] = 0; arr[9][2] = 0; arr[9][3] = 1;
	arr[10][0] = 1; arr[10][1] = 0; arr[10][2] = 1; arr[10][3] = 0;
	arr[11][0] = 1; arr[11][1] = 0; arr[11][2] = 1; arr[11][3] = 1;
	arr[12][0] = 1; arr[12][1] = 1; arr[12][2] = 0; arr[12][3] = 0;
	arr[13][0] = 1; arr[13][1] = 1; arr[13][2] = 0; arr[13][3] = 1;
	arr[14][0] = 1; arr[14][1] = 1; arr[14][2] = 1; arr[14][3] = 0;
	arr[15][0] = 1; arr[15][1] = 1; arr[15][2] = 1; arr[15][3] = 1;

	func_NO(arr, n, 1, 4);
	func_AND(arr, n, 3, 4, 5);
	func_OR(arr, n, 2, 0, 6);
	func_OR(arr, n, 6, 5, 7);
	print(arr, n, m);
	cout << endl;
	delete[] arr;
	return 0;
}