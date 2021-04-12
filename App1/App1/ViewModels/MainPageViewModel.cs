﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class MainPageViewModel: INotifyPropertyChanged
    {

        public MainPageViewModel()
        {
            Notes = new ObservableCollection<string>();

            SelectedNoteChangedCommand = new Command(async () =>
            {
                var detailVM = new DetailPageViewModel(SelectedNote);
                var detailPage = new DetailPage();
                detailPage.BindingContext = detailVM;

                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
            });

            EraseCommand = new Command(() => TheNote = string.Empty);

            SaveCommand = new Command(() =>
            {
                Notes.Add(TheNote);

                TheNote = string.Empty;
            });

        }
        
        public ObservableCollection<string> Notes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }

        public Command EraseCommand { get; }
        public Command SelectedNoteChangedCommand { get; }

        private string selectedNote;

        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedNote));
                PropertyChanged?.Invoke(this, args);
            }
        }


    }
}
