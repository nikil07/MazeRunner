using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using ECM.Components;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;
    [SerializeField] Canvas controlsCanvas;
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] TMP_Text pickupsText;
    [SerializeField] TMP_Text passPickupsText;

    EnterLevel enterLevel;
    private bool isPaused = false;
    int localPassPickupsLeft, localTotalPickupsLeft;

    // Start is called before the first frame update
    void Start()
    {
        enterLevel = FindObjectOfType<EnterLevel>();
        Cursor.lockState = CursorLockMode.None;
        if (SceneManager.GetActiveScene().buildIndex == 0)
            PlayerPrefs.SetInt("maze0", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (!isPaused)
            {
                openPauseMenu();
            }
            else {
                closePauseMenu();
            }

    }

    #region MainMenu

    public void showControls() {
        SoundManager.buttonSound();
        controlsCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
    }

    public void hideControls() {
        SoundManager.buttonSound();
        controlsCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }

    #endregion

    public void startGame() {
        SoundManager.buttonSound();
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
        SoundManager.buttonSound();
        Application.Quit();
    }

    public void goToLandingScene() {
        StartCoroutine(goToLandingSceneCoroutine());
    }

    IEnumerator goToLandingSceneCoroutine() {
        Time.timeScale = 1;
        SoundManager.buttonSound();
        if (pauseMenuCanvas)
            pauseMenuCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        bl_SceneLoader.GetActiveLoader().LoadLevel("LandingScene");
       // SceneManager.LoadScene("LandingScene");
    }

    public void showAllLevels() {
        StartCoroutine(showAllLevelsCoroutine());
    }

    IEnumerator showAllLevelsCoroutine()
    {
        Time.timeScale = 1;
        SoundManager.buttonSound();
        if(pauseMenuCanvas)
            pauseMenuCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        bl_SceneLoader.GetActiveLoader().LoadLevel("AllLevelsScene");
        //SceneManager.LoadScene("AllLevelsScene");
    }

    public void showLevel(int level) {
        SoundManager.buttonSound();
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
        isPaused = true;
        pauseMenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void closePauseMenu() {
        isPaused = false;
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        //FindObjectOfType<MouseLook>().externalLockCursor();
    }

    public void updatePickupText(int picksupsLeft,int passPickupsLeft ,int totalPickups) {
        if (passPickupsLeft < 0)
            passPickupsLeft = 0;
        localTotalPickupsLeft = PlayerPrefs.GetInt(Constants.TOTAL_PICKUPS_NUMBER + +SceneManager.GetActiveScene().buildIndex) - picksupsLeft;
        pickupsText.SetText(localTotalPickupsLeft + "/" + PlayerPrefs.GetInt(Constants.TOTAL_PICKUPS_NUMBER + +SceneManager.GetActiveScene().buildIndex));

        localPassPickupsLeft = PlayerPrefs.GetInt(Constants.PASS_PICKUPS_NUMBER + +SceneManager.GetActiveScene().buildIndex) - passPickupsLeft;
        passPickupsText.SetText(localPassPickupsLeft + "/" + PlayerPrefs.GetInt(Constants.PASS_PICKUPS_NUMBER + +SceneManager.GetActiveScene().buildIndex));

        if (passPickupsLeft == 0)
            passPickupsText.color = (Color.green);

        if(picksupsLeft == 0)
            passPickupsText.color = (Color.green);
    }
}
