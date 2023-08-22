#include<iostream>
#include<iomanip>
#include<Windows.h>
using namespace std;
int main() {
	setlocale(0, "RUS");
	cout << "Вы гуль?\n1. Да\n2. Нет" << endl;
	int menu, avtobus = 1000;
	cin >> menu;
	system("cls");
	switch (menu) {
	case 1: {
		while (avtobus > 0) {
			cout << setw(10) << avtobus << " - 7 = ";
			avtobus -= 7;
			cout << avtobus << endl;
			Sleep(40);
		}
	}
		  break;
	default : 
		cout << "1000 - 7 ?" << endl;
		break;
	}
	system("pause");
}
