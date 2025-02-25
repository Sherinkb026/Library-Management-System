﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using LMSAPI.Models;
using LMSFrontend.Commands;
using LMSFrontend.Views;
using Newtonsoft.Json;

namespace LMSFrontend.ViewModel
{
    public class AvailableBooksViewModel : BaseViewModel<AvailableBooksViewModel>
    {

        public ObservableCollection<Books> AvailableBooks { get; set; }

        private readonly HttpClient _httpClient;

        private Books _selectedBook;



        public Books SelectedBook
        {
            get => _selectedBook;

            set => SetProperty(ref _selectedBook, value);
            
        }


        public ICommand BorrowCommand { get; set; }


        public AvailableBooksViewModel()
        {

            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7266/api/") };

            AvailableBooks = new ObservableCollection<Books>();

            BorrowCommand = new RelayCommands(ExecuteBorrowCommand, CanExecuteBorrowCommand);

            LoadAvailableBooks();

        }



        public async void LoadAvailableBooks()
        {
            try
            {

                //checks if the book is available
                var response = await _httpClient.GetStringAsync("Books/available");

                var books = JsonConvert.DeserializeObject<ObservableCollection<Books>>(response);

                AvailableBooks.Clear();

                foreach(var book in books)
                {

                    AvailableBooks.Add(book);

                }

               
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., show an error message)
                MessageBox.Show($"Error fetching books: {ex.Message}");
            }
        }


        private void ExecuteBorrowCommand(object parameter)
        {

            if (parameter is Books book)
            {

                var userInfoWindow = new UserInfoWindow(book);
                userInfoWindow.Show();  
                
            }
            else
            {
                MessageBox.Show("Please select a book to borrow");
            }

            
        }


        private bool CanExecuteBorrowCommand(object parameter)
        {
            return true;
        }


       


        
    }
}
