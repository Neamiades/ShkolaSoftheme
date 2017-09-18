using static System.Console;
namespace ConsoleCopyApp
{
    class RefUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public RefUser GetUserCopy()
        {
            var user = new RefUser
            {
                FirstName = FirstName,
                LastName = LastName,
                Nickname = Nickname
            };

            return user;
        }

        public void TellAbout(string paramName)
        {
            WriteLine($"User info of {paramName}: (Name: {FirstName} {LastName}, Nickname: {Nickname})");
            WriteLine("");
        }
    }

    struct ValUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public void TellAbout(string paramName)
        {
            WriteLine($"User info of {paramName}: (Name: {FirstName} {LastName}, Nickname: {Nickname})");
            WriteLine("");
        }
    }

    class Program
    {
        static void Main()
        {
            var rUser1 = new RefUser { FirstName = "Hex", LastName = "Gaga", Nickname = "Nexo" };
            var rUser2 = rUser1.GetUserCopy();

            WriteLine("---Stage ONE - referense type users---\n");
            WriteLine($"---{nameof(rUser2)} is a deep copy of {nameof(rUser1)}---\n");
            rUser1.TellAbout(nameof(rUser1));
            rUser2.TellAbout(nameof(rUser2));

            WriteLine($"---Change {nameof(rUser1)} nickname---\n");
            rUser1.Nickname = "Fox";

            rUser1.TellAbout(nameof(rUser1));
            rUser2.TellAbout(nameof(rUser2));

            rUser2 = rUser1;
            WriteLine($"---{nameof(rUser2)} is a shallow copy of {nameof(rUser1)} now---\n");

            rUser1.TellAbout(nameof(rUser1));
            rUser2.TellAbout(nameof(rUser2));

            WriteLine($"---Change {nameof(rUser2)} nickname---\n");
            rUser2.Nickname = "Turtle";

            rUser1.TellAbout(nameof(rUser1));
            rUser2.TellAbout(nameof(rUser2));

            var vUser1 = new ValUser { FirstName = "Jessica", LastName = "White", Nickname = "Gias" };
            var vUser2 = vUser1;

            WriteLine("---Stage TWO - value type users---\n");
            WriteLine($"---{nameof(vUser2)} is a deep copy of {nameof(vUser1)}, becouse they are value types---\n");
            vUser1.TellAbout(nameof(vUser1));
            vUser2.TellAbout(nameof(vUser2));

            WriteLine($"---Change {nameof(vUser1)} nickname---\n");
            vUser1.Nickname = "Fox";

            vUser1.TellAbout(nameof(vUser1));
            vUser2.TellAbout(nameof(vUser2));
        }
    }
}
