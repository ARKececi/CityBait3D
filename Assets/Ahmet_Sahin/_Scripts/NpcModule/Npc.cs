using System;
using System.Collections;
using System.Collections.Generic;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ahmet
{
    public class Npc : MonoBehaviour
    {

        public NpcSO npcSO;
        private Material _material;
        public Color Color;

        private void OnEnable()
        {
            npcSO.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0,1f));
            _material = GetComponentInChildren<SkinnedMeshRenderer>().material;
            _material.color = npcSO.color;
            Color = npcSO.color;
        }

        private void OnDisable()
        {
            SpawnSignals.Instance.onEnemyCountReduction?.Invoke();
        }
    }
}