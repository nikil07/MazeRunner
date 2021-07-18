using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ECM.Components;

public class EnterLevel : MonoBehaviour
{

    MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        mouseLook = FindObjectOfType<MouseLook>();
        mouseLook.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
         StartCoroutine(openMaze(PlayerPrefs.GetInt("currentGameLevel") + 1));
    }

    public IEnumerator openMaze(int maze)
    {
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
