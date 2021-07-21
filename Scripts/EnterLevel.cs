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
        PlayerPrefs.SetInt("maze" + (PlayerPrefs.GetInt("currentGameLevel") -1 ), 1);
    }

    public IEnumerator openMaze(int maze)
    {
        if (mouseLook)
            mouseLook.lockCursor = false;
        yield return new WaitForSeconds(1f);
        //maze++;
        if (maze <= SceneManager.sceneCountInBuildSettings-2)
        {
            // Code to execute after the delay
            PlayerPrefs.SetInt("currentGameLevel", maze);
            PlayerPrefs.Save();
            SceneManager.LoadScene(maze);
        }
        else {
            // Code to execute after the delay
            PlayerPrefs.SetInt("currentGameLevel", 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
        }
    }
}
