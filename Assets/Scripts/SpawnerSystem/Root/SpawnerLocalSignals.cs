using System;
using SpawnerSystem.PoolManager.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace SpawnerSystem.Root
{
    public struct SpawnerLocalSignals
    {
        // PoolController to  PoolManager
        public Action<GameObject, PoolType> onListAdd;
        public Func<PoolType,GameObject> onListRemove;
    }
}