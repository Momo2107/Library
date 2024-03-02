
namespace Library.Infrastructure.Exceptions
{
    public class LibroExceptions : Exception
    {
        public LibroExceptions(string message) : base(message)
        {
            GuardarLog(message);
        }
        void GuardarLog(string message)
        {

        }
    }
}
