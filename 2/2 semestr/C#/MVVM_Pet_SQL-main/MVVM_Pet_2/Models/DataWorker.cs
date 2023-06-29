using MVVM_Pet_2.View;
using MVVM_Pet_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MVVM_Pet_2.Models
{
    public static class DataWorker
    {
        #region MethodsForPet
        public static string CreatePet(string passport, string name, string type, DateTime dateOfBirth, int age, string breed, string color, string info)
        {
            string result = "Уже существует";
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                bool checkIsExist = db.Pets.Any(p => p.Passport == passport);
                if (!checkIsExist)
                {
                    Pet pet = new Pet
                    {
                        Passport = passport,
                        PetName = name,
                        PetType = type,
                        DateOfBirth = dateOfBirth,
                        Age = age,
                        Breed = breed,
                        Color = color,
                        Info = info
                    };
                    db.Pets.Add(pet);
                    db.SaveChanges();

                    result = "Добавлено!";
                }
                return result;
            }
        }


        public static string DeletePet(Pet pet)
        {
            string result = "Питомец не найден. Удаление не выполнено.";
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                try
                {
                    db.Pets.Remove(pet);
                    db.SaveChanges();
                    result = $"Питомец {pet.PetName} удален.";
                }
                catch
                {
                    return result;
                }
            }
            return result;
        }


        public static string EditPet(Pet oldPet, string passport, string name, string type, DateTime dateOfBirth, int age, string breed, string color, string info)
        {
            string result = "Питомец не найден. Редактирование не выполнено.";
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                try
                {
                    Pet pet = db.Pets.FirstOrDefault(d => d.Passport == oldPet.Passport);

                    pet.Passport = passport;
                    pet.PetName = name;
                    pet.PetType = type;
                    pet.DateOfBirth = dateOfBirth;
                    pet.Age = age;
                    pet.Breed = breed;
                    pet.Color = color;
                    pet.Info = info;

                    db.SaveChanges();

                    result = $"Питомец {pet.PetName} изменен.";
                }
                catch
                {
                    return result;
                }
            }
            return result;
        }


        public static List<Pet> GetAllPets()
        {
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                var result = db.Pets.ToList();

                return result;
            }
        }


        public static List<Pet> FilterPet(string str)
        {
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                var newList = new List<Pet>();
                var result = db.Pets.ToList();

                foreach (var pet in result)
                {
                    if (pet.PetName.IndexOf(str, StringComparison.CurrentCultureIgnoreCase) != -1)
                        newList.Add(pet);
                }
                return newList;
            }
        }

        #endregion

        #region MethodsForClient
        public static string CreateClient(string name, string phone, string email, string address, string info, int petId)
        {
            string result = "Уже существует";
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                bool checkIsExist = db.Clients.Any(p => p.FullName == name && p.Phone == phone);
                if (!checkIsExist)
                {
                    Client client = new Client
                    {
                        FullName = name,
                        Phone = phone,
                        Email = email,
                        Address = address,
                        Info = info,
                        PetId = petId,
                    };
                    db.Clients.Add(client);
                    db.SaveChanges();

                    result = "Добавлено!";
                }
                return result;
            }
        }


        public static string DeleteClient(Client client)
        {
            string result = "Клиент не найден. Удаление не выполнено.";
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                result = $"Клиент {client.FullName} удален.";
            }
            return result;
        }


        public static string EditClient(Client oldClient, string name, string phone, string email, string address, string info, int petId, List<Pet> pets)
        {
            string result = "Клиент не найден. Редактирование не выполнено.";
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                try
                {
                    Client client = db.Clients.FirstOrDefault(d => d.Id == oldClient.Id);
                    client.FullName = name;
                    client.Phone = phone;
                    client.Email = email;
                    client.Address = address;
                    client.Info = info;
                    client.PetId = petId;
                    client.Pets = pets;

                    db.SaveChanges();
                    result = $"Клиент {client.FullName} изменен.";
                }
                catch { return result; }
            }
            return result;
        }


        public static List<Client> GetAllClients()
        {
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                var result = db.Clients.ToList();
                return result;
            }
        }

        public static List<Client> FilterClient(string str)
        {
            using (VetClinic_DB_MsSQLContext db = new VetClinic_DB_MsSQLContext())
            {
                var newList = new List<Client>();
                var result = db.Clients.ToList();

                foreach (var client in result)
                {
                    if (client.FullName.IndexOf(str, StringComparison.CurrentCultureIgnoreCase) != -1)
                        newList.Add(client);
                }
                return newList;
            }
        }

        #endregion


        public static void ShowMessage(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }


        public static void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            window.ShowDialog();
        }
    }
}
