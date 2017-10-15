 using System.Data.Entity.Core;
 using PhonesDBProvider;
 using static System.Console;

namespace PhonesConsoleApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (var db = DbContext.Context)
                {
                    var phones = db.Phones;
                    int i = 1;
                    WriteLine("In our shop you can buy one of our phones:");
                    foreach (var phone in phones)
                    {
                        WriteLine($"{i++}. {phone.Name.Trim()} - {phone.Price}$");
                        WriteLine($"By {phone.Brand.Name}");
                        WriteLine("Characteristics:");
                        WriteLine($"{nameof(phone.Param.CPU)} - {phone.Param.CPU}");
                        WriteLine($"{nameof(phone.Param.Memory)} - {phone.Param.Memory}");
                        WriteLine($"{nameof(phone.Param.Capacity)} - {phone.Param.Capacity}");
                        WriteLine($"{nameof(phone.Param.Color)} - {phone.Param.Color}\n");
                    }
                }
            }
            catch (EntityException e)
            {
                WriteLine($"\nWe're sorry, but we had bad response from our database server: {e.Message}");
                WriteLine("Try again later");
            }
        }
    }
}
