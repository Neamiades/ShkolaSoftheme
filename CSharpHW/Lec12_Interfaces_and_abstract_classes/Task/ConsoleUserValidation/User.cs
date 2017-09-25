namespace ConsoleUserValidation
{
    class User : IUser
    {
        public string Name      { get; set; }
        public string Email     { get; set; }
        public string Password  { get; set; }
        public string LastEntry { get; set; }

        public string GetFullInfo()
        {
            return string.Concat(
                $"Users name: {Name}\n",
                $"Users email: {Email}\n",
                $"Users password: {Password}\n"
                );
        }
    }
}
