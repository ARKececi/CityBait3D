using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace SpawnerSystem.SpawnManager.Signals
{
    public class SpawnSignals : MonoSingleton<SpawnSignals>
    {
        public UnityAction<float, GameObject> onWeaponProperty = delegate {  };
    }
}