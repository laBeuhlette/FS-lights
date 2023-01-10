using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

using UnityEngine.SceneManagement;

public class cast : MonoBehaviour
{

    public string LevelToLoad;

    private Color pix;
    private Color pix2;

    public RenderTexture sourceTex;
    public Texture2D targetTex ;


    public RenderTexture refSourceTex;
    public Texture2D refTargetTex;


    public int commonsPix;
    public int diffPix;

    public List<int> pixTab = new List<int>();
    public List<int> refPixTab = new List<int>();

    public TextMeshProUGUI diff;

    public GameObject sceneIndic;


    // Start is called before the first frame update
    void Start()
    {
        /*RenderTexture.active = myRenderTexture;
        myTexture2D.ReadPixels(new Rect(0, 0, myRenderTexture.width, myRenderTexture.height), 0, 0);
        myTexture2D.Apply();
        Texture2D virtualPhoto = new Texture2D(sqr,sqr, TextureFormat.RGB24, false);
        */
        /*
        RenderTexture.active = sourceTex;

        targetTex = new Texture2D(256, 256, TextureFormat.RGB24, false);

        targetTex.ReadPixels(new Rect(0, 0, sourceTex.width, sourceTex.height), 0, 0);
        targetTex.Apply();
        
        */

        targetTex = new Texture2D(256, 256, TextureFormat.RGB24, false);
        refTargetTex = new Texture2D(256, 256, TextureFormat.RGB24, false);


        commonsPix = 0;
        
        //pixTab.Clear();
        //refPixTab.Clear();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit hit;
         
        if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 10))
        {
                
            Debug.Log(hit.point);
            Debug.DrawRay(transform.position, hit.point- transform.position, Color.green);
        }
        else
            Debug.DrawRay(transform.position, -Vector3.forward * 10, Color.red);
        */

        
        

        
        
    }

    public void verif()
    {
        refPixTab.Clear();
        RenderTexture.active = refSourceTex;
            refTargetTex.ReadPixels(new Rect(0, 0, refSourceTex.width, refSourceTex.height), 0, 0);
            refTargetTex.Apply();

            Color[] refPix = refTargetTex.GetPixels(0, 0, 256, 256);
            for (int i = 0; i< refPix.Length; i ++)
            {
                if (refPix[i].r > 0.5)
                {
                    refPixTab.Add(1);
                }
                else
                {
                    refPixTab.Add(0);
                }
            }


            //////////////////////RENDER TEXTURE JOUEUR///////////////////////////

            pixTab.Clear();
            commonsPix = 0;
            diffPix = 0;

            RenderTexture.active = sourceTex;
            targetTex.ReadPixels(new Rect(0, 0, sourceTex.width, sourceTex.height), 0, 0);
            targetTex.Apply();


            Color[] pix = targetTex.GetPixels(0, 0, 256, 256);
            
            for (int i = 0; i< pix.Length; i ++)
            {
                if (pix[i].r > 0.5)
                {
                    pixTab.Add(1);
                }
                else
                {
                    pixTab.Add(0);
                }
            }


            //////////////////////COMPARAISON///////////////////////////
            for (int i = 0; i< pix.Length; i ++)
            {
                if ( pixTab[i] == refPixTab[i] )
                {
                    commonsPix ++;
                }
                else
                {
                    diffPix ++;
                }

            }

            
            Debug.Log(diffPix);

            if(diffPix < 1700)
            {
                Debug.Log("level completed");
                   
                if(sceneIndic.name == "scene 1")
                {
                    if (manager.avance < 1)
                    {
                        manager.avance = 1;
                    }
                    SceneManager.LoadScene("entracte 1");
                }
                else if (sceneIndic.name == "scene 2")
                {
                    if (manager.avance < 2)
                    {
                        manager.avance = 2;
                    }
                    SceneManager.LoadScene("entracte 2");
                }
                else if (sceneIndic.name == "scene 3")
                {
                    if (manager.avance < 3)
                    {
                        manager.avance = 3;
                    }
                    manager.avance = 3;
                    SceneManager.LoadScene("entracte 3");
                }
                //SceneManager.LoadScene(LevelToLoad);
            }
            else
            {
                diff.SetText("Incorrect attempt");
            }
    }
}
