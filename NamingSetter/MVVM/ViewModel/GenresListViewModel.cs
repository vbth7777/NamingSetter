using NamingSetter.Core;
using System;
using System.Windows.Input;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using System.Text.RegularExpressions;

namespace NamingSetter.MVVM.ViewModel
{
    public class GenresListViewModel : BaseViewModel
    {
        public string GenresListFileName = "./GenresList.txt";
        #region Properties
        private List<ListBoxItem> _ListBoxItems;
        public List<ListBoxItem> ListBoxItems
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

        private ObservableCollection<string> _CheckedGenreItems;
        public ObservableCollection<string> CheckedGenreItems
        {
            get { return _CheckedGenreItems; }
            set { _CheckedGenreItems = value; OnPropertyChanged(); }
        }

        private string _ListBoxName;
        public string ListBoxName
        {
            get { return _ListBoxName; }
            set { _ListBoxName = value; OnPropertyChanged(); }
        }

        private ObjectInformation _SelectedGenre;
        public ObjectInformation SelectedGenre
        {
            get { return _SelectedGenre; }
            set { _SelectedGenre = value; OnPropertyChanged(); }
        }

        private Visibility _LevelVisibility;
        public Visibility LevelVisibility
        {
            get { return _LevelVisibility; }
            set { _LevelVisibility = value; OnPropertyChanged(); }
        }

        private Visibility _FrequencyVisibility;
        public Visibility FrequencyVisibility
        {
            get { return _FrequencyVisibility; }
            set { _FrequencyVisibility = value; OnPropertyChanged(); }
        }

        private int _LevelValue;
        public int LevelValue
        {
            get { return _LevelValue; }
            set { _LevelValue = value; OnPropertyChanged(); }
        }

        private int _FrequencyValue;
        public int FrequencyValue
        {
            get { return _FrequencyValue; }
            set { _FrequencyValue = value; OnPropertyChanged(); }
        }

        //private string _AddingContent;
        //public string AddingContent
        //{
        //    get { return _AddingContent; }
        //    set { _AddingContent = value; OnPropertyChanged(); }
        //}

        #endregion
        #region Commands
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddingScreenDisplayCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand FrequencyValueChangedCommand { get; set; }
        public ICommand LevelValueChangedCommand { get; set; }
        public ICommand SelectionGenreChangedCommand { get; set; }
        #endregion
        public GenresListViewModel()
        {
            Load();
        }
        void Load()
        {
            AddingScreenHidden();
            ListBoxName = "Genres";
            CheckedGenreItems = new ObservableCollection<string>();
            ListBoxItems = new List<ListBoxItem>();
            LoadCommands();
        }
        void LoadCommands()
        {
            LoadCommand = new RelayCommand<object>(p => true, p => { LoadItems(); });
            //AddingScreenDisplayCommand = new RelayCommand<object>(p => true, p => { AddingScreenDisplay(); });
            //AddCommand = new RelayCommand<object>(p => true, p => { AddItem(); });
            //CancelCommand = new RelayCommand<object>(p => true, p => { CancelAdding(); });
            FrequencyValueChangedCommand = new RelayCommand<object>(p => true, p => { FrequencyValueChanged(); });
            LevelValueChangedCommand = new RelayCommand<object>(p => true, p => { LevelValueChanged(); });
            SelectionGenreChangedCommand = new RelayCommand<ComboBox>(p => p is ComboBox ? true : false, p => 
            {
                if (p.SelectedValue is null) return;
                string genreName = p.SelectedValue.ToString();
                SelectedGenre = Information.GetObjectInformationFromGenres(genreName);
                FrequencyValue = SelectedGenre.Frequency;
                LevelValue = SelectedGenre.Level;
            });
        }
        void FrequencyValueChanged()
        {
            if (CheckedGenreItems.Count == 0)
            {
                return;
            }
            SelectedGenre.Frequency = FrequencyValue;
        }
        void LevelValueChanged()
        {
            if (CheckedGenreItems.Count == 0)
            {
                return;
            }
            SelectedGenre.Level = LevelValue;
            //int length = CheckedGenreItems.Count();
            //for(int i = 0; i < length; ++i)
            //{
            //    if (CheckedGenreItems[i].IndexOf(SelectedGenre.Name) != -1)
            //    {
            //        CheckedGenreItems[i] = Regex.Replace(CheckedGenreItems[i], @"\((\d+),(\d+)\)$", (m) =>
            //        {
            //            return m.Groups[1].Value;
            //        });
            //    }
            //}
        }
        void LoadItems()
        {
            CheckAndCreateFile(GenresListFileName);
            string[] lines = File.ReadAllLines(GenresListFileName);
            foreach(string line in lines)
            {
                string genreName = line.Trim();
                if(genreName == "")
                {
                    continue;
                }
                AddCheckBoxItemToListView(genreName);
            }
        }
        void AddingScreenDisplay()
        {
            AddingScreenVisibility = Visibility.Visible;
        }
        void AddingScreenHidden()
        {
            AddingScreenVisibility = Visibility.Hidden;
        }
        //void CancelAdding()
        //{
        //    AddingScreenHidden();
        //    AddingContent = "";
        //}

        ListBoxItem GetItemInListBoxWithString(string text)
        {
            foreach (ListBoxItem item in ListBoxItems)
            {
                CheckBox checkBox = item.Content as CheckBox;
                if (checkBox != null)
                {
                    if (checkBox.Content.ToString() == text)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        //void AddItem()
        //{
        //    if (AddingContent == "" )
        //    {
        //        return;
        //    }
        //    string[] lines = File.ReadAllLines(GenresListFileName);
        //    foreach (string line in lines)
        //    {
        //        if (line.Trim() == AddingContent)
        //        {
        //            return;
        //        }
        //    }
        //    File.WriteAllText(GenresListFileName, AddingContent + Environment.NewLine, Encoding.UTF8);
        //    AddCheckBoxItemToListView(AddingContent);
        //    AddingContent = "";
        //    AddingScreenHidden();
        //}

        void CheckAndCreateFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }
        void AddCheckBoxItemToListView(string text)
        {
            ListBoxItem item = new ListBoxItem() { Padding = new Thickness(5, 0, 0, 0) };
            TextBlock content = new TextBlock() { Text = text };
            CheckBox checkBox = new CheckBox()
            {
                Width = 210,
                MinHeight = 45,
                Padding = new Thickness(5, 0, 15, 5),
                VerticalContentAlignment = VerticalAlignment.Center,
                Content = content 
            };
            checkBox.Click += ItemChecked;
            item.Content = checkBox;
            ListBoxItems.Add(item);
        }
        private void ItemChecked(object sender, RoutedEventArgs e)
        {
            CheckBox genreCheckBox = sender as CheckBox;
            string currentGenre = (genreCheckBox.Content as TextBlock).Text;
            if (genreCheckBox is null)
            {
                return;
            }
            if(genreCheckBox.IsChecked == true)
            {
                Information.AddGenre(new ObjectInformation() { Name = currentGenre, Frequency = 1, Level = 1});
                CheckedGenreItems.Add(currentGenre);
                return;
            }
            var items = Information.Genres;
            foreach (ObjectInformation item in items)
            {
                if (item.Name == currentGenre)
                {
                    items.Remove(item);
                    break;
                }
            }
            string removedValue = "";
            foreach (string genre in CheckedGenreItems)
            {
                if (genre.IndexOf(currentGenre) != -1)
                {
                    removedValue = genre;
                    break;
                }
            }
            CheckedGenreItems.Remove(removedValue);
        }
    }
}
