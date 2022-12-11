using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class test : MonoBehaviour
{

    private Vector3 myVector;

    public Transform target;

    public testSO reference;

    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("le cube start");
        meshRenderer = reference.objectMesh;


    }

    // Update is called once per frame
    void Update()
    {
        myVector = (target.position - transform.position);



        RaycastHit hit;


        Debug.DrawRay(transform.position, myVector, Color.green);
        Debug.DrawRay(transform.position, transform.up*10, Color.green);


        if (Physics.Raycast(transform.position, transform.up, out hit, 10))
        {
            Debug.Log(hit.transform.position);
        }
    }
}
