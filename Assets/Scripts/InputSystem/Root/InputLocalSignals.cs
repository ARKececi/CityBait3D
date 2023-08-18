using System;
using InputSystem.Struct;
using Unity.VisualScripting;

namespace InputSystem.Root
{
    public struct InputLocalSignals
    {
        //InputManager to PlayerManager
        public Action<InputParams> onInputParams;
        public Action<bool> onClick;
    }
}