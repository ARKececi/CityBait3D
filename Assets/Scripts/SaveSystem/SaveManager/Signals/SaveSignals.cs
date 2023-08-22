using System.Collections.Generic;
using Extentions;
using SaveSystem.SaveManager.Enum;
using UISystem.UIManager.Data.ValueObject;
using UISystem.UIManager.Enum;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace SaveSystem.SaveManager.Signals
{
    public class SaveSignals : MonoSingleton<SaveSignals>
    {
        public UnityAction<SaveType,int> onSave = delegate { };
        public UnityAction<GameObject> onMapSave = delegate { };
        public UnityAction<SerializedDictionary<TextType, PriceData>> onButtonSave = delegate { };
    }
}