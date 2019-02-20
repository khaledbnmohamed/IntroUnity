using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Handles All the data from the QR reader
/// 0 -> Template Varaible
/// 1 ->  facebook page
/// 2 -> twitter
/// 3 -> phone
/// </summary>

public class QRdataHandler : MonoBehaviour
{


   

    private void Start()
    {
        QRValues(SceneSwitcher.QRValue);

    }
    public List<string> ExtractedValues = new List<string>();
    public void onButtonClick()
    {
        Debug.Log(" SceneSwitcherinARscene.QRValue" + SceneSwitcher.QRValue);
        
        //QRValues(SceneSwitcher.QRValue);
     }
    public void QRValues(string QRValue)

    { 
    char[] separators = new char[] { ' ' };

    foreach (var word  in QRValue.Split(separators, StringSplitOptions.RemoveEmptyEntries))
    {

            ExtractedValues.Add(word);
    }

        Debug.Log("ExtractedValues" + ExtractedValues[0]);

    }
    public string getTemplateId()
    {

        try
        {

            return ExtractedValues[0];

        }
        catch
        {
            return "0";


        }
    }
    

    public void onCickFacebook()
    {

        Application.OpenURL("https://facebook.com/" + ExtractedValues[1]);
    }
    public void onClickTwitter()
    {

        Application.OpenURL("https://twitter.com/@" + ExtractedValues[2]);
    }
    public void onClickPhone()
    {

        Application.OpenURL("tel://"+ ExtractedValues[3]);
    }

}
