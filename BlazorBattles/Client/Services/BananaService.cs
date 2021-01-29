using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class BananaService : IBananaService
    {
        private readonly HttpClient _http;

        public BananaService(HttpClient http)
        {
            _http = http;
        }
        public int Bananas { get; set; } = 0;

        public event Action OnChnage;

        public void AddBananas(int amount)
        {
            Bananas += amount;
            BananasChnaged();
        }

        public void EatBananas(int amount)
        {
            Bananas -= amount;
            BananasChnaged();
        }
        void BananasChnaged() => OnChnage.Invoke();

        public async Task GetBananas()
        {
            Bananas = await _http.GetFromJsonAsync<int>("api/User/GetBananas");
            BananasChnaged();
        }

    }
}
