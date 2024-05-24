namespace InvestmentManagerApi.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        private const string defaultMessage = "Entity not found";

        public NotFoundException(string message) : base(message) 
        { 

        }

        public NotFoundException() : base(defaultMessage)
        {
            
        }
    }
}
