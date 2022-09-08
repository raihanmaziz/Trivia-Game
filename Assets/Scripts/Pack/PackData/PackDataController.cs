using TMPro;
using TriviaGame.Global.Database;
using TriviaGame.Global.Save;
using TriviaGame.Pack.PackScene;
using TriviaGame.Pack.PackUnlock;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Pack.PackData
{
    public class PackDataController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _packName;
        [SerializeField] private TextMeshProUGUI[] _unlockCost;
        [SerializeField] private Button[] _selectButton;
        [SerializeField] private Button[] _unlockButton;
        [SerializeField] private Image[] _completeImage;
        [SerializeField] private Image[] _lockImage;
        [SerializeField] private PackView _packView;
        [SerializeField] private PackUnlockController _packUnlock;

        private string[] _listPack;
        private PackDataModel[] _packs;
        private DatabaseController _database;
        private SaveData _saveData;

        private void Awake()
        {
            _saveData = SaveData.saveInstance;
            _database = DatabaseController.databaseInstance;
            LoadPackList();
            _packs = GetPackList();
            InitPackList(_packs);
        }

        private void LoadPackList()
        {
            _listPack = _database.GetPackList();
        }

        private PackDataModel[] GetPackList()
        {
            PackDataModel[] tempPacks = new PackDataModel[_listPack.Length];
            for (int i = 0; i < tempPacks.Length; i++)
            {
                tempPacks[i].packID = _listPack[i];
                tempPacks[i].packName = tempPacks[i].packID;
                for (int j = 0; j < _saveData.completedPack.Length; j++)
                {
                    if (tempPacks[i].packID == _saveData.completedPack[j])
                    {
                        tempPacks[i].isCompleted = true;
                    }
                }
                for (int j = 0; j < _saveData.unlockedPack.Length; j++)
                {
                    if (tempPacks[i].packID == _saveData.unlockedPack[j])
                    {
                        tempPacks[i].isUnlocked = true;
                    }
                }
            }
            return tempPacks;
        }

        private void InitPackList(PackDataModel[] packs)
        {
            for (int i = 0; i < packs.Length; i++)
            {
                int tempIndex = i;
                _packName[i].text = packs[i].packName;
                _unlockCost[i].text = packs[i].unlockCost.ToString();
                _selectButton[i].onClick.AddListener(() => _packView.SelectPack(packs[tempIndex].packID));
                _unlockButton[i].onClick.AddListener(() => _packUnlock.UnlockPack(packs[tempIndex].packID));
                if (packs[i].isCompleted)
                {
                    _completeImage[i].gameObject.SetActive(true);
                }
                if (packs[i].isUnlocked)
                {
                    _lockImage[i].gameObject.SetActive(false);
                    _unlockButton[i].gameObject.SetActive(false);
                }
                _selectButton[i].gameObject.SetActive(true);
            }
        }

    }
}