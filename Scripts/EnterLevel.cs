using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour
{
    readonly string mazeRoom1 = "MazeRoom1";
    readonly string mazeRoom2 = "MazeRoom2";
    readonly string mazeRoom3 = "MazeRoom3";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.name.Equals(mazeRoom1))
        {
            StartCoroutine(openMaze(1));
        }
        else if (transform.parent.name.Equals(mazeRoom2))
        {
            StartCoroutine(openMaze(2));
        }
        else if (transform.parent.name.Equals(mazeRoom3))
        {
            StartCoroutine(openMaze(3));
        }
        else {
            StartCoroutine(openMaze(PlayerPrefs.GetInt("currentGameLevel") + 1));
        }
    }

    public IEnumerator openMaze(int maze)
    {
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
