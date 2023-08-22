#include<iostream.h>
#include<conio.h>
using namespace std;
void main()
{
    int matr[5][6], mas[5];      // mas[ ] — массив сумм  строк   
    int і, j, sum, stk;
    //--------------------- ввод матрицы matr(5,6)
    cout << "Vvod matr[5][6] \n";
    for (і = 0; і < 5; і++)
        for (j = 0; j < 6; j++)
            cin >> matr[i][j];
    //--------------- формирование массива сумм элементов строк
    for (і = 0; sum = 0; і < 5; і++)
    { // нахождение суммы элементов строки
        for (j = 0; j < 6; j++)
            sum += matr[i][j];
        mas[i] = sum
    }       //занесение суммы строки в массив
    cout << "\nMassiv summ el. strok" << endl;
    for (і = 0; і < 5; i++)
        cout << mas[i] << " ";
    //------------------ сортировка массива сумм по возрастанию
    for (і = 1; і < 5; і++)           // цикл шагов сортировки 
        for (j = 0; j < 5 - і; j++)      // цикл сравнен. и перестан. элем.
            if (mas[j] > mas[j + 1])
            {
                stk = mas[j];          // stk — для перестановки элементов 
                mas[j] = mas[j + 1];
                mas[j + 1] = stk;
            }
    cout << "\nOtsortirovanniy massiv \n";
    for (i = 0; і < 5; i++)
        cout << mas[i] << " ";
    getch();            //задержка экрана вывода результата
}
