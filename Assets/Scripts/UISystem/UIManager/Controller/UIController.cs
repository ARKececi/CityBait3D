using TMPro;
using UISystem.UIManager.Enum;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace UISystem.UIManager.Controller
{
    public class UIController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private SerializedDictionary<TextType, TextMeshProUGUI> texts = new SerializedDictionary<TextType, TextMeshProUGUI>();
        [SerializeField] private Image aimImage;

        #endregion

        #endregion
        
        public void SetAimImageTransform(Vector3 mousePosition)
        {
            aimImage.transform.position = mousePosition;
        }
        
        public void TextChange(TextType textType, int count)
        {
            switch (textType)
            {
                case TextType.Bullet:
                    texts[textType].text = count.ToString();
                    break;
                case TextType.Ammo:
                    texts[textType].text = count.ToString();
                    break;
                case TextType.Walkers:
                    texts[textType].text = count.ToString();
                    break;
                case TextType.Income:
                    texts[textType].text = count.ToString();
                    break;
                case TextType.Money:
                    texts[textType].text = count.ToString();
                    break;
                case TextType.FireRate:
                    texts[textType].text = count.ToString();
                    break;
            }
        }
    }
}