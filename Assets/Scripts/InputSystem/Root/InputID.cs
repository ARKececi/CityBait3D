using UnityEngine;

namespace InputSystem.Root
{
    [CreateAssetMenu(fileName = "InputID", menuName = "IDMenu/InputID", order = 0)]
    public class InputID : ScriptableObject
    {
        public InputLocalSignals InputLocalSignals;
    }
}