using Extentions;
using System.Collections;
using System.Collections.Generic;
using UISystem.UIManager.Enum;
using UISystem.UIManager.Signals;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private int _money;
    private int _income = 1;

    private void MoneyTextUpdate()
    {
        UISignals.Instance.onTextChange?.Invoke(TextType.Money, _money);
    }

    private void IncreaseMoney()
    {
        _money += _income;
    }

    private void MoneyUIUpdate()
    {
        IncreaseMoney();
        MoneyTextUpdate();
    }

    private void OnEnable()
    {
        NpcSignals.Instance.onNpcHit += MoneyUIUpdate;
    }

    private void OnDisable()
    {
        NpcSignals.Instance.onNpcHit -= MoneyUIUpdate;
    }
}
