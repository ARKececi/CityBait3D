using SaveSystem.SaveManager.Enum;
using SaveSystem.SaveManager.Signals;
using SpawnerSystem.PoolManager.Enum;
using UnityEngine;

namespace SaveSystem.SaveManager
{
    public class SaveManager : MonoBehaviour
    {
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SaveSignals.Instance.onSave += OnSave;
        }

        private void UnsubscribeEvents()
        {
            SaveSignals.Instance.onSave -= OnSave;
        }

        private void OnDisable()    
        {
            UnsubscribeEvents();
        }
        #endregion

        private void OnSave(SaveType SaveType,int SaveCount)
        {
            switch (SaveType)
            {
                case SaveType.Money:
                    MoneySave(SaveCount);
                    break;
                case SaveType.Income:
                    IncomeSave(SaveCount);
                    break;
                case SaveType.Walkers:
                    WalkersSave(SaveCount);
                    break;
                case SaveType.FireRate:
                    FireRateSave(SaveCount);
                    break;
                case SaveType.Ammo:
                    AmmoSave(SaveCount);
                    break;
                case SaveType.Level:
                    LevelSave(SaveCount);
                    break;
            }
        }

        private void MoneySave(int moneyCount) { ES3.Save("MoneyCount", moneyCount); }

        private void IncomeSave(int incomeCount) { ES3.Save("IncomeCount", incomeCount); }

        private void WalkersSave(int walkerCount) { ES3.Save("WalkerCount", walkerCount); }

        private void FireRateSave(int weaponCount) { ES3.Save("WeaponCount", weaponCount); }

        private void AmmoSave(int magazine) { ES3.Save("Magazine", magazine); }

        private void LevelSave(int level) { ES3.Save("Level", level); }

    }
}