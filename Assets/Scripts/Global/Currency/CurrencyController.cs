using TriviaGame.Global.Save;
using UnityEngine;

namespace TriviaGame.Global.Currency
{
    public class CurrencyController : MonoBehaviour
    {
        public static CurrencyController currencyInstance;

        private SaveData _saveData;

        private int _coin;
        private int _coinIncrement = 20;

        private void Awake()
        {
            if (currencyInstance == null)
            {
                currencyInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _saveData = SaveData.saveInstance;
            _coin = GetCoin();
        }

        private void OnEnable()
        {
            EventManager.StartListening("FinishLevel", AddCurrency);
        }

        private void OnDisable()
        {
            EventManager.StopListening("FinishLevel", AddCurrency);
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

        private void AddCurrency(object data)
        {
            string levelID = (string)data;
            for (int i = 0; i < _saveData.completedLevel.Length; i++)
            {
                if(levelID == _saveData.completedLevel[i])
                {
                    return;
                }
            }
            _saveData.UpdateCompletedLevel(levelID);
            AddCoin(_coinIncrement);
        }
    }
}

