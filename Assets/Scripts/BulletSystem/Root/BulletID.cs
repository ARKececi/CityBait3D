using UnityEngine;

namespace BulletSystem.Root
{
    [CreateAssetMenu(fileName = "BulletID", menuName = "IDMenu/BulletID", order = 0)]
    public class BulletID : ScriptableObject
    {
        public BulletLocalSignals BulletLocalSignals;
    }
}