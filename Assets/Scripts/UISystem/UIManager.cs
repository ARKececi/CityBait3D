using UnityEngine;
using UnityEngine.UI;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image aimImage;
    private void Update()
    {
        SetAimImageTransform();
    }

    private void SetAimImageTransform()
    {
        aimImage.transform.position = Input.mousePosition;
    }
}
