using SpawnerSystem.SpawnManager.Signals;
using UISystem.UIManager.Controller;
using UISystem.UIManager.Signals;
using UnityEngine;
using UnityEngine.UI;
using WeaponsSystem.WeaponManager.Signals;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

public class UIManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private UIController uıController;

    #endregion

    #endregion

    #region Event Subscription

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        UISignals.Instance.onSetAimImageTransform += OnSetAimImageTransform;
    }

    private void UnsubscribeEvents()
    {
        UISignals.Instance.onSetAimImageTransform -= OnSetAimImageTransform;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
        
    #endregion
    
    private void OnSetAimImageTransform(Vector3 mousePosition)
    {
        uıController.SetAimImageTransform(mousePosition);
    }

    public void Walkers()
    {
        SpawnSignals.Instance.onEnemyCountIncrease?.Invoke();
    }

    public void WeaponLevelUp()
    {
        WeaponsSignals.Instance.onWeaponLevelUp?.Invoke();
    }

    public void AmmoAmount()
    {
        
    }
}
