namespace InvestmentManagerApi.Shared.Exceptions
{
    public class ClientErrorException : Exception
    {
        public string RedirectTo { get; }

        public ClientErrorException() : base()
        {
            this.RedirectTo = "/error";
        }

        public ClientErrorException(string redirectTo) : base()
        {
            this.RedirectTo = redirectTo;
        }
    }
}
