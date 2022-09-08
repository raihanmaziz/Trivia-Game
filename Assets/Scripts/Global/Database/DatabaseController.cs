using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Global.Database
{
    public class DatabaseController : MonoBehaviour
    {
        public static DatabaseController databaseInstance;

        [SerializeField] private LevelStruct[] _levels;

        public LevelStruct[] levels => _levels;

        private void Awake()
        {
            if (databaseInstance == null)
            {
                databaseInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public string[] GetPackList()
        {
            List<string> listPack = new List<string>();
            for (int i = 0; i < _levels.Length; i++)
            {
                bool isCopy = false;
                for (int j = 0; j < listPack.Count; j++)
                {
                    if (_levels[i].packID == listPack[j])
                    {
                        isCopy = true;
                    }
                }
                if (!isCopy)
                {
                    listPack.Add(_levels[i].packID);
                }
            }
            return listPack.ToArray();
        }

        public string[] GetLevelList(string packID)
        {
            List<string> listLevel = new List<string>();
            for (int i = 0; i < _levels.Length; i++)
            {
                if (packID == _levels[i].packID)
                {
                    listLevel.Add(_levels[i].levelID);
                }
            }
            return listLevel.ToArray();
        }

        public LevelStruct GetLevelData(string LevelID)
        {
            for (int i = 0; i < _levels.Length; i++)
            {
                if (LevelID == _levels[i].levelID)
                {
                    return _levels[i];
                }
            }
            return null;
        }
    }
}

