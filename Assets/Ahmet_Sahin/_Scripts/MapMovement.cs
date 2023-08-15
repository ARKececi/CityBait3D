using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        gameObject.transform.Rotate(0f, _rotateSpeed, 0f);
        
    }
}
