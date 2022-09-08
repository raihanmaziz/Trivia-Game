using TriviaGame.Global.Save;
using UnityEngine;

namespace TriviaGame.Global.Currency
{
    public class CurrencyController : MonoBehaviour
    {
        private SaveData _saveData;

        private int _coin;

        private void Start()
        {
            _saveData = SaveData.saveInstance;
            GetCoin();
        }

        public int GetCoin()
        {
            return _saveData.coin;
        }

        public void AddCoin(int amount)
        {
            _coin += amount;
            _saveData.UpdateCoin(_coin);
        }

        public bool SpendCoin(int amount)
        {
            if (amount > _coin)
            {
                return false;
            }
            else
            {
                _coin -= amount;
                _saveData.UpdateCoin(_coin);
                return true;
            }
        }
    }
}

