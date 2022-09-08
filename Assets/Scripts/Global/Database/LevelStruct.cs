using UnityEngine;

namespace TriviaGame.Global.Database
{
    [System.Serializable]
    [CreateAssetMenu]
    public class LevelStruct : ScriptableObject
    {
        public string levelID;
        public string packID;
        public string question;
        public string hint;
        public string[] choice;
        public int answer;
    }
}

