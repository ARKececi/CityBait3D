using System;
using System.Collections.Generic;
using LevelSystem.Signal;
using PaintIn3D;
using SaveSystem.SaveManager.Signals;
using SpawnerSystem.SpawnManager.Signals;
using TMPro;
using UISystem.UIManager.Controller;
using UISystem.UIManager.Data.ValueObject;
using UISystem.UIManager.Enum;
using UISystem.UIManager.Signals;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using WeaponsSystem.WeaponManager.Signals;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

public class UIManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private UIController uıController;
    [SerializeField] private P3dChannelCounterText p3dChannelCounterText;
    [SerializeField] private SerializedDictionary<TextType, PriceData> price = new SerializedDictionary<TextType, PriceData>();

    #endregion

    #region Private Variables

    private Dictionary<TextType, PriceData> dictionaryPrice;

    #endregion

    #endregion

    private void Awake()
    {
        if (GetActivePriceDatas() != null)
        {
            dictionaryPrice = GetActivePriceDatas();
            foreach (var Keys in dictionaryPrice.Keys)
            {
                int buttonPrice = dictionaryPrice[Keys].Price * dictionaryPrice[Keys].Multiplier;
                uıController.TextChange(Keys,buttonPrice);
                price[Keys].Price = dictionaryPrice[Keys].Price;
                price[Keys].Multiplier = dictionaryPrice[Keys].Multiplier;
            }
        }
        else
        {
            foreach (var Keys in price.Keys)
            {
                int buttonPrice = price[Keys].Price * price[Keys].Multiplier;
                uıController.TextChange(Keys,buttonPrice);
            }
        }
    }

    #region Event Subscription

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        UISignals.Instance.onSetAimImageTransform += OnSetAimImageTransform;
        UISignals.Instance.onTextChange += OnTextChange;
        UISignals.Instance.onOpenPanel += OnOpenPanel;
        UISignals.Instance.onClosePanel += OnClosePanel;
        UISignals.Instance.onNextLevelButton += OnNextLevelButton;
    }

    private void UnsubscribeEvents()
    {
        UISignals.Instance.onSetAimImageTransform -= OnSetAimImageTransform;
        UISignals.Instance.onTextChange -= OnTextChange;
        UISignals.Instance.onOpenPanel -= OnOpenPanel;
        UISignals.Instance.onClosePanel -= OnClosePanel;
        UISignals.Instance.onNextLevelButton -= OnNextLevelButton;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
        
    #endregion
    
    private Dictionary<TextType, PriceData> GetActivePriceDatas()
    {
        if (!ES3.FileExists()) return null;
        return ES3.KeyExists("PriceDatas") ? ES3.Load<Dictionary<TextType, PriceData>>("PriceDatas") : null;
    }
    
    private void OnOpenPanel(TextType panel)
    {
        uıController.OpenPanel(panel);
    }

    private void OnClosePanel(TextType panel)
    {
        uıController.ClosePanel(panel);
    }

    public void Walkers()
    {
        var buttonPrice = price[TextType.Walkers];
        int priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
        if ((bool)ScoreSignals.Instance.onBuy?.Invoke(priceBuy))
        {
            SpawnSignals.Instance.onEnemyCountIncrease?.Invoke();
            buttonPrice.Multiplier++;
            priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
            uıController.TextChange(TextType.Walkers,priceBuy);
            SaveSignals.Instance.onButtonSave?.Invoke(price);
        }
    }

    public void WeaponLevelUp()
    {
        var buttonPrice = price[TextType.FireRate];
        int priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
        if ((bool)ScoreSignals.Instance.onBuy?.Invoke(priceBuy))
        {
            WeaponsSignals.Instance.onWeaponLevelUp?.Invoke();
            buttonPrice.Multiplier++;
            priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
            uıController.TextChange(TextType.FireRate,priceBuy);
            SaveSignals.Instance.onButtonSave?.Invoke(price);
        }
    }

    public void AmmoAmount()
    {
        var buttonPrice = price[TextType.Ammo];
        int priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
        if ((bool)ScoreSignals.Instance.onBuy?.Invoke(priceBuy))
        {
            WeaponSignals.Instance.onMagazineAmount?.Invoke();
            buttonPrice.Multiplier++;
            priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
            uıController.TextChange(TextType.Ammo,priceBuy);
            SaveSignals.Instance.onButtonSave?.Invoke(price);
        }
    }

    public void Income()
    {
        var buttonPrice = price[TextType.Income];
        int priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
        if ((bool)ScoreSignals.Instance.onBuy?.Invoke(priceBuy))
        {
            ScoreSignals.Instance.onIncomeAmount?.Invoke();
            buttonPrice.Multiplier++;
            priceBuy = buttonPrice.Price * buttonPrice.Multiplier;
            uıController.TextChange(TextType.Income,priceBuy);
            SaveSignals.Instance.onButtonSave?.Invoke(price);
        }
    }
    
    private void OnSetAimImageTransform(Vector3 mousePosition)
    {
        uıController.SetAimImageTransform(mousePosition);
    }

    public void OnTextChange(TextType textType, int count)
    {
        uıController.TextChange(textType,count);
    }

    public void OnNextLevelButton()
    {
        float percent = p3dChannelCounterText.Percent();
        if (percent > 70) uıController.OpenPanel(TextType.NextLevel);
    }

    public void OnNextLevel()
    {
        LevelSignals.Instance.onNextLevel?.Invoke();
        uıController.ClosePanel(TextType.NextLevel);
    }
}
