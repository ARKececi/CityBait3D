using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahmet
{
    public abstract class NpcSystem : MonoBehaviour
    {
        [SerializeField] protected Npc npc;

        protected virtual void Awake()
        {
            npc = transform.root.GetComponent<Npc>();
        }
    }
}