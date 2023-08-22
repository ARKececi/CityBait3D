using System;
using Extentions;
using System.Collections;
using System.Collections.Generic;
using SaveSystem.SaveManager.Enum;
using SaveSystem.SaveManager.Signals;
using UISystem.UIManager.Enum;
using UISystem.UIManager.Signals;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    #region Self Variables

    #region Private Variables

    private int _money;
    private int _income = 1;

    #endregion

    #endregion

    private void Awake()
    {
        _income = GetActiveIncomeCount();
        _money = GetActiveMoney();
        MoneyTextUpdate();
    }

    #region Event Subscription

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        ScoreSignals.Instance.onNpcHit += OnMoneyUIUpdate;
        ScoreSignals.Instance.onBuy += OnBuy;
        ScoreSignals.Instance.onIncomeAmount += OnIncomeAmount;
    }

    private void UnsubscribeEvents()
    {
        ScoreSignals.Instance.onNpcHit -= OnMoneyUIUpdate;
        ScoreSignals.Instance.onBuy -= OnBuy;
        ScoreSignals.Instance.onIncomeAmount -= OnIncomeAmount;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
        
    #endregion
    
    private int GetActiveIncomeCount()
    {
        if (!ES3.FileExists()) return 1;
        return ES3.KeyExists("IncomeCount") ? ES3.Load<int>("IncomeCount") : 1;
    }
    
    private int GetActiveMoney()
    {
        if (!ES3.FileExists()) return 0;
        return ES3.KeyExists("MoneyCount") ? ES3.Load<int>("MoneyCount") : 0;
    }

    private void MoneyTextUpdate()
    {
        UISignals.Instance.onTextChange?.Invoke(TextType.Money, _money);
    }

    private void IncreaseMoney()
    {
        _money += _income;
        SaveSignals.Instance.onSave?.Invoke(SaveType.Money, _money);
    }

    private void OnMoneyUIUpdate()
    {
        IncreaseMoney();
        MoneyTextUpdate();
    }

    private void OnIncomeAmount()
    {
        _income++;
        SaveSignals.Instance.onSave?.Invoke(SaveType.Income, _income);
    }

    private bool OnBuy(int much)
    {
        if (_money >= much)
        {
            _money -= much;
            MoneyTextUpdate();
            return true;
        }
        else
        {
            return false;
        }
    }
}
