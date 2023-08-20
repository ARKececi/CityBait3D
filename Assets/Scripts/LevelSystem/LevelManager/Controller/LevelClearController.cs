using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem.LevelManager.Controller
{
    public class LevelClearController : MonoBehaviour
    {
        public void ClearLevel(GameObject level)
        {
            Destroy(level);
        }
    }
}