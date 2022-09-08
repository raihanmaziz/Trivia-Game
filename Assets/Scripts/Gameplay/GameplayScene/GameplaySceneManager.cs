using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Gameplay.GameplayScene
{
    public class GameplaySceneManager : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
        }

        private void GoBack()
        {
            SceneManager.LoadScene("Level");
        }
    }
}

