using System;
using UnityEngine;

namespace BulletSystem.Root
{
    public struct BulletLocalSignals
    {
        public Action<Color, Vector3> PaintNpc;
        public Action<Vector3> PaintPlane;
    }
}