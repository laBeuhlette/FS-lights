using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class manageObject : MonoBehaviour
{

    public saut leS;
    public camRotate camR;

    public Camera cam;

    private Vector3 mousePosition;

    public GameObject[] mesObjets;


    public GameObject target;
    private int managerMode;

    public GameObject sphere;

    public GameObject torch;
    private float ratioSensi;

    public GameObject c0;
    public GameObject c0_target;
    public GameObject c1;
    public GameObject c1_target;
    public GameObject c1_sphere;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    

    public GameObject UI;
    public GameObject[] UI_parts;

    private GameObject po;
    private GameObject pr;
    private GameObject ro;
    private GameObject rc;
    private GameObject verif;
    private GameObject cpt;
    private GameObject rz;

    public TextMeshProUGUI tuto;

    public Material Mbase;
    public Material Mselected;

    public GameObject sceneIndic;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        mesObjets = GameObject.FindGameObjectsWithTag("Objets");
        UI_parts = GameObject.FindGameObjectsWithTag("UI_parts");

        foreach (GameObject Obj in mesObjets)
        {
            Obj.SetActive(false);
            
            switch (Obj.name)
            {
                case "cube0":
                    c0 = Obj;
                    break;
                case "cube0_target":
                    c0_target = Obj;
                    Obj.tag = "Ignore";
                    break;
                case "cube1":
                    c1 = Obj;
                    break;
                case "cube1_target":
                    c1_target = Obj;
                    Obj.tag = "Ignore";
                    break;
                case "cube2":
                    c2 = Obj;
                    break;
                case "cube3":
                    c3 = Obj;
                    break;
                case "cube4":
                    c4 = Obj;
                    break;
                case "sphere":
                    c1_sphere = Obj;
                    break;
                default :
                    break;
            }
        }
        
        foreach (GameObject child in UI_parts) {

            child.SetActive(false);

            switch (child.name)
            {
                case "PO":
                    po = child;
                    break;
                case "PR":
                    pr = child;
                    break;
                case "RO":
                    ro = child;
                    break;
                case "RC":
                    rc = child;
                    break;
                case "VERIF":
                    verif = child;
                    break;
                case "cpt":
                    cpt = child;
                    break;
                case "RZ":
                    rz = child;
                    break;
                default :
                    break;
            }
        }

        
        
        switch (sceneIndic.name)
        {
            case "scene 1":
                phase1();
                break;
            case "scene 2":
                phase2_1();
                break;
            case "scene 3":
                break;
            default:
                break;
        }
        
        

        //managerMode = 1;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        // r�cup�ration de la position de la souris
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(target != null)
        {
            ratioSensi = Vector3.Distance(target.transform.position, torch.transform.position) / 100;
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
                            target.GetComponent<MeshRenderer> ().material = Mbase;
                    }
                    

                    target = hit.transform.gameObject;

                    target.GetComponent<saut>().canMove = true;
                    target.GetComponent<MeshRenderer> ().material = Mselected;
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

        /*foreach (GameObject Obj in mesObjets)
        {
            if (!Obj.active)
                Obj.SetActive(true); 
        }*/
    }

    public void resetObject()
    {
        if (target.tag == "Objets")
        target.GetComponent<saut>().reset();
    }


    // PHASES
    public void phase1()
    {
        // Manager en mode profondeur
        Debug.Log("phase 1");
        managerMode = 2;
        
        // activation bloc ref et sa target
        c0.SetActive(true);
        c0.GetComponent<MeshRenderer> ().material = Mselected;
        target = c0;
        

        c0_target.SetActive(true); 


        pr.SetActive(true);

        /*tempUi = UI.Find("PO");
        tempUi.SetActive(false);
        */

        //tuto.SetActive(true);
        tuto.SetText("Slide the bloc to his target");
    }

    public void phase2()
    {
        Debug.Log("phase 2");
        managerMode = 1;

        c0.tag = "Ignore" ;
        target.GetComponent<saut>().canMove = false;
        c0.GetComponent<MeshRenderer> ().material = Mbase;
        
        c1.SetActive(true);
        target = c1;
        c1.GetComponent<MeshRenderer> ().material = Mselected;

        c1_target.SetActive(true);
        c1_sphere.SetActive(true);
        
        c0_target.SetActive(false);

        pr.SetActive(false);
        
        po.SetActive(true);

        tuto.SetText("Place the bloc next to his target");
    }

    public void phase3()
    {
        Debug.Log("phase 3");
        //toCam();

        c1_target.SetActive(false);
        c1_sphere.SetActive(false);
        c1.tag = "Ignore";
        c1.GetComponent<saut>().canMove = false;
        c1.GetComponent<MeshRenderer> ().material = Mbase;
        target = null;

        c2.SetActive(true);

        po.SetActive(true);
        pr.SetActive(true);
        
        verif.SetActive(true);
        rc.SetActive(true);
        cpt.SetActive(true);
        rz.SetActive(true);
        
        tuto.SetText("you place the last object and press the verif button");
    }

    public void phase2_1()
    {
        Debug.Log("phase 2_1");
        
        managerMode = 3;
        c0.SetActive(true);
        c0_target.SetActive(true);
    }

    public void phase2_2()
    {
        Debug.Log("phase 2_2");
        c0.tag = "Ignore";
        c0_target.SetActive(false);

        c1.SetActive(true);
        c2.SetActive(true);
        c3.SetActive(true);
        c4.SetActive(true);

        po.SetActive(true);
        pr.SetActive(true);
        
        verif.SetActive(true);
        rc.SetActive(true);
        cpt.SetActive(true);
        rz.SetActive(true);

    }

}
