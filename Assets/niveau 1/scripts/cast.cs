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

        
        #region inputY
        if (Input.GetKeyDown(KeyCode.Y))
        {

            //////////////////////RENDER TEXTURE REF///////////////////////////
            RenderTexture.active = refSourceTex;
            refTargetTex.ReadPixels(new Rect(0, 0, refSourceTex.width, refSourceTex.height), 0, 0);
            refTargetTex.Apply();

            Color[] refPix = refTargetTex.GetPixels(37, 37, 219-37, 219-37);
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


            Color[] pix = targetTex.GetPixels(37, 37, 219-37, 219-37);
            
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

            if(diffPix < 1500)
            {
                Debug.Log("level completed");
                SceneManager.LoadScene(LevelToLoad);
            }


            /*
            pixel = targetTex.GetPixel(128, 128);
            Debug.Log("128 :" + pixel);
            pixel2 = targetTex.GetPixel(1, 1);
            Debug.Log("1 :" + pixel2);
            */




            /*
            for (int i = 0; i < 128; i++)
            {
                if (targetTex.GetPixel(i, i).r > 0.7)
                {
                    targetTex.SetPixel(i,i , Color.red);
                    Debug.Log("blanc");
                }
                else
                {
                    targetTex.SetPixel(i,i , Color.blue);
                    Debug.Log("noir");
                }
            }
            targetTex.Apply();
            */

            /*
            for (int i = 37; i<219; i ++)
            {
                for (int j = 37; j<219; j ++)
                {
                    if (targetTex.GetPixel(i, j).r > 0.5)
                    {
                        targetTex.SetPixel(i,j , Color.red);
                        Debug.Log("blanc");
                    }
                    else
                    {
                        targetTex.SetPixel(i,j , Color.blue);
                        Debug.Log("noir");
                    }
                }
            }
            targetTex.Apply();
            */

            

        }
        #endregion

        
        
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

            diff.SetText(diffPix.ToString());

            if(diffPix < 700)
            {
                Debug.Log("level completed");
                SceneManager.LoadScene(LevelToLoad);
            }
    }
}
