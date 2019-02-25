using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTemplate : MonoBehaviour {

    public QRdataHandler QRscriptHandler;
    public GameObject VideoPlayerCube;

    private static Quaternion Change(float x, float y, float z)
    {
        //Return the new Quaternion
        return new Quaternion(x, y, z, 1);
    }

    private void Update()
    {
       
    }

 public void ActivateTemplate()
    {

        Debug.Log("QRscriptHandler.getTemplateId()" + QRscriptHandler.getTemplateId());

        switch (QRscriptHandler.getTemplateId())
        {


            case "0":
                gameObject.transform.GetChild(0).gameObject.SetActive(true); // cube 
                break;
            case "1":
                gameObject.transform.GetChild(1).gameObject.SetActive(true); // Cycliner 
                break;
            case "2":
                gameObject.transform.GetChild(2).gameObject.SetActive(true); // Sphere 
                break;
            case "3":
                gameObject.transform.GetChild(2).gameObject.SetActive(true); // Sphere 
                break;


            default:
                gameObject.transform.GetChild(0).gameObject.SetActive(true); // cube 
                break;


        }
        VideoPlayerCube.SetActive(true);
    }

    public void DeactivateTemplate()
    {

        Debug.Log("DeactivateTemplate" + QRscriptHandler.getTemplateId());

        switch (QRscriptHandler.getTemplateId())
        {


            case "0":
                gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.61f, 3.57f, 3.37f); // cube 
                gameObject.transform.GetChild(0).gameObject.transform.localRotation = Change(0f, 180f, 0f);  // cube 

                gameObject.transform.GetChild(0).gameObject.SetActive(false); // cube 

                break;
            case "1":
                gameObject.transform.GetChild(1).gameObject.SetActive(false); // Cycliner 
                break;
            case "2":
                gameObject.transform.GetChild(2).gameObject.SetActive(false); // Sphere 
                break;
            case "3":
                gameObject.transform.GetChild(2).gameObject.SetActive(false); // Sphere 
                break;


            default:
                gameObject.transform.GetChild(0).gameObject.SetActive(false); // cube 

                break;


        }
        VideoPlayerCube.SetActive(false);

    }

}
