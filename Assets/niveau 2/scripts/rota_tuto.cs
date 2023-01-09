using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rota_tuto : MonoBehaviour
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
        Debug.Log(cube.transform.rotation.y);
        if(cube.transform.rotation.y > -0.1f && cube.transform.rotation.y < 0.1f)
        {
            cube.transform.rotation = myTransform.rotation;
            objectManager.GetComponent<manageObject>().phase2_2();

        }
    }
}
