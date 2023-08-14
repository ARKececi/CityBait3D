using System;
using System.Collections.Generic;
using SpawnerSystem.PoolManager.Controller.Interface;
using UnityEngine;

namespace SpawnerSystem.PoolManager.Data.ValueObject
{
    [Serializable]
    public class PoolChange
    {
        public List<GameObject> Pool = new List<GameObject>();
        public List<GameObject> Use = new List<GameObject>();
    }
}