﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class CreateManagerViewModel : ViewModelBase
    {
        CreateManager cm;
        Entity context = new Entity();

        public CreateManagerViewModel(CreateManager createManagerOpen)
        {
            cm = createManagerOpen;
            sssList = GetSSS();
        }
        
        private List<tblDegree> ssslist;
        public List<tblDegree> sssList
        {
            get
            {
                return ssslist;
            }
            set
            {
                ssslist = value;
                OnPropertyChanged("sssList");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        private string mail;
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        private int floor;
        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
                OnPropertyChanged("Floor");
            }
        }
        private int experience;
        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
            }
        }
        private tblDegree sss;
        public tblDegree Sss
        {
            get
            {
                return sss;
            }
            set
            {
                sss = value;
                OnPropertyChanged("Sss");
            }
        }
        private string birthday;
        public string Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        private ICommand createManager;
        public ICommand CreateManager
        {
            get
            {
                if (createManager == null)
                {
                    createManager = new RelayCommand(param => CreateManagerExecute(), param => CanCreateManagerExecute());
                }
                return createManager;
            }
        }

        private void CreateManagerExecute()
        {
            try
            {
                using (Entity context = new Entity())
                {
                    tblAll newAll = new tblAll();
                    newAll.FirstName = Name;
                    newAll.Surname = Surname;
                    newAll.Email = Mail;
                    newAll.Username = Username;
                    newAll.Pasword = Password;
                    context.tblAlls.Add(newAll);
                    context.SaveChanges();
                    tblManager newManager = new tblManager();
                    newManager.AllIDman = newAll.All_ID;
                    newManager.Experience = Experience;
                    newManager.SSS = Sss.name;
                    newManager.ManagerFlor = Floor;
                    context.tblManagers.Add(newManager);
                    context.SaveChanges();
                    MessageBox.Show("Manager is created");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCreateManagerExecute()
        {
            if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Surname) || String.IsNullOrEmpty(Mail) || String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Floor.ToString()) || String.IsNullOrEmpty(Experience.ToString()) || String.IsNullOrEmpty(Sss.name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            cm.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }

        private List<tblDegree> GetSSS()
        {
            List<tblDegree> list = new List<tblDegree>();
            list = context.tblDegrees.ToList();

            return list;
        }
    }
}
