using TriviaGame.Global.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TriviaGame.Pack.PackUnlock
{
    public class PackUnlockController : MonoBehaviour
    {
        private SaveData _saveData;

        private void Awake()
        {
            _saveData = SaveData.saveInstance;
        }

        public void UnlockPack(string packID)
        {
            _saveData.UpdateUnlockedPack(packID);
            SceneManager.LoadScene("Pack");
        }
    }
}

