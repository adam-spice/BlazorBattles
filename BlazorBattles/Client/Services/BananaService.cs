using System;

namespace BlazorBattles.Client.Services
{
    public class BananaService : IBananaService
    {
        public int Bananas { get; set; } = 1000;

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
    }
}
