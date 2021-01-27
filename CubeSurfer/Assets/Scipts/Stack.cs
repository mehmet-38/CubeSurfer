using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stack : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource Coin;
    
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject FinishPanel;
    [SerializeField] GameObject Gamer;
    [SerializeField] Text diamondText;

    //Cube 
    public GameObject generateCube;
    [HideInInspector]
    public List<GameObject> cubes = new List<GameObject>();
    public Material[] Materials;
    [HideInInspector]
    public Material cubeMaterial;
    private Material toggleMaterial;
    int sayac = 0;
    void Awake()
    {
        listOfChildCubes();
        cubes[0].GetComponent<MeshRenderer>().material = Materials[0];

        cubeMaterial = cubes[0].GetComponent<MeshRenderer>().material;
    }
 
    private void OnTriggerEnter(Collider other)
    {

        cubeMaterial = cubes[0].GetComponent<MeshRenderer>().material;
        // Cube Material karşılaştırma
        if (cubeMaterial.name.ToString() == other.GetComponent<MeshRenderer>().material.name.ToString())
        {
            toggleMaterial = cubes[0].GetComponent<MeshRenderer>().material;
            Destroy(other.gameObject);
            listOfChildCubes();
            if (other.tag == "PickCube" && other.tag != "Diamond")
            {
                audio.Play();
                if (cubes[cubes.Count - 1].tag == "PickCube")
                {

                    GameObject newCube = Instantiate(generateCube, new Vector3(transform.position.x, cubes[cubes.Count - 1].transform.position.y + 1f, transform.position.z), Quaternion.Euler(0, 0, 0));

                    newCube.transform.parent = gameObject.transform;
                    newCube.GetComponent<MeshRenderer>().material = cubeMaterial;
                    newCube.layer = LayerMask.NameToLayer("layer2");

                    Gamer.transform.position = new Vector3(transform.position.x, cubes[cubes.Count - 1].transform.position.y + 1.5f, transform.position.z);
                    listOfChildCubes();


                }

            }



        }

        else
        {

            listOfChildCubes();

            if (cubes[1].tag == "PickCube" && other.tag != "Diamond" && other.tag != "finish")
            {

                audio.Play();
                cubes[1].transform.parent = null;

                other.gameObject.GetComponent<MeshRenderer>().material = cubeMaterial;
                other.gameObject.transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y, transform.position.z - 1.3f);

                Destroy(cubes[1]);

                listOfChildCubes();
                for (int i = 1; i < cubes.Count; i++)
                {
                    cubes[i].transform.position = new Vector3(cubes[i].transform.position.x, cubes[i].transform.position.y - 1f, cubes[i].transform.position.z);
                    Gamer.transform.position = new Vector3(transform.position.x, cubes[i].transform.position.y + 0.5f, transform.position.z);
                }
                if (cubes.Count == 1)
                {
                    LosePanel.SetActive(true);
                    Time.timeScale = 0.0f;
                }

            }
            else if (other.tag == "Diamond")
            {


                sayac += 1;
                diamondText.text = sayac.ToString();
                Destroy(other.gameObject);

                Coin.Play();



            }
            else if (other.tag == "finish")
            {
                FinishPanel.SetActive(true);
                Time.timeScale = 0.0f;

            }


        }


    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    
    private void listOfChildCubes()
    {
        cubes.Clear();

        foreach (Transform child in transform)
        {
            cubes.Add(child.gameObject);
        }
        for (int i = 2; i < cubes.Count; i++)
        {
            cubes[i].GetComponent<BoxCollider>().isTrigger = false;
        }

        if (cubes.Count > 1)
            cubes[1].GetComponent<BoxCollider>().enabled = true;
    }
}

