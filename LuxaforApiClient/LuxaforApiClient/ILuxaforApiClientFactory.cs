namespace LuxaforApiClient
{
    public interface ILuxaforApiClientFactory
    {
        ILuxaforApiClient Initialize(string luxaforId);
    }
}
