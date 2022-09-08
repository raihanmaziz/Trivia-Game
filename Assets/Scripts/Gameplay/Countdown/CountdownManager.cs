using TMPro;
using TriviaGame.Gameplay.GameFlow;
using UnityEngine;

namespace TriviaGame.Gameplay.Countdown
{
    public class CountdownManager : MonoBehaviour
    {
        private float _timer = 0f;
        private long _remaining = 30;

        [SerializeField] private TextMeshProUGUI _countdownText;
        [SerializeField] private GameFlowManager _gameFlow;

        private void Awake()
        {
            Time.timeScale = 0f;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= 1f)
            {
                _remaining--;
                _countdownText.text = _remaining.ToString() + "s";
                _timer = 0f;
                if (_remaining == 0)
                {
                    FinishCountdown();
                }
            }
        }

        public void StartCountdown()
        {
            Time.timeScale = 1f;
        }

        public void StopCountdown()
        {
            Time.timeScale = 0f;
        }

        public void FinishCountdown()
        {
            StopCountdown();
            _gameFlow.Timeout();
        }
    }
}

