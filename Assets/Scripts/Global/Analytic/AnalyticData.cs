using UnityEngine;

namespace TriviaGame.Global.Analytic
{
    public class AnalyticData : MonoBehaviour
    {
        public static AnalyticData analyticInstance;

        private void Awake()
        {
            if (analyticInstance == null)
            {
                analyticInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            EventManager.StartListening("FinishLevel", TrackFinishLevel);
            EventManager.StartListening("UnlockPack", TrackUnlockPack);
        }

        private void OnDisable()
        {
            EventManager.StopListening("FinishLevel", TrackFinishLevel);
            EventManager.StopListening("UnlockPack", TrackUnlockPack);
        }

        private void TrackFinishLevel(object data)
        {
            string levelID = (string)data;
            Debug.Log("Sending finished level: " + levelID);
        }

        private void TrackUnlockPack(object data)
        {
            string packID = (string)data;
            Debug.Log("Sending unlock pack: " + packID);
        }
    }
}

