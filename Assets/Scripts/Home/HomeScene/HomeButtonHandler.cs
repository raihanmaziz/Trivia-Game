using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Home.HomeScene
{
    public class HomeButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            _startButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(StartPlay);
        }

        public void StartPlay()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}

