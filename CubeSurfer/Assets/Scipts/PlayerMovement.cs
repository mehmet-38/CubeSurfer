using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
  
    [SerializeField] float moveSpeed;
    [SerializeField] float slideSpeed;
    private Touch touch;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        rb.velocity = Vector3.forward * moveSpeed;
       
        MoveSwipe();

    }
    void MoveSwipe()
    {
        

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x * slideSpeed,-2.98f,3.89f), transform.position.y, transform.position.z);
            }
        }
        

    }
}

