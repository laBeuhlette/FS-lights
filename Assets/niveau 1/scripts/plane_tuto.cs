using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane_tuto : MonoBehaviour
{
    public GameObject objectManager;
    public manageObject MO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider touched)
    {
        
        if(touched.gameObject.name == "cube0")
        {
            objectManager.GetComponent<manageObject>().phase2();
            //canMove = false;
            //gameObject.tag = "Ignore";
        }

        
        
        
    }
}
