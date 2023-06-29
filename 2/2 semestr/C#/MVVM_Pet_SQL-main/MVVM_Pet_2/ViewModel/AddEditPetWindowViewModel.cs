using MVVM_Pet_2.Core;
using MVVM_Pet_2.Models;
using MVVM_Pet_2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace MVVM_Pet_2.ViewModel
{
    internal class AddEditPetWindowViewModel
    {
 
        #region FieldsOfForm
        public string PetPassport { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public DateTime PetDateOfBirth { get; set; }
        public int PetAge { get; set; }
        public string PetBreed { get; set; }
        public string PetColor { get; set; }
        public string PetInfo { get; set; }
        #endregion

        public Pet currentPet;
        internal Action Close;


        public AddEditPetWindowViewModel() {}
        public AddEditPetWindowViewModel(Pet selectedPet)
        {
            if (selectedPet != null)
            {
                currentPet = selectedPet;

                PetPassport = currentPet.Passport;
                PetName = currentPet.PetName;
                PetType = currentPet.PetType;
                PetDateOfBirth = (DateTime)currentPet.DateOfBirth;
                PetAge = currentPet.Age;
                PetBreed = currentPet.Breed;    
                PetColor = currentPet.Color;
                PetInfo = currentPet.Info;
            }
        }


        private RelayCommand createPetCommand;
        public RelayCommand CreatePetCommand
        {
            get
            {
                return createPetCommand ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    resultStr = DataWorker.CreatePet(PetPassport, PetName, PetType, PetDateOfBirth, PetAge, PetBreed, PetColor, PetInfo);
                    
                    DataWorker.ShowMessage(resultStr);
                    Close();
                });
            }
        }



        private RelayCommand editPetCommand;
        public RelayCommand EditPetCommand
        {
            get
            {
                return editPetCommand ?? new RelayCommand(obj =>
                {
                    string resultStr = "";

                    resultStr = DataWorker.EditPet(currentPet, PetPassport, PetName, PetType, PetDateOfBirth, PetAge, PetBreed, PetColor, PetInfo);
                    DataWorker.ShowMessage(resultStr);

                    Close();
                });
            }
        }

    }
}
