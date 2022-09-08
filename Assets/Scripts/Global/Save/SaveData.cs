using System.Collections.Generic;
using TriviaGame.Global.Currency;
using TriviaGame.Global.Database;
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
        private DatabaseController _database;

        public int coin => _coin;
        public string[] unlockedPack => _unlockedPack;
        public string[] completedPack => _completedPack;
        public string[] completedLevel => _completedLevel;
        public string selectedPack => _selectedPack;
        public string selectedLevel => _selectedLevel;

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
            if (_unlockedPack.Length == 0)
            {
                UpdateUnlockedPack("PackA");
            }
        }

        private void Start()
        {
            _database = DatabaseController.databaseInstance;
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
            _selectedPack = packID;
        }

        public void UpdateUnlockedPack(string packID)
        {
            List<string> tempUnlock = new List<string>();
            for (int i = 0; i < _unlockedPack.Length; i++)
            {
                tempUnlock.Add(_unlockedPack[i]);
            }
            tempUnlock.Add(packID);
            _unlockedPack = tempUnlock.ToArray();
            Save();
        }

        public void UpdateSelectedLevel(string levelID)
        {
            _selectedLevel = levelID;
        }

        public void UpdateCompletedLevel(string levelID)
        {
            List<string> tempCompletedLevel = new List<string>();
            for (int i = 0; i < _completedLevel.Length; i++)
            {
                tempCompletedLevel.Add(_completedLevel[i]);
            }
            tempCompletedLevel.Add(levelID);
            _completedLevel = tempCompletedLevel.ToArray();
            string[] listLevelOnPack = _database.GetLevelList(_selectedPack);
            bool isAllLevelOnPackCompleted = true;
            bool[] isLevelCompleted = new bool[listLevelOnPack.Length];
            for (int i = 0; i < listLevelOnPack.Length; i++)
            {
                for (int j = 0; j < _completedLevel.Length; j++)
                {
                    if (listLevelOnPack[i] == _completedLevel[j])
                    {
                        isLevelCompleted[i] = true;
                    }
                }
            }
            for (int i = 0; i < isLevelCompleted.Length; i++)
            {
                if(!isLevelCompleted[i])
                {
                    isAllLevelOnPackCompleted = false;
                }
            }
            if(isAllLevelOnPackCompleted)
            {
                UpdateCompletedPack(_selectedPack);
            }
            Save();
        }

        public void UpdateCompletedPack(string packID)
        {
            List<string> tempCompletedPack = new List<string>();
            for (int i = 0; i < _completedPack.Length; i++)
            {
                tempCompletedPack.Add(_completedPack[i]);
            }
            tempCompletedPack.Add(packID);
            _completedPack = tempCompletedPack.ToArray();
            Save();
        }
    }
}

