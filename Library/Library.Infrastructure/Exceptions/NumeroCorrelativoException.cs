

namespace Library.Infrastructure.Exceptions
{
    public class NumeroCorrelativoException : Exception
    {
        public NumeroCorrelativoException(string message) : base(message)
        {
            GuardarLog(message);
        }

        void GuardarLog(string message)
        {

        }
    }
}
