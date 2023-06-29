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

namespace MVVM_Pet_2.ViewModel
{
    internal class ClientsWindowViewModel : ObservableObject
    {
        private List<Client> allClients = DataWorker.GetAllClients();
        public List<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                NotifyPropertyChanged();
            }
        }


        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                NotifyPropertyChanged();
                AllClients = DataWorker.FilterClient(filterText);
            }
        }


        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                NotifyPropertyChanged();
            }
        }

        private void OpenAddEditClientWindow()
        {
            AddEditClientWindow window = new AddEditClientWindow();
            AddEditClientWindowViewModel windowViewModel = new AddEditClientWindowViewModel();
            window.DataContext = windowViewModel;
            windowViewModel.Close = window.Close;
            window.editButton.IsEnabled = false;
            DataWorker.SetCenterPositionAndOpen(window);
        }
        private void OpenAddEditClientWindow(Client client)
        {
            AddEditClientWindow window = new AddEditClientWindow();
            AddEditClientWindowViewModel windowViewModel = new AddEditClientWindowViewModel(client);
            window.DataContext = windowViewModel;
            windowViewModel.Close = window.Close;
            window.createButton.IsEnabled = false;
            DataWorker.SetCenterPositionAndOpen(window);
        }



        #region CLIENT WINDOW COMMANDS

        private RelayCommand openCreateClientWindowCommand;
        public RelayCommand OpenCreateClientWindowCommand
        {
            get
            {
                return openCreateClientWindowCommand ?? new RelayCommand(obj =>
                {
                    OpenAddEditClientWindow();

                    AllClients = DataWorker.GetAllClients();
                });
            }
        }


        private RelayCommand openEditClientWindowCommand;
        public RelayCommand OpenEditClientWindowCommand
        {
            get
            {
                return openEditClientWindowCommand ?? new RelayCommand(obj =>
                {
                    OpenAddEditClientWindow(SelectedClient);

                    AllClients = DataWorker.GetAllClients();
                });
            }
        }


        private RelayCommand deleteClientCommand;
        public RelayCommand DeleteClientCommand
        {
            get
            {
                return deleteClientCommand ?? new RelayCommand(obj =>
                {
                    string result = null;

                    try
                    {
                        result = DataWorker.DeleteClient(SelectedClient);
                        DataWorker.ShowMessage(result);

                        AllClients = DataWorker.GetAllClients();
                    }
                    catch
                    {
                        DataWorker.ShowMessage(result);
                    }
                });
            }
        }

        #endregion
    }
}

