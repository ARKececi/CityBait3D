using System;
using System.Collections.Generic;
using SpawnerSystem.PoolManager.Controller.Interface;
using UnityEngine;

namespace SpawnerSystem.PoolManager.Data.ValueObject
{
    [Serializable]
    public class PoolChange
    {
        public List<IPoolable> Pool = new List<IPoolable>();
        public List<IPoolable> Use = new List<IPoolable>();
    }
}