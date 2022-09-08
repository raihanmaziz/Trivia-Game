using TMPro;
using TriviaGame.Global.Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Level.LevelScene
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TextMeshProUGUI _packText;

        private SaveData _saveData;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
        }

        private void Start()
        {
            _saveData = SaveData.saveInstance;
            _packText.text = "Level " + _saveData.selectedPack;
        }

        private void GoBack()
        {
            SceneManager.LoadScene("Pack");
        }

        public void SelectLevel(string levelID)
        {
            _saveData.UpdateSelectedLevel(levelID);
            SceneManager.LoadScene("Gameplay");
        }
    }
}

