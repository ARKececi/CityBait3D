using UnityEngine;

namespace SpawnerSystem.Root
{
    public abstract class SpawnerSystem : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] protected Spawner spawner;

        #endregion

        #endregion

        private void OnValidate()
        {
            spawner = transform.GetComponentInParent<Spawner>();
        }
    }
}