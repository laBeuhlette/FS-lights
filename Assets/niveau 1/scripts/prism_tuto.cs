using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prism_tuto : MonoBehaviour
{
    public Transform myTransform;

    public GameObject cube;

    public GameObject objectManager;
    public manageObject MO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(myTransform.position, cube.transform.position));
        if(Vector3.Distance(myTransform.position, cube.transform.position) < 0.022f)
        {
            objectManager.GetComponent<manageObject>().phase3();
            
        }
    }
}
