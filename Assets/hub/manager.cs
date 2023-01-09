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
    public GameObject check2;

    public GameObject niveau2;

    public GameObject particle1;
    public GameObject particle2;

    public static int avance;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        particle1.SetActive(true);

        particle2.SetActive(false);

        niveau2.GetComponent<BoxCollider>().enabled = false;
        

        if (avance == 1)
        {
            check1.SetActive(true);
            particle1.SetActive(false);
            particle2.SetActive(true);

            check2.SetActive(false);
            niveau2.GetComponent<BoxCollider>().enabled = true;
        }
        else if (avance == 2)
        {
            check2.SetActive(true);
        }
        else
        {
            check1.SetActive(false);
            check2.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(avance);
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
                if (hit.transform.tag == "scene")
                {
                    if(hit.transform.name == "tour narbonaise")
                    {
                        LoadEntracte1();
                    }
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

    void LoadEntracte1()
    {
        SceneManager.LoadScene("entracte 1");
    }
    void LoadEntracte2()
    {
        SceneManager.LoadScene("entracte 2");
    }
    
}
