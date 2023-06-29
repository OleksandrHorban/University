using Microsoft.EntityFrameworkCore.Query.Internal;
using MVVM_Pet_2.Core;
using MVVM_Pet_2.Models;
using MVVM_Pet_2.View;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.DesignerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVM_Pet_2.ViewModel
{
    internal class PetsWindowViewModel: ObservableObject
    {
        public PetsWindowViewModel()
        {
            
        }

        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                NotifyPropertyChanged();
                AllPets = DataWorker.FilterPet(filterText);
            }
        }


        private List<Pet> allPets = DataWorker.GetAllPets();
        public List<Pet> AllPets
        {
            get { return allPets; }
            set
            {
                allPets = value;
                NotifyPropertyChanged();
            }
        }
        

        private Pet selectedPet;
        public Pet SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                NotifyPropertyChanged();
            }
        }


        private void OpenAddEditPetWindow()
        {
            AddEditPetWindow window = new AddEditPetWindow();
            AddEditPetWindowViewModel windowViewModel = new AddEditPetWindowViewModel();
            window.DataContext = windowViewModel;
            windowViewModel.Close = window.Close;
            window.editButton.IsEnabled = false;
            DataWorker.SetCenterPositionAndOpen(window);
        }
        private void OpenAddEditPetWindow(Pet pet)
        {
            AddEditPetWindow window = new AddEditPetWindow();
            AddEditPetWindowViewModel windowViewModel = new AddEditPetWindowViewModel(pet);
            window.DataContext = windowViewModel;
            windowViewModel.Close = window.Close;
            window.createButton.IsEnabled = false;
            DataWorker.SetCenterPositionAndOpen(window);
        }


        #region PET WINDOW COMMANDS

        private RelayCommand openCreatePetWindowCommand;
        public RelayCommand OpenCreatePetWindowCommand
        {
            get
            {
                return openCreatePetWindowCommand ?? new RelayCommand(obj =>
                {
                    OpenAddEditPetWindow();

                    AllPets = DataWorker.GetAllPets();
                });
            }
        }


        private RelayCommand openEditPetWindowCommand;
        public RelayCommand OpenEditPetWindowCommand
        {
            get
            {
                return openEditPetWindowCommand ?? new RelayCommand(obj =>
                {
                    OpenAddEditPetWindow(SelectedPet);
                    
                    AllPets = DataWorker.GetAllPets();
                });
            }
        }



        private RelayCommand deletePetCommand;
        public RelayCommand DeletePetCommand
        {
            get
            {
                return deletePetCommand ?? new RelayCommand(obj =>
                {
                    string result = null;

                    try
                    {
                        result = DataWorker.DeletePet(SelectedPet);
                        DataWorker.ShowMessage(result);

                        AllPets = DataWorker.GetAllPets();
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
