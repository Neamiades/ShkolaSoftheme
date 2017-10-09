using System.ComponentModel.DataAnnotations;
using ConsoleLib.Enums;
using ConsoleLib.Models;

namespace ConsoleLib.Attributes
{
    class OnlyForViewingAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ScienceBook book && book.Status == BookStatus.OnHands)
            {
                ErrorMessage = "Science books can't be given to reader!";
                return false;
            }

            return true;
        }
    }
}
