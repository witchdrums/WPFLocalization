using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SignUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int lengthInTextBox = this.textBox_email.Text.Length;
            this.label_EmailCharacterCount.Content = lengthInTextBox;
            this.label_EmailInvalid.Visibility = Visibility.Hidden;
            this.textBox_email.BorderBrush = System.Windows.Media.Brushes.Gray;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) 
        {
            this.label_PasswordInvalid.Visibility = Visibility.Hidden;
            this.label_PasswordsDontMatch.Visibility = Visibility.Hidden;
            this.textBox_password.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.textBox_passwordConfirmation.BorderBrush = System.Windows.Media.Brushes.Gray;
        }

        private void button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            validateEmail();
            validatePassword();
            validateMatchingPasswords();
            //string password = this.textBox_
        }

        private void validateEmail()
        {
            Regex validEmailRegex = new Regex(
                "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\." +
                "[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:" +
                "[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+" +
                "[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"
            );
            string email = this.textBox_email.Text.ToString();
            if (validEmailRegex.IsMatch(email) == false)
            {
                this.textBox_email.BorderBrush = System.Windows.Media.Brushes.Red;
                this.label_EmailInvalid.Visibility = Visibility.Visible;
            }
        }

        private void validatePassword()
        {
            Regex validPasswordRegex = new Regex("^.*(?=.{10,})" +
            "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            string password = this.textBox_password.Password.ToString();
            if (validPasswordRegex.IsMatch(password) == false)
            {
                this.textBox_password.BorderBrush = System.Windows.Media.Brushes.Red;
                this.label_PasswordInvalid.Visibility = Visibility.Visible;
            }
        }

        private void validateMatchingPasswords()
        {
            string password = this.textBox_password.Password.ToString();
            string passwordConfirmation = this.textBox_passwordConfirmation.Password.ToString();
            if (password.Equals(passwordConfirmation) == false) 
            {
                this.textBox_password.BorderBrush = System.Windows.Media.Brushes.Red;
                this.textBox_passwordConfirmation.BorderBrush = System.Windows.Media.Brushes.Red;
                this.label_PasswordsDontMatch.Visibility = Visibility.Visible;
            }
        }
    }
}
