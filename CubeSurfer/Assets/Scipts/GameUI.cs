using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform EndLine;
    [SerializeField] Slider slider;
    



    float maxDistance;


    void Start()
    {
        maxDistance = getDistance();
        

    }
    void Update()
    {
        
        if (Player.position.z <= maxDistance && Player.position.z <= EndLine.position.z)
        {
            float distance = 1-(getDistance() / maxDistance);
            SetProgress(distance);

        }
    }
   
    float getDistance()
    {
        return Vector3.Distance(Player.position, EndLine.position);
    }
    void SetProgress(float p)
    {
        slider.value = p;
    }
    public void LevelPass()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
