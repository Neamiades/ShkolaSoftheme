using static System.Console;

namespace ConsoleHuman
{
    class Human
    {
        public Human() : this(20) { }

        public Human(uint age) => Age = age;

        public string FirstName { get; set; }
        public string Lastame   { get; set; }
        public string BirthDate { get; set; }
        public uint   Age       { get; }

        //В том случае, если в задании имелась ввиду еквивалентность по значениям полей,
        //иначе в Object уже есть метод Equals, который можно даже переопределить.
        public bool Eq(Human otherHuman)
        {
            if (otherHuman.FirstName == FirstName
                && otherHuman.Lastame == Lastame
                && otherHuman.BirthDate == BirthDate
                && otherHuman.Age == Age)
            {
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            var h = new Human (21) {FirstName = "Serhii", Lastame = "Yakhin", BirthDate = "17/09/1996"};
            var h2 = new Human(21) { FirstName = "Lera", Lastame = "Urban", BirthDate = "17/09/1995" };
            WriteLine("Lera and Serhii is the same human?");
            WriteLine($"Answer: {h.Eq(h2)}");
        }
    }
}
