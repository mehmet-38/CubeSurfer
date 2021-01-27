using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    float setZ;
    void Start()
    {
        setZ = transform.position.z - playerTarget.position.z;
    }

    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerTarget.position.z + setZ);
    }
}
