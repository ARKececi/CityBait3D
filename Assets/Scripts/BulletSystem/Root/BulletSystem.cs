using UnityEngine;

namespace BulletSystem.Root
{
    public class BulletSystem : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] protected BulletExtends bulletExtends;

        #endregion

        #endregion

        private void OnValidate()
        {
            bulletExtends = transform.GetComponentInParent<BulletExtends>();
        }
    }
}