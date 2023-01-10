using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
#############################
# TOOL MADE BY GEMINITAURUS #
#############################
*/
public class LocalizationSystem : MonoBehaviour 
{
    public static LocalizationSystem instance;
    public int currentLanguage;
    public string currentLanguageCode;
    public string[] languagesHeaders;
    public bool isReady;
    private Dictionary<string, string> localizationData;

    private void Awake()//keep one object for the whole game
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    public void Init()//function to init language
    {
        isReady = false;//security gate

        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();//reload csv to check if new language are available and such

        //get values
        languagesHeaders = csvLoader.GetHeaders();
        currentLanguageCode = languagesHeaders[currentLanguage];
        localizationData = csvLoader.GetDictionaryValues(currentLanguage);

        isReady= true;//end
    }

    public string GetLocalizedValue(string key)//return the string attached to a key
    {
        string value = key;
        localizationData.TryGetValue(key, out value);//if fail will return null

        return value;


    }
}
