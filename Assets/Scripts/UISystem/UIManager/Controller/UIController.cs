using UnityEngine;
using UnityEngine.UI;

namespace UISystem.UIManager.Controller
{
    public class UIController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Image aimImage;

        #endregion

        #endregion
        
        public void SetAimImageTransform(Vector3 mousePosition)
        {
            aimImage.transform.position = mousePosition;
        }
    }
}