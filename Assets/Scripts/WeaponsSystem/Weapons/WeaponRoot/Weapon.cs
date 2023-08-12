using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;

namespace WeaponsSystem.Weapons.WeaponRoot
{
    public abstract class Weapon : MonoBehaviour
    {
        protected GameObject barrel { get; set; }
        private const int force = 20;

        protected void Fire()
        {
            IPoolable bullet = SpawnSignals.Instance.onBulletSpawner?.Invoke();
            bullet.Transform.position = barrel.transform.position;
            bullet?.IRigidbody.AddForce(barrel.transform.forward * force, ForceMode.Impulse);
        }
    }
}