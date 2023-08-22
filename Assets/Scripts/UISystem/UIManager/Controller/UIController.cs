using System;
using System.Collections.Generic;
using TMPro;
using UISystem.UIManager.Data.ValueObject;
using UISystem.UIManager.Enum;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UISystem.UIManager.Controller
{
    public class UIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public SerializedDictionary<TextType, UIData> panels = new SerializedDictionary<TextType, UIData>();

        #endregion

        #region Serialized Variables
        
        [SerializeField] private Image aimImage;

        #endregion

        #endregion

        public void OpenPanel(TextType textType )
        {
            panels[textType].TextObject.SetActive(true);
        }

        public void ClosePanel(TextType textType)
        {
            panels[textType].TextObject.SetActive(false);
        }
        
        public void SetAimImageTransform(Vector3 mousePosition)
        {
            aimImage.transform.position = mousePosition;
        }
        
        public void TextChange(TextType textType, int count)
        {
            switch (textType)
            {
                case TextType.Bullet:
                    panels[textType].TextMeshProUGUI.text = count.ToString();
                    break;
                case TextType.Ammo:
                    panels[textType].TextMeshProUGUI.text = "Ammo\n$" + count;
                    break;
                case TextType.Walkers:
                    panels[textType].TextMeshProUGUI.text = "Walkers\n$" + count;
                    break;
                case TextType.Income:
                    panels[textType].TextMeshProUGUI.text = "Income\n$" + count;
                    break;
                case TextType.Money:
                    panels[textType].TextMeshProUGUI.text = count.ToString();
                    break;
                case TextType.FireRate:
                    panels[textType].TextMeshProUGUI.text =  "FireRate\n$" + count;
                    break;
            }
        }
    }
}