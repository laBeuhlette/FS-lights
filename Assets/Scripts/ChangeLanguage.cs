using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
#############################
# TOOL MADE BY GEMINITAURUS #
#############################
*/
public class ChangeLanguage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ButtonLanguage()//On Button Click
    {

        if(LocalizationSystem.instance.currentLanguage < LocalizationSystem.instance.languagesHeaders.Length-1)//if next lang available
        {

            LocalizationSystem.instance.currentLanguage++;
            LocalizationSystem.instance.Init();
        }
        else//loop
        {

            LocalizationSystem.instance.currentLanguage = 0;
            LocalizationSystem.instance.Init();

        }
        StartCoroutine("LoadingNewLanguage");//wait before reloading scene
    }

    private IEnumerator LoadingNewLanguage()
    {
        while (!LocalizationSystem.instance.isReady)
        {
            yield return null;//wait
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reload scene

    }
}
