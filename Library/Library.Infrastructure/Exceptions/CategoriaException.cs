
namespace Library.Infrastructure.Exceptions
{
    public class CategoriaException : Exception
    {
        public CategoriaException(string message) : base(message)
        {
            GuardarLog(message);
        }
        void GuardarLog(string message)
        {

        }
    }
}
