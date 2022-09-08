using TMPro;
using TriviaGame.Gameplay.GameFlow;
using TriviaGame.Global.Database;
using TriviaGame.Global.Save;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Gameplay.Quiz
{
    public class QuizManager : MonoBehaviour
    {
        [SerializeField] private GameFlowManager _gameFlow;
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private Image _hintImage;
        [SerializeField] private Button[] _answerButton;
        [SerializeField] private TextMeshProUGUI[] _answerText;

        private DatabaseController _database;
        private SaveData _saveData;
        private LevelStruct _activeLevel;

        private void Awake()
        {
            _saveData = SaveData.saveInstance;
            _database = DatabaseController.databaseInstance;
            SetActiveLevel();
            InitQuiz(_activeLevel);
        }


        private void SetActiveLevel()
        {
            for (int i = 0; i < _database.levels.Length; i++)
            {
                if (_database.levels[i].levelID == _saveData.selectedLevel)
                {
                    _activeLevel = _database.levels[i];
                    return;
                }
            }
        }

        private void InitQuiz(LevelStruct level)
        {
            _questionText.text = level.question;
            _hintImage.sprite = Resources.Load<Sprite>("Image/" + level.hint);
            for (int i = 0; i < level.choice.Length; i++)
            {
                int tempIndex = i;
                _answerText[i].text = level.choice[i];
                _answerButton[i].onClick.AddListener(() => _gameFlow.AnswerQuestion(tempIndex, level.answer, level.levelID));
                _answerButton[i].gameObject.SetActive(true);
            }
        }
    }
}

