using System;
using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using InputSystem.Root;
using InputSystem.Struct;
using UISystem.UIManager.Signals;
using UnityEngine;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

namespace Ahmet
{
    public class InputManager : InputSystem.Root.InputSystem
    {

        #region Self Variables

        #region Private Variables

        private Vector3 _mousePosition;
        private Vector3 _hitPosition;
        private bool _click;

        #endregion

        #endregion
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) Click(true);
            
            else if (Input.GetMouseButtonUp(0)) Click(false);
            
            
            if (Input.GetMouseButton(0))
            {
                UISignals.Instance.onSetAimImageTransform?.Invoke(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    MousePosition(Input.mousePosition,hit.point);
                    //WeaponSignals.Instance.onAimPosition?.Invoke(hit.point);
                }
            }
        }

        private void Click(bool click)
        {
            _click = click;
            inputS.InputID.InputLocalSignals.onClick?.Invoke(_click);
        }

        private void MousePosition(Vector3 mousePosition , Vector3 hitPosition)
        {
            _mousePosition = mousePosition;
            _hitPosition = hitPosition;
            inputS.InputID.InputLocalSignals.onInputParams?.Invoke(new InputParams()
            {
                HitPosition = _hitPosition,
                MousePositions = _mousePosition
            });
        }
    }
}