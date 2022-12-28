using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void LateUpdate()
    {
        transform.position = new Vector3(0, 0, _target.position.z) ;
    }
}
