using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahmet
{
    public class Npc : MonoBehaviour
    {
        public NpcSO npcSO;
        private Material _material;

        private void Awake()
        {
            _material = GetComponentInChildren<SkinnedMeshRenderer>().material;
            _material.color = npcSO.color;
        }
    }
}