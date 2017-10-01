using System.ComponentModel.DataAnnotations;

namespace ConsoleLib
{
    class OnlyForViewingAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ScienceBook book && (book.Status == BookStatus.OnHands || book.Holder != null))
            {
                ErrorMessage = "Science books can't be given to reader!";
                return false;
            }

            return true;
        }
    }
}
