using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;


public class saut : MonoBehaviour
{

    public Vector3 mousePosition;
    
    private bool following;

    private float oldPositionX;
    private float oldPositionY;

    public int mode; 

    public Transform myTransform;

    private Vector3 memoryPosition;
    private Quaternion memoryRotation;

    public Camera cam;

    private Vector3 targetMove;

    public bool canMove;


    //public Vector3 pos = new Vector3 (10f, 10f, 10f);

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        following = false;

        // sauvegarde de position d'origine 
        memoryPosition = transform.position;
        memoryRotation = transform.rotation;


        // initialisation de position de la souris
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        oldPositionX = mousePosition.x;
        oldPositionY = mousePosition.y;

        mode = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;

        // récupération de la position de la souris
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        


        // ///////////////////////Détection de clic/////////////////
        if (Input.GetMouseButtonDown(0))
        {
            following = true;
            oldPositionX = mousePosition.x;
            oldPositionY = mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
        {
            following = false;
        }

        if (canMove)
        {
            #region Babar

            //---------------------------------------//
            //           jyhezsdgfckdshsedg          //
            //---------------------------------------//


            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-


            // ///////////////////////   -Déplacements-   /////////////////
            if (following)
            {
                // //////////////// * PositionSurPlan * ////////////////////
                if (mode == 1)
                {
                    transform.position += new Vector3(0f, mousePosition.y - oldPositionY, 0f);

                    Vector3 _moveVector = new Vector3(mousePosition.x - oldPositionX, 0f, 0f);

                    _moveVector = cam.transform.rotation * _moveVector;

                    _moveVector.z = 0f;

                    transform.position -= _moveVector;


                    //targetMove = cam.transform.position - transform.position;               // Mon beau commentaire
                    // Blabla bla kzjhezrkiuhgrelgesurgerljglrejhgrlddjh
                    // shdvgkbfsdqklrjhbvs:dkjsmkjddsg

                    //transform.position += targetMove.normalized * (oldPositionY - mousePosition.y);




                }
                // ////////////////Hauteur////////////////////
                else if (mode == 2)
                {
                    Vector3 _moveVector = new Vector3(0f, 0f, oldPositionY - mousePosition.y);

                    _moveVector = cam.transform.rotation * _moveVector;

                    _moveVector.x = 0f;
                    _moveVector.y = 0f;

                    transform.position -= _moveVector;

                    //transform.position += new Vector3(0f, mousePosition.y - oldPositionY, 0f);
                }
                // ////////////////Rotation////////////////////
                else if (mode == 3)
                {
                    transform.Rotate(new Vector3(2 * (oldPositionY - mousePosition.y), 2 * (mousePosition.x - oldPositionX), 0f), Space.World);
                }


            }

            // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

            #endregion
        }


        // ///////////////////////Suivi de position/////////////////
        oldPositionX = mousePosition.x;
        oldPositionY = mousePosition.y;

        // ////////////////Reset////////////////////
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset appliqué au mode de contrôle en cours (déplacement / rotation)
            if (mode <= 2)
            {
                transform.position = memoryPosition;
            }
            else
            {
                transform.rotation = memoryRotation;
            }
        }


        


    }

    void FixedUpdate()
    {
        
        
    }

    public void changeMode()
    {
        Debug.Log("patate");

            if (mode <= 2)
            {
                mode++;
            }
            else
            {
                mode = 1;
            }
        
    }
}
