using TriviaGame.Global.Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Level.LevelScene
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

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

        private void GoBack()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}

