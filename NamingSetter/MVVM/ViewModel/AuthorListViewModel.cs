using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text;
using NamingSetter.Core;

namespace NamingSetter.MVVM.ViewModel
{
    public class AuthorListViewModel : BaseViewModel
    {
        #region Properties
        private string _ListBoxName;
        public string ListBoxName
        {
            get { return _ListBoxName; }
            set { _ListBoxName = value; OnPropertyChanged(); }
        }

        private string _SelectedValue;
        public string SelectedValue
        {
            get { return _SelectedValue; }
            set { _SelectedValue = value; OnPropertyChanged(); }
        }

        private int _FrequencyValue;
        public int FrequencyValue
        {
            get { return _FrequencyValue; }
            set { _FrequencyValue = value; OnPropertyChanged(); }
        }

        private int _LevelValue;
        public int LevelValue
        {
            get { return _LevelValue; }
            set { _LevelValue = value; OnPropertyChanged(); }
        }

        private bool _IsLevelEnabled;
        public bool IsLevelEnabled
        {
            get { return _IsLevelEnabled; }
            set { _IsLevelEnabled = value; OnPropertyChanged(); }
        }

        private bool _IsFrequencyEnabled;
        public bool IsFrequencyEnabled
        {
            get { return _IsFrequencyEnabled; }
            set { _IsFrequencyEnabled = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _ListBoxItems;
        public ObservableCollection<string> ListBoxItems
        {
            get { return _ListBoxItems; }
            set { _ListBoxItems = value; OnPropertyChanged(); }
        }

        private Visibility _AddingScreenVisibility;
        public Visibility AddingScreenVisibility
        {
            get { return _AddingScreenVisibility; }
            set { _AddingScreenVisibility = value; OnPropertyChanged(); }
        }

        private string _AddingContent;
        public string AddingContent
        {
            get { return _AddingContent; }
            set { _AddingContent = value; OnPropertyChanged(); }
        }
        #endregion
        #region Commands
        public ICommand AddingScreenDisplayCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        #endregion
        public AuthorListViewModel()
        {
            Load();
        }
        void Load()
        {
            IsLevelEnabled = false;
            IsFrequencyEnabled = false;
            ListBoxItems = new ObservableCollection<string>();
            HiddenAddingScreen();
            ListBoxName = "Authors";
            LoadCommands();
        }
        void LoadCommands()
        {
            AddingScreenDisplayCommand = new RelayCommand<object>(p => true, p => { DisplayAddingScreen(); });
            AddCommand = new RelayCommand<object>(p => true, p => { AddName(); });
            CancelCommand = new RelayCommand<object>(p => true, p => { HiddenAddingScreen(); AddingContent = ""; });
            RemoveCommand = new RelayCommand<object>(p =>
            {
                if (SelectedValue != null)
                    return true;
                return false;
            }, p => { RemoveName(SelectedValue); });
        }
        void DisplayAddingScreen()
        {
            AddingScreenVisibility = Visibility.Visible;
        }
        void HiddenAddingScreen()
        {
            AddingScreenVisibility = Visibility.Hidden;
        }
        void AddName()
        {
            if (ListBoxItems.Contains(AddingContent))
            {
                MessageBox.Show("Author is already exist");
            }
            else
            {
                ListBoxItems.Add(AddingContent) ;
                Information.AddAuthorName(AddingContent);
            }
            HiddenAddingScreen();
            AddingContent = "";
        }
        void RemoveName(string selectedItem)
        {
            Information.RemoveAuthorName(selectedItem);
            ListBoxItems.Remove(selectedItem);
        }
    }
}
