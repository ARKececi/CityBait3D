using System;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using WeaponsSystem.WeaponManager.Controller;
using WeaponsSystem.WeaponManager.Signals;

namespace WeaponsSystem.WeaponManager
{
    public class WeaponsManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private WeaponsController weaponsController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            WeaponsSignals.Instance.onWeaponLevelUp += OnWeaponLevelUp;
        }

        private void UnsubscribeEvents()
        {
            WeaponsSignals.Instance.onWeaponLevelUp -= OnWeaponLevelUp;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnWeaponLevelUp()
        {
            weaponsController.WeaponLevelUp();
        }

    }
}