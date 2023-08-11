using System;
using Extentions;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.PoolManager.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace SpawnerSystem.PoolManager.Signals
{
    public class PoolSignals : MonoSingleton<PoolSignals>
    {
        public UnityAction<IPoolable,PoolType> onListAdd = delegate {  };
        public Func<PoolType,IPoolable> onListRemove = delegate { return null;};
    }
}