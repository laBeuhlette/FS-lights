using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageObject : MonoBehaviour
{

    public saut leS;
    public camRotate camR;

    public Camera cam;

    private Vector3 mousePosition;

    public GameObject[] mesObjets;


    private GameObject target;
    private int managerMode;

    public GameObject sphere;

    public GameObject torch;
    private float ratioSensi;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        mesObjets = GameObject.FindGameObjectsWithTag("Objets");
        foreach (GameObject Obj in mesObjets)
        {
            Obj.SetActive(false); 
        }
        

        managerMode = 1;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        // r�cup�ration de la position de la souris
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(target != null)
        {
            ratioSensi = Vector3.Distance(target.transform.position, torch.transform.position) / 25;
        }
        else
        {
            ratioSensi = 1;
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Objets")
                {
                    //Debug.Log("l'objet touch� :" + hit.transform);
                    if (target != null)
                    {
                        if(target.transform.tag == "cam")
                        {
                            target.GetComponent<camRotate>().canMove = false;
                        }
                        else
                            target.GetComponent<saut>().canMove = false;
                    }
                    

                    target = hit.transform.gameObject;

                    target.GetComponent<saut>().canMove = true;
                    target.GetComponent<saut>().mode = managerMode;
                }
                

                
            }

            if (target.transform.tag == "Objets")
            {
                target.GetComponent<saut>().sensi = ratioSensi;
            }
        }

        //Debug.Log(  (Vector3.Distance(target.transform.position, torch.transform.position)) / 25  );
    }

    public void changeMode()
    {

        if (managerMode <= 2)
        {
            managerMode++;
        }
        else
        {
            managerMode = 1;
        }
        target.GetComponent<saut>().mode = managerMode;
    }

    public void setToPosition()
    {
        managerMode = 1;
        target.GetComponent<saut>().mode = managerMode;
    }

    public void setToProfondeur()
    {
        managerMode = 2;
        target.GetComponent<saut>().mode = managerMode;
    }

    public void setToRotation()
    {
        managerMode = 3;
        target.GetComponent<saut>().mode = managerMode;
    }

    public void toCam()
    {
        if(target != null)
            target.GetComponent<saut>().canMove = false;

        target = sphere;
        target.GetComponent<camRotate>().canMove = true;

        foreach (GameObject Obj in mesObjets)
        {
            if (!Obj.active)
                Obj.SetActive(true); 
        }
    }


}
