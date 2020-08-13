namespace LuxaforApiClient
{
    public class LuxaforApiClientFactory : ILuxaforApiClientFactory
    {
        public ILuxaforApiClient Initialize(string luxaforId)
        {
            return new LuxaforApiClient(luxaforId);
        }
    }
}
