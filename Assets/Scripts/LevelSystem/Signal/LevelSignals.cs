using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace LevelSystem.Signal
{
    public class LevelSignals : MonoSingleton<LevelSignals>
    {
        public UnityAction onNextLevel = delegate { };
    }
}