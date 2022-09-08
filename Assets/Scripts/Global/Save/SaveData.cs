using UnityEngine;

namespace TriviaGame.Global.Save
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData saveInstance;
        private const string _prefsKey = "SaveData";

        [SerializeField] private int _coin;
        [SerializeField] private string[] _unlockedPack;
        [SerializeField] private string[] _completedPack;
        [SerializeField] private string[] _completedLevel;
        private string _selectedPack;
        private string _selectedLevel;

        public int coin => _coin;
        public string[] unlockedPack => _unlockedPack;
        public string[] completedPack => _completedPack;
        public string[] completedLevel => _completedLevel;

        private void Awake()
        {
            if (saveInstance == null)
            {
                saveInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Load();
        }

        private void Save()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(_prefsKey, json);
            Debug.Log(json);
        }

        private void Load()
        {
            if (PlayerPrefs.HasKey(_prefsKey))
            {
                string json = PlayerPrefs.GetString(_prefsKey);
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else
            {
                Save();
            }
        }

        public void UpdateCoin(int coin)
        {
            _coin = coin;
            Save();
        }

        public void UpdateSelectedPack(string packID)
        {
            _selectedLevel = packID;
        }

        public void UpdateUnlockedPack(string packID)
        {
            string[] tempUnlocked = _unlockedPack;
            int newLength = tempUnlocked.Length + 1;
            _unlockedPack = new string[newLength];
            _unlockedPack = tempUnlocked;
            _unlockedPack[newLength - 1] = packID;
        }
    }
}

