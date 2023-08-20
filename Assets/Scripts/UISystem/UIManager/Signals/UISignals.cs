using Extentions;
using UISystem.UIManager.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace UISystem.UIManager.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<Vector3> onSetAimImageTransform = delegate { };
        public UnityAction<TextType,int> onTextChange = delegate { };
    }
}