using System.Net.Http;
using System.Text;
using System.Windows;
using LMSAPI.Models;
using LMSFrontend.Commands;
using Newtonsoft.Json;


namespace LMSFrontend.ViewModel
{
    public class UserInfoViewModel : BaseViewModel<UserInfoViewModel>
    {
        public Books SelectedBook { get; set; }
        public RelayCommands ConfirmBorrowCommand { get; }

        private readonly HttpClient _httpClient;

        private readonly string _apiBaseUrl = "https://localhost:7266/api/User";

        private readonly string _apiBaseUrlBorrow = "https://localhost:7266/api/Borrow";

        private string _username;

        private string _email;
        


        public string UserName
        {
            get => _username;

            set => SetProperty(ref _username, value);
        }



        public string Email
        {
            get => _email;

            set => SetProperty(ref _email, value);
        }



        public UserInfoViewModel(Books selectedBook)
        {

            _httpClient = new HttpClient();

            SelectedBook = selectedBook;

            ConfirmBorrowCommand = new RelayCommands(ExecuteConfirmBorrowCommand, CanExecuteConfirmBorrowCommand);

            RegisterPropertyChangedAction(nameof(UserName), () => ConfirmBorrowCommand.RaiseCanExecuteChanged());

            RegisterPropertyChangedAction(nameof(Email), () => ConfirmBorrowCommand.RaiseCanExecuteChanged());
 
        }



        private bool CanExecuteConfirmBorrowCommand(object obj)
        {

            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Email);

        }


        private async void ExecuteConfirmBorrowCommand(object obj)
        {

            try
            {


                if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Email))
                {

                    MessageBox.Show("Username and email cannot be empty","Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;

                }


                if (!IsValidEmail(Email))
                {
                    MessageBox.Show("Invalid Email format","Error", MessageBoxButton.OK, MessageBoxImage.Error);

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
                        MessageBox.Show("Error in saving user details","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }


                    userBorrowId = int.Parse(await userResponse.Content.ReadAsStringAsync());
                }
                else
                {

                    MessageBox.Show("Error in retrieving user details", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }


                if (await HasAlreadyBorrowed(userBorrowId, SelectedBook.Id))
                {
                    MessageBox.Show("You have already borrowed the book", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                // Step 3: Proceed to borrow the book
                var borrowRequest = new { BookId = SelectedBook.Id, UserId = userBorrowId };

                var borrowJson = new StringContent(JsonConvert.SerializeObject(borrowRequest), Encoding.UTF8, "application/json");

                var borrowResponse = await _httpClient.PostAsync(_apiBaseUrlBorrow, borrowJson);


                if (!borrowResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Failed to borrow the book. The book may not be available","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                }
              

                else
                {
                    MessageBox.Show("Book Borrowed successfully","Success", MessageBoxButton.OK,MessageBoxImage.Information);
                    CloseCurrentWindow();
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error in borrowing the book: {ex.Message}");
            }
        }


        //Closing current window
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


        //Checks if the user already borrowed the same book before
        public async Task<bool> HasAlreadyBorrowed(int userId, int bookId)
        {

            var response = await _httpClient.GetStringAsync($"{_apiBaseUrlBorrow}/{userId}");

            var borrowedBooks = JsonConvert.DeserializeObject<List<BorrowRecords>>(response);

            return borrowedBooks.Any(b => b.BookId == bookId);
   
        }


        //Email validation
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
