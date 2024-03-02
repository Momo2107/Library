

namespace Library.Infrastructure.Exceptions
{
    public class PrestamoException : Exception
    {
        public PrestamoException(string message) : base(message)
        {
            GuardarLog(message);
        }
        void GuardarLog(string message)
        {
            //x logica para almacenar el error
        }
    }
}
