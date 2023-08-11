using System;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.PoolManager.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace SpawnerSystem.Root
{
    public struct SpawnerLocalSignals
    {
        // PoolController to  PoolManager and SpawnController
        public Action<IPoolable, PoolType> onListAdd;
        public Func<PoolType,IPoolable> onListRemove;
        
        //SpawnController to SpawnManager
        public Action<float,GameObject> weaponProperty;
    }
}