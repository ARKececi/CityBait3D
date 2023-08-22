using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extentions;
using System;
using UnityEngine.Events;

public class ScoreSignals : MonoSingleton<ScoreSignals>
{
    public UnityAction onNpcHit = delegate { };
    public Func<int,bool> onBuy = delegate { return false; };
    public UnityAction onIncomeAmount = delegate { };
}
