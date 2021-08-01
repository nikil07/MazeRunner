using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ECM.Components;
using System;

public class EnterLevel : MonoBehaviour
{

    MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        mouseLook = FindObjectOfType<MouseLook>();
        if (!mouseLook)
            return;
        mouseLook.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        updateLevelCompleted();
        StartCoroutine(openMaze(PlayerPrefs.GetInt("currentGameLevel") + 1));
    }

    private void updateLevelCompleted()
    {
        PlayerPrefs.SetInt("maze" + (PlayerPrefs.GetInt("currentGameLevel")), 1);
    }

    public IEnumerator openMaze(int maze)
    {
        if (mouseLook)
            mouseLook.lockCursor = false;
        yield return new WaitForSeconds(0.5f);
        //maze++;
        if (maze <= SceneManager.sceneCountInBuildSettings-2)
        {
            // Code to execute after the delay
            PlayerPrefs.SetInt("currentGameLevel", maze);
            PlayerPrefs.Save();
            print(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(maze)));
            //SceneManager.LoadScene(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(maze)));
            bl_SceneLoader.GetActiveLoader().LoadLevel(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(maze)));


        }
        else {
            // Code to execute after the delay
            PlayerPrefs.SetInt("currentGameLevel", 0);
            PlayerPrefs.Save();
            bl_SceneLoader.GetActiveLoader().LoadLevel(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(0)));
            //SceneManager.LoadScene(0);
        }
    }
}
