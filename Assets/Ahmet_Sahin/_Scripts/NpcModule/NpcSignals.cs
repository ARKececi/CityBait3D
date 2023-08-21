using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extentions;
using System;

public class NpcSignals : MonoSingleton<NpcSignals>
{
    public Action onNpcHit = delegate { };
}
