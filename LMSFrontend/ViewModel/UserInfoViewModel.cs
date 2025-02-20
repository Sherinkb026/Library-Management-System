using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LMSAPI.Models;
using LMSFrontend.Commands;
using LMSFrontend.Views;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;


namespace LMSFrontend.ViewModel
{
    public class UserInfoViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly HttpClient _httpClient;

        private readonly string _apiBaseUrl = "https://localhost:7266/api/User";

        private readonly string _apiBaseUrlBorrow = "https://localhost:7266/api/Borrow";



        public Books SelectedBook { get; set; }

        private string _username;
        private string _email;
        


        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }


        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }


        public ICommand ConfirmBorrowCommand { get; }

        public UserInfoViewModel(Books selectedBook)
        {

            _httpClient = new HttpClient();
            SelectedBook = selectedBook;
            ConfirmBorrowCommand = new RelayCommands(ExecuteConfirmBorrowCommand, CanExecuteConfirmBorrowCommand);

           
        }


        



        private bool CanExecuteConfirmBorrowCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Email);
        }




        //private async void ExecuteConfirmBorrowCommand(object obj)
        //{
        //    try
        //    {

        //        if (string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(Email))
        //        {
        //            MessageBox.Show("Username and email cannot be empty");
        //            return;
        //        }

        //        if (!IsValidEmail(Email))
        //        {
        //            MessageBox.Show("Invalid Email format");
        //            return;

        //        }




        //        var userBorrowResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/available?email={Email}");
        //        if (!userBorrowResponse.IsSuccessStatusCode)
        //        {
        //            string errorDetails = await userBorrowResponse.Content.ReadAsStringAsync();
        //            MessageBox.Show("Error in retrieving user details: {errorDetails}");
        //            return;

        //        }



        //        var userBorrowId = int.Parse(await userBorrowResponse.Content.ReadAsStringAsync());

        //        if (await HasAlreadyBorrowed(userBorrowId, SelectedBook.Id))
        //        {
        //            MessageBox.Show("You have already borrowed the book");
        //            return;
        //        }



        //        var user = new { Name = UserName, Email = Email };

        //        var json = JsonConvert.SerializeObject(user);

        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var userResponse = await _httpClient.PostAsync(_apiBaseUrl, content);

        //        var responseText = await userResponse.Content.ReadAsStringAsync();


        //        if (!userResponse.IsSuccessStatusCode)
        //        {
        //            MessageBox.Show("Error in saving user details");
        //            return;
        //        }

        //        var userId = await userResponse.Content.ReadAsStringAsync();

        //        var borrowRequest = new { BookId = SelectedBook.Id, UserId = int.Parse(userId) };

        //        var borrowJson = new StringContent(JsonConvert.SerializeObject(borrowRequest), Encoding.UTF8, "application/json");

        //        var borrowResponse = await _httpClient.PostAsync(_apiBaseUrlBorrow, borrowJson);

        //        if (!borrowResponse.IsSuccessStatusCode)
        //        {
        //            MessageBox.Show("Failed to borrow the book. The book may not be available");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Book Borrowed successfully");
        //            CloseCurrentWindow();


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}");
        //    }
        //}


        private async void ExecuteConfirmBorrowCommand(object obj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Email))
                {
                    MessageBox.Show("Username and email cannot be empty");
                    return;
                }

                if (!IsValidEmail(Email))
                {
                    MessageBox.Show("Invalid Email format");
                    return;
                }

                // Step 1: Check if the user exists
                var userBorrowResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/available?email={Email}");
                int userBorrowId;

                if (userBorrowResponse.IsSuccessStatusCode)
                {
                    // User exists, get the user ID
                    userBorrowId = int.Parse(await userBorrowResponse.Content.ReadAsStringAsync());
                }
                else if (userBorrowResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // User does not exist, create a new user
                    var user = new { Name = UserName, Email = Email };
                    var json = JsonConvert.SerializeObject(user);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var userResponse = await _httpClient.PostAsync(_apiBaseUrl, content);

                    if (!userResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error in saving user details");
                        return;
                    }

                    userBorrowId = int.Parse(await userResponse.Content.ReadAsStringAsync());
                }
                else
                {
                    MessageBox.Show("Error in retrieving user details");
                    return;
                }

                if (await HasAlreadyBorrowed(userBorrowId, SelectedBook.Id))
                {
                    MessageBox.Show("You have already borrowed the book");
                    return;
                }

                // Step 3: Proceed to borrow the book
                var borrowRequest = new { BookId = SelectedBook.Id, UserId = userBorrowId };
                var borrowJson = new StringContent(JsonConvert.SerializeObject(borrowRequest), Encoding.UTF8, "application/json");
                var borrowResponse = await _httpClient.PostAsync(_apiBaseUrlBorrow, borrowJson);

                if (!borrowResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Failed to borrow the book. The book may not be available");
                }
              
                else
                {
                    MessageBox.Show("Book Borrowed successfully");
                    CloseCurrentWindow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in borrowing the book: {ex.Message}");
            }
        }




        private void CloseCurrentWindow()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.IsActive) 
                    {
                        window.Close();
                        break;
                    }
                }
            });
        }








        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if(propertyName == nameof(UserName) || propertyName == nameof(Email))
            {
                (ConfirmBorrowCommand as RelayCommands)?.RaiseCanExecuteChanged();
            }
        }


        public async Task<bool> HasAlreadyBorrowed(int userId, int bookId)
        {
            

           

            var response = await _httpClient.GetStringAsync($"{_apiBaseUrlBorrow}/{userId}");

            var borrowedBooks = JsonConvert.DeserializeObject<List<BorrowRecords>>(response);

            return borrowedBooks.Any(b => b.BookId == bookId);
            
            
            
        }



        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
