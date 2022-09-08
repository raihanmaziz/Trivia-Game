using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Global.Database
{
    public class DatabaseController : MonoBehaviour
    {
        public static DatabaseController databaseInstance;

        [SerializeField] private LevelStruct[] _levels;

        public LevelStruct[] levels => levels;

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
            string[] listPack = new string[_levels.Length];
            for (int i = 0; i < _levels.Length; i++)
            {
                bool isCopy = false;
                for (int j = 0; j < listPack.Length; j++)
                {

                }
            }
            return listPack;
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
            string[] tempList = new string[listLevel.Count];
            for (int i = 0; i < tempList.Length; i++)
            {
                tempList[i] = listLevel[i];
            }
            Debug.Log(tempList);
            return tempList;
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

