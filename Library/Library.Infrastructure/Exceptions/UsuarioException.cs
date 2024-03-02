
namespace Library.Infrastructure.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException(string message) : base(message) 
        {
            GuardarLog(message);
        }
        void GuardarLog(string message)
        {

        }
    }
}
