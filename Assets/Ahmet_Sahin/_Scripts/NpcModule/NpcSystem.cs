using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NpcSystem : MonoBehaviour
{
    protected Npc npc;

    protected virtual void Awake()
    {
        npc = transform.root.GetComponent<Npc>();
    }
}
