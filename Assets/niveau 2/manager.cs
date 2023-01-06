using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public Camera cam;
    private Vector3 mousePosition;
    private GameObject target;

    public string LevelToLoad;

    public GameObject check1;


    public static int avance;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        if (avance > 0)
        {
            check1.SetActive(true);
        }
        else
        {
            check1.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Lvl1")
                {
                    Debug.Log("lancement niveau 1");
                    changeScene();
                }

                
            }
        }

        

    }

    void changeScene()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    
}
