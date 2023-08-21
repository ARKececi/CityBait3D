using Extentions;
using SaveSystem.SaveManager.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace SaveSystem.SaveManager.Signals
{
    public class SaveSignals : MonoSingleton<SaveSignals>
    {
        public UnityAction<SaveType,int> onSave = delegate {  };
    }
}