using NamingSetter.Core;
using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace NamingSetter.MVVM.ViewModel
{
    public class CharactersListViewModel : BaseViewModel
    {
        #region Properties
        private string _ListBoxName;
        public string ListBoxName
        {
            get { return _ListBoxName; }
            set { _ListBoxName = value; OnPropertyChanged(); }
        }

        private ObjectInformation _SelectedCharacter;
        public ObjectInformation SelectedCharacter
        {
            get { return _SelectedCharacter; }
            set { _SelectedCharacter = value; OnPropertyChanged(); }
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
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand LevelChangedCommand { get; set; }
        public ICommand FrequencyChangedCommand { get; set; }
        #endregion
        public CharactersListViewModel()
        {
            Load();
        }
        void Load()
        {
            IsLevelEnabled = false;
            IsFrequencyEnabled = false;
            ListBoxItems = new ObservableCollection<string>();
            HiddenAddingScreen();
            ListBoxName = "Characters";
            LoadCommands();
        }
        void LoadCommands()
        {
            AddingScreenDisplayCommand = new RelayCommand<object>(p => true, p => { DisplayAddingScreen(); });
            AddCommand = new RelayCommand<object>(p => true, p => { AddCharacter(); });
            CancelCommand = new RelayCommand<object>(p => true, p => { HiddenAddingScreen(); AddingContent = ""; });
            RemoveCommand = new RelayCommand<object>(p => true, p => { RemoveCharacter(SelectedValue); });
            SelectionChangedCommand = new RelayCommand<object>(p => true, p => 
            {  
                SelectedCharacter = GetCharacter(SelectedValue);
                if(SelectedValue != null)
                {
                    IsLevelEnabled = true;
                    IsFrequencyEnabled = true;
                    FrequencyValue = SelectedCharacter.Frequency;
                    LevelValue = SelectedCharacter.Level;
                }
            });
            LevelChangedCommand = new RelayCommand<object>(p => true, p =>
            {
                if (SelectedCharacter != null)
                {
                    SelectedCharacter.Level = LevelValue;
                }
            });
            FrequencyChangedCommand = new RelayCommand<object>(p => true, p =>
            {
                if (SelectedCharacter != null)
                {
                    SelectedCharacter.Frequency = FrequencyValue;
                }
            });
        }
        ObjectInformation GetCharacter(string name)
        {
            var items = Information.Characters;
            foreach(ObjectInformation item in items)
            {
                if (item.Name == name) return item;
            }
            return null;
        }
        void DisplayAddingScreen()
        {
            AddingScreenVisibility = Visibility.Visible;
        }
        void HiddenAddingScreen()
        {
            AddingScreenVisibility = Visibility.Hidden;
        }
        void AddCharacter()
        {
            ListBoxItems.Add(AddingContent) ;
            Information.AddCharacter(new ObjectInformation() { Name = AddingContent, Frequency = 1, Level = 1});
            HiddenAddingScreen();
            AddingContent = "";
        }
        void RemoveCharacter(string selectedItem)
        {
            var items = Information.Characters;
            foreach (var item in items)
            {
                if (item.Name == selectedItem)
                {
                    Information.RemoveCharacter(item);
                    break;
                }
            }
            ListBoxItems.Remove(selectedItem);
        }
    }
}
