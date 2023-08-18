using System;
using InputSystem.Struct;
using UISystem.UIManager.Signals;
using UnityEngine;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

namespace InputSystem.PlayerManager
{
    public class PlayerManager : Root.InputSystem
    {
        #region Self Variables

        #region Private Variables

        private InputParams _inputParams;
        private bool _click;

        #endregion

        #endregion

        private void OnEnable()
        {
            inputS.InputID.InputLocalSignals.onInputParams += MousePosition;
            inputS.InputID.InputLocalSignals.onClick += Click;
        }

        private void OnDisable()
        {
            inputS.InputID.InputLocalSignals.onInputParams -= MousePosition;
            inputS.InputID.InputLocalSignals.onClick -= Click;
        }

        private void MousePosition(InputParams inInputParams)
        {
            _inputParams = inInputParams;
        }
        
        private void Click(bool click)
        {
            _click = click;
        }

        private void FixedUpdate()
        {
            if (_click)
            {
                Move();
            }
        }

        private void Move()
        {
            UISignals.Instance.onSetAimImageTransform?.Invoke(_inputParams.MousePositions);
            WeaponSignals.Instance.onAimPosition?.Invoke(_inputParams.HitPosition);
        }
        
    }
}