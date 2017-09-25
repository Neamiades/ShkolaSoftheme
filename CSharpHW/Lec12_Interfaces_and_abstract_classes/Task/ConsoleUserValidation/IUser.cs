namespace ConsoleUserValidation
{
    interface IUser
    {
        string Name     { get; set; }
        string Password { get; set; }
        string Email    { get; set; }

        string GetFullInfo();
    }
}
