using LuxaforApiClient.Enums;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace LuxaforApiClient
{
    public class LuxaforApiClient : ILuxaforApiClient
    {
        public const string _luxaforEndpoint = "https://api.luxafor.com/webhook/v1/actions/solid_color";

        public LuxaforApiClient(string luxaforId)
        {

        }

        public Task SetBlinkAsync(Color color, string hexadecimalColor)
        {
            throw new System.NotImplementedException();
        }

        public Task SetColorAsync(Color color, string hexadecimalColor)
        {
            throw new System.NotImplementedException();
        }

        public Task SetPatternAsync(Pattern pattern)
        {
            throw new System.NotImplementedException();
        }


        public async Task<T> GetRestResponseAsync<T>(string endpoint)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Luxafor-Jwt-Request");
            var streamTask = await client.GetStreamAsync(_luxaforEndpoint + endpoint);
            var response = await JsonSerializer.DeserializeAsync<T>(streamTask);

            return response;
        }

        private string GetJwtToken(string key, string secret)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var payload = new JwtPayload
            {
                { "iss", key },
            };

            var securityToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            string tokenString = handler.WriteToken(securityToken);

            return tokenString;
        }
    }
}
