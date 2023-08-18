using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahmet
{
    [CreateAssetMenu(fileName = "NpcData", menuName = "IDMenu/NpcSO", order = 0)]
    public class NpcSO : ScriptableObject
    {
        public NpcEvents npcEvents;
        public Color color;
    }
}