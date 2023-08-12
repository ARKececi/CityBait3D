using System;
using Extentions;
using SpawnerSystem.PoolManager.Controller.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace SpawnerSystem.SpawnManager.Signals
{
    public class SpawnSignals : MonoSingleton<SpawnSignals>
    {
        public Func<IPoolable> onBulletSpawner = delegate { return null; };
    }
}