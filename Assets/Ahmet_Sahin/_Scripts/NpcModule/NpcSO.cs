using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NpcData", menuName = "ScriptableObjects/NpcSO", order = 0)]
public class NpcSO : ScriptableObject
{
    public NpcEvents npcEvents;
}
