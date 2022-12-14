using TMPro;
using TriviaGame.Global.Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Pack.PackScene
{
    public class PackView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TextMeshProUGUI _coinText;

        private SaveData _saveData;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
        }

        private void Start()
        {
            _saveData = SaveData.saveInstance;
        }

        private void Update()
        {
            _coinText.text = _saveData.coin.ToString() + "C";
        }

        private void GoBack()
        {
            SceneManager.LoadScene("Home");
        }

        public void SelectPack(string packID)
        {
            for (int i = 0; i < _saveData.unlockedPack.Length; i++)
            {
                if (packID == _saveData.unlockedPack[i])
                {
                    _saveData.UpdateSelectedPack(packID);
                    SceneManager.LoadScene("Level");
                }
            }
        }
    }
}

