using UnityEngine;
using UnityEngine.Serialization;

namespace WeaponsSystem.Root
{
    public abstract class WeaponsSystem : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] protected Weapons weapons;

        #endregion

        #endregion
        
        private void OnValidate()
        {
            weapons = transform.GetComponentInParent<Weapons>();
        }
    }
}