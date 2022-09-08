using TMPro;
using TriviaGame.Global.Database;
using TriviaGame.Global.Save;
using TriviaGame.Level.LevelScene;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Level.LevelData
{
    public class LevelDataController : MonoBehaviour
    {
        [SerializeField] private Button[] _selectButton;
        [SerializeField] private TextMeshProUGUI[] _levelName;
        [SerializeField] private Image[] _completeImage;
        [SerializeField] private LevelView _levelView;

        private string[] _listLevel;
        private LevelDataModel[] _levels;
        private SaveData _saveData;
        private DatabaseController _database;

        private void Awake()
        {
            _saveData = SaveData.saveInstance;
            _database = DatabaseController.databaseInstance;
            LoadLevelList();
            _levels = GetLevelList();
            InitLevelList(_levels);
        }

        private void LoadLevelList()
        {
            _listLevel = _database.GetLevelList(_saveData.selectedPack);
        }

        private LevelDataModel[] GetLevelList()
        {
            LevelDataModel[] tempLevel = new LevelDataModel[_listLevel.Length];
            for (int i = 0; i < tempLevel.Length; i++)
            {
                tempLevel[i].levelID = _listLevel[i];
                tempLevel[i].levelName = tempLevel[i].levelID;
                for (int j = 0; j < _saveData.completedLevel.Length; j++)
                {
                    if (tempLevel[i].levelID == _saveData.completedLevel[j])
                    {
                        tempLevel[i].isCompleted = true;
                    }
                }
            }
            return tempLevel;
        }

        private void InitLevelList(LevelDataModel[] levels)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                int tempIndex = i;
                _levelName[i].text = levels[i].levelName;
                _selectButton[i].onClick.AddListener(() => _levelView.SelectLevel(levels[tempIndex].levelID));
                if (levels[i].isCompleted)
                {
                    _completeImage[i].gameObject.SetActive(true);
                }
                _selectButton[i].gameObject.SetActive(true);
            }
        }
    }
}

