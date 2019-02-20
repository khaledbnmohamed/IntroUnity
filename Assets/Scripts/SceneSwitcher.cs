﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public string scenename;
    public static string QRValue;
    bool Loaded = false;

    Scene sceneToLoad;
    Scene sceneToUnload;
 
    // Use this for initialization


   public  void OnButtonClick()
    {


            StartCoroutine(ChangeScene());
        
    }
 


    IEnumerator ChangeScene()
    {
            Debug.Log("sceneName to load: " + scenename);

            SceneManager.LoadScene(scenename);
            sceneToLoad = SceneManager.GetSceneByName(scenename);
            sceneToUnload = SceneManager.GetActiveScene();

            //OnSceneLoaded(sceneToLoad, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += OnSceneLoaded;

    
        yield return null;


        //  var spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        // other.transform.position = spawnPoint.position;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Loaded = true;
        if (scenename == "ARScene")
        {

            SceneManager.UnloadSceneAsync(0);

        }
        else
        {
            SceneManager.UnloadSceneAsync(1);


        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}