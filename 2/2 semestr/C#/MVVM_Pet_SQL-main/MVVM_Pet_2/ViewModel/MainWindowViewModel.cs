using MVVM_Pet_2.Core;
using MVVM_Pet_2.Models;
using MVVM_Pet_2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Window = System.Windows.Window;

namespace MVVM_Pet_2.ViewModel
{
    internal class MainWindowViewModel :ObservableObject
    {
        public MainWindowViewModel()
        {
            buttonPetsIsEnabled = false;
            buttonClientsIsEnabled = false;
            Authorization = false;
        }

        #region FIELDS
        public bool Authorization { get; set; }

        private bool buttonPetsIsEnabled;
        public bool ButtonPetsIsEnabled
        {
            get { return buttonPetsIsEnabled; } 
            set
            {
                buttonPetsIsEnabled = value;
                NotifyPropertyChanged();
            }
        }


        private bool buttonClientsIsEnabled;
        public bool ButtonClientsIsEnabled
        {
            get { return buttonClientsIsEnabled; }
            set
            {
                buttonClientsIsEnabled = value;
                NotifyPropertyChanged();
            }
        }


        private string loginText;
        public string LoginText
        {
            get { return loginText; } 
            set
            {
                loginText = value;
                NotifyPropertyChanged();
            }
        }


        private string passText;
        public string PassText
        {
            get { return passText; }
            set
            {
                passText = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region METHODS
        private void OpenWindowOfPets()
        {
            PetsWindow pWindow = new PetsWindow();
            DataWorker.SetCenterPositionAndOpen(pWindow);
        }

        private void OpenWindowOfClients()
        {
            ClientsWindow cWindow = new ClientsWindow();
            DataWorker.SetCenterPositionAndOpen(cWindow);
        }

        private void AccessActivation(object passwordBox)
        {
            string str = "Невірні дані";
            PassText = ((PasswordBox)passwordBox).Password;

            if (LoginText == "admin" && PassText == "admin")
            {
                ButtonPetsIsEnabled = true;
                ButtonClientsIsEnabled = true;
                Authorization = true;
            }
            else
            {
                DataWorker.ShowMessage(str);
            }
        }

        #endregion

        #region COMMANDS
        private RelayCommand openPetsWindow;
        public RelayCommand OpenPetsWindow
        {
            get
            {
                return openPetsWindow?? new RelayCommand(obj =>
                {
                    OpenWindowOfPets();
                });
            }
        }


        private RelayCommand openClientsWindow;
        public RelayCommand OpenClientsWindow
        {
            get
            {
                return openClientsWindow ?? new RelayCommand(obj =>
                {
                    OpenWindowOfClients();
                });
            }
        }



        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? new RelayCommand(obj =>
                {
                    AccessActivation(obj);
                });
            }
        }
        #endregion
    }
}
