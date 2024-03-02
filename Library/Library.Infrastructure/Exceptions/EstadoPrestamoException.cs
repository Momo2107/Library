

namespace Library.Infrastructure.Exceptions
{
    public class EstadoPrestamoException : Exception
    {
        public EstadoPrestamoException(string message) : base(message)
        {
            GuardarLog(message);
        }

        void GuardarLog (string message)
        {

        }
    }
}
