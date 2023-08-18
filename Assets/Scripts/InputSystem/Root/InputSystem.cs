using UnityEngine;
using UnityEngine.Serialization;

namespace InputSystem.Root
{
    public abstract class InputSystem : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] protected InputS inputS;

        #endregion

        #endregion

        private void OnValidate()
        {
            inputS = transform.GetComponentInParent<InputS>();
        }
    }
}