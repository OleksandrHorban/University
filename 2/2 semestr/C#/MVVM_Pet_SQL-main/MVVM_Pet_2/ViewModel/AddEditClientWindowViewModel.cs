using MVVM_Pet_2.Core;
using MVVM_Pet_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Pet_2.ViewModel
{
    internal class AddEditClientWindowViewModel:ObservableObject
    {
            #region FieldsOfForm
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public int PetId { get; set; }
        public Pet selectedPet { get; set; }

        public List<Pet> Pets { get; set; }
        #endregion


        public Client currentClient;

        internal Action Close;
        public AddEditClientWindowViewModel() 
        {
            Pets = DataWorker.GetAllPets();
        }
        public AddEditClientWindowViewModel(Client selectedClient)
            {
                if (selectedClient != null)
                {
                    Pets = DataWorker.GetAllPets();
                    currentClient = selectedClient;

                    FullName = currentClient.FullName;
                    Phone = currentClient.Phone;
                    Email = currentClient.Email;
                    Address = currentClient.Address;
                    Info = currentClient.Info;
                    PetId = currentClient.PetId;
                }
        }



        private RelayCommand createClientCommand;
        public RelayCommand CreateClientCommand
        {
            get
            {
                return createClientCommand ?? new RelayCommand(obj =>
                {
                    string resultStr = "";
                    PetId = selectedPet.Id;
                    resultStr = DataWorker.CreateClient(FullName, Phone, Email, Address, Info, PetId);

                    DataWorker.ShowMessage(resultStr);
                    Close();
                });
            }
        }


        private RelayCommand editClientCommand;
        public RelayCommand EditClientCommand
        {
            get
            {
                return editClientCommand ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    while (resultStr == "")
                    {
                        try
                        {
                            PetId = selectedPet.Id;
                            resultStr = DataWorker.EditClient(currentClient, FullName, Phone, Email, Address, Info, PetId, Pets);
                            DataWorker.ShowMessage(resultStr);
                            Close();
                        }
                        catch
                        {
                            DataWorker.ShowMessage("Призначте клієнту вихованця! Поле ID");
                            break;
                        }
                    }
                });
            }
        }
    }
}
