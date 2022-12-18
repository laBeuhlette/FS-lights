using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotate : MonoBehaviour
{

    public Vector3 mousePosition;

    public bool canMove;

    private float oldPositionX;
    private bool following;


    // Start is called before the first frame update
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        oldPositionX = mousePosition.x;
    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (Input.GetMouseButtonDown(0))
        {
            following = true;
            oldPositionX = mousePosition.x;    
        }
        if (Input.GetMouseButtonUp(0))
        {
            following = false;
        }

        if (following && canMove)
        {
            transform.Rotate(new Vector3(0f,  (oldPositionX - mousePosition.x) * 1.5f , 0f), Space.World);
        }
        oldPositionX = mousePosition.x;
    }
}
