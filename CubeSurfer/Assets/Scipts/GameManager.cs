using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject SwipeImg;
    void Start()
    {
        SwipeImg.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SwipeImg.SetActive(false);


            Time.timeScale = 1.0f;
        }
    }
}
