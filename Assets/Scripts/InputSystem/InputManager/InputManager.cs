using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UISystem.UIManager.Signals;
using UnityEngine;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

namespace Ahmet
{
    public class InputManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                UISignals.Instance.onSetAimImageTransform?.Invoke(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    WeaponSignals.Instance.onAimPosition?.Invoke(hit.point);
                }
            }
        }
    }
}