using System;
using System.Collections.Generic;
using UnityEngine;

/*
#############################
# TOOL MADE BY GEMINITAURUS #
#############################
*/
public class CSVLoader
{
    private string[] csvFile; //array of all strings in file

    //characters to split strings
    private char lineSeparator = '\n';
    private char surround = '"';
    private string[] fieldSeparator = {"\",\""};

    // Start is called before the first frame update

    public void LoadCSV()//loads the csv
    {
        TextAsset path =  Resources.Load<TextAsset>("Language");//finds the asset path
        //Debug.Log(path.ToString().Split("\n"));
        //csvFile = Resources.Load("glass") as string[];
        csvFile = path.ToString().Split(lineSeparator);

    }

    public string[] GetHeaders()//return how many languages and their headers (FR, EN, ...) in the csv
    {
        int languagesDetected = 0;
        string[] lines = csvFile;
        string[] headers = lines[0].Split(fieldSeparator, StringSplitOptions.None);
        string[] result = new string[headers.Length-1];

        for (int i = 1; i < headers.Length; i++)
        {
            headers[i] = headers[i].TrimStart(' ',surround);
            headers[i] = headers[i].Replace("\"", "");
            headers[i] = headers[i].TrimEnd(surround);
            result[i-1] = headers[i];
            languagesDetected++;
            
        }
        //Debug.Log(languagesDetected + " CSVs Detected");
        return result;
    }

    public Dictionary<string,string> GetDictionaryValues(int languageIndex) //return a dictionary of the csv languages values
    {
        int successfulImports = 0;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = csvFile;

        for (int i = 1; i < lines.Length; i++)//formats all lines
        {
            
            string line = lines[i];
            string[] fields = line.Split(fieldSeparator, StringSplitOptions.None);
            for (int j = 0; j < fields.Length; j++)
            {
                Debug.Log(fields[j]);
                fields[j] = fields[j].TrimStart(' ',surround);
                fields[j] = fields[j].Replace("\"", "");
                fields[j] = fields[j].TrimEnd(surround);
                Debug.Log(fields[j]);
                
            }
            dictionary.Add(fields[0], fields[languageIndex+1]);//adds line to Dictionary
            successfulImports++;

        }
        Debug.Log("LOADED successfully " + successfulImports + " fields for localization: " + LocalizationSystem.instance.languagesHeaders[languageIndex]);

        return dictionary;
    }
}