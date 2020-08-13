using LuxaforApiClient.Enums;
using System.Threading.Tasks;

namespace LuxaforApiClient
{
    public interface ILuxaforApiClient
    {
        Task SetBlinkAsync(Color color, string hexadecimalColor);

        Task SetColorAsync(Color color, string hexadecimalColor);

        Task SetPatternAsync(Pattern pattern);
    }
}
