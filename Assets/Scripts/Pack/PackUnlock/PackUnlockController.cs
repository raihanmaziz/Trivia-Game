using TriviaGame.Global;
using TriviaGame.Global.Currency;
using TriviaGame.Global.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TriviaGame.Pack.PackUnlock
{
    public class PackUnlockController : MonoBehaviour
    {
        private SaveData _saveData;
        private CurrencyController _currency;

        private void Awake()
        {
            _saveData = SaveData.saveInstance;
            _currency = CurrencyController.currencyInstance;
        }

        public void UnlockPack(string packID)
        {
            if (_currency.SpendCoin(100))
            {
                _saveData.UpdateUnlockedPack(packID);
                EventManager.TriggerEvent("UnlockPack", packID);
            }
            else
            {
                Debug.Log("Not enough coin!");
            }
            SceneManager.LoadScene("Pack");
        }
    }
}

