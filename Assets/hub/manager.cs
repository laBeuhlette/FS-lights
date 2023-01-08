using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public Camera cam;
    private Vector3 mousePosition;
    private GameObject target;

    public string Level1;
    public string Level2;

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
                    LoadLvl1();
                }
                if (hit.transform.tag == "Lvl2")
                {
                    Debug.Log("lancement niveau 2");
                    LoadLvl2();
                }

                
            }
        }

        

    }

    void LoadLvl1()
    {
        SceneManager.LoadScene(Level1);
    }

    void LoadLvl2()
    {
        SceneManager.LoadScene(Level2);
    }
    
}
