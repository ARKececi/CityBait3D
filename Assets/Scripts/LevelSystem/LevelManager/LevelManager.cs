using LevelSystem.LevelManager.Controller;
using LevelSystem.LevelManager.Data;
using LevelSystem.Signal;
using SaveSystem.SaveManager.Enum;
using SaveSystem.SaveManager.Signals;
using SpawnerSystem.PoolManager.Signals;
using UnityEngine;

namespace LevelSystem.LevelManager
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private LevelLoaderController levelLoader;
        [SerializeField] private LevelClearController clearlevel;
        [SerializeField] private GameObject levelHolder;

        #endregion

        #region Private Variables
        
        private int _levelID;

        #endregion

        #endregion
        
        private void Awake()
        {
            _levelID = GetActiveLevel();
            OnLoaderLevel();
        }
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            LevelSignals.Instance.onNextLevel += OnNextLevel;
        }

        private void UnsubscribeEvents()
        {
            LevelSignals.Instance.onNextLevel -= OnNextLevel;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private int GetActiveLevel()
        {
             if (!ES3.FileExists()) return 0;
             return ES3.KeyExists("Level") ? ES3.Load<int>("Level") : 0;
        }
        
        private void OnLoaderLevel()
        {
            _levelID %= Resources.Load<CD_LevelData>("Data/CD_LevelData").LevelCount;
            levelLoader.LoaderLevel(_levelID, levelHolder.transform);
        }
                
        private void OnClearLevel()
        {
            var level = levelHolder.transform.GetChild(0).gameObject;
            clearlevel.ClearLevel(level);
        }

        private void OnNextLevel()
        {
            _levelID++;
            SaveSignals.Instance.onSave?.Invoke(SaveType.Level, _levelID);
            PoolSignals.Instance.onReset?.Invoke();
            OnClearLevel();
            OnLoaderLevel();
        }
    }
}