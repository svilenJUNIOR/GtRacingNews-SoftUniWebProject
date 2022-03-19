namespace GtRacingNews.Common.Constants
{
    public class Messages
    {
        /////////// Wrong register //////////////
       
        /// Email ///
        public const string ExistingEmail = "There's an account corresponding to that email!";
        public const string WrongEmailFormat = "Email must end with {0}";
        /// UserName ///
        public const string ExistingUsername = "There's an account corresponding to that username!";
        public const string WrongUsernameFormat = "Username must be between {0} and {1} characters!";
        /// Password ///
        public const string WrongPasswordFormat = "Password must be at least {0} characters!";
        public const string PasswordsDontMatch = "Passwords don't match!";

        /////////// Wrong login //////////////
        public const string UnExistingEmail = "No account corresponds to that email!";
        public const string UnExistingPassword = "No account corresponds to that password!";

        ////////// Wrong add form /////////////
        public const string LongerName = "Name cannot be more than 50 symbols!";       
        public const string LongerCarModel = "Car model cannot be more than 30 symbols!";       

        public const string NullField = "The form contains empty fields!";

        public const string ExistingNews = "News with that name already exists!";

        public const string ExistingTeam = "Team with that name already exists!";

        public const string ExistingRace = "Race with that name already exists!";

        public const string ExistingDriver = "Driver with that name alredy exists!";

        public const string ExistingChampionship = "Championship with that name already exists!";
    }
}
