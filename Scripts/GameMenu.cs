using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Canvas playerInfoCanvas;
    [SerializeField] Canvas pauseMenuCanvas;

    EnterLevel enterLevel;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        enterLevel = FindObjectOfType<EnterLevel>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (!isPaused)
            {
                openPauseMenu();
                isPaused = true;
            }
            else {
                closePauseMenu();
                isPaused = false;
            }

    }

    public void startGame() {
        int getLevelScene = PlayerPrefs.GetInt("currentGameLevel"); // TODO get current level being played by user
        if (getLevelScene == 0)
        {
            PlayerPrefs.SetInt("currentGameLevel", 1);
            PlayerPrefs.Save();
            callLoadLevel(1);
        }
        else {
            callLoadLevel(getLevelScene);
        }
    }

    public void quitGame() {
        Application.Quit();
    }

    public void goToLandingScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene("LandingScene");
    }

    public void showAllLevels() {
        Time.timeScale = 1;
        SceneManager.LoadScene("AllLevelsScene");
    }

    public void showLevel(int level) {
        if (level > SceneManager.sceneCountInBuildSettings)
        {
            print("INVALID LEVEL");
            return;
        }

        callLoadLevel(level);
    }

    private void callLoadLevel(int level) {
        StartCoroutine(enterLevel.openMaze(level));
    }

    public void openPauseMenu() {
        pauseMenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void closePauseMenu() {
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
