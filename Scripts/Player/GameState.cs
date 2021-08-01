using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private int remainingPickups;
    private int remainingPassPickups;
    private int totalPickups;
    GameMenu gameMenu;

    private string REMAINING_PICKUPS_KEY;
    private string REMAINING_PASS_PICKUPS_KEY;

    // Start is called before the first frame update
    void Start()
    {
        REMAINING_PICKUPS_KEY = "REMAINING_PICKUPS"+"maze" + SceneManager.GetActiveScene().buildIndex;
        REMAINING_PASS_PICKUPS_KEY = "REMAINING_PASS_PICKUPS" + "maze" + SceneManager.GetActiveScene().buildIndex;
        ItemPickup.ItemPickedUp += handleItemPickup;
        gameMenu = FindObjectOfType<GameMenu>();
        StartCoroutine(setPickups());
    }

    IEnumerator setPickups()
    {
        yield return new WaitForSeconds(1f);
        totalPickups = getTotalPickups();
        remainingPickups = getRemainingPickups();
        setPassPickups();
        if (PlayerPrefs.HasKey(REMAINING_PASS_PICKUPS_KEY))
            remainingPassPickups = PlayerPrefs.GetInt(REMAINING_PASS_PICKUPS_KEY);
        else
            remainingPassPickups = getPassPickups();
        gameMenu.updatePickupText(remainingPickups, remainingPassPickups ,totalPickups);
    }

    private void setRemainingPickups() {
        PlayerPrefs.SetInt(REMAINING_PICKUPS_KEY, remainingPickups);
        PlayerPrefs.SetInt(REMAINING_PASS_PICKUPS_KEY, remainingPassPickups);
        PlayerPrefs.Save();
    }

    private int getRemainingPickups() {
        if (PlayerPrefs.HasKey(REMAINING_PICKUPS_KEY))
            return PlayerPrefs.GetInt(REMAINING_PICKUPS_KEY);
        else
            return getTotalPickups();
    }

    private int getTotalPickups() {
        int pickupsTotal = GameObject.Find("Pickups").gameObject.transform.childCount;
        if (!PlayerPrefs.HasKey(Constants.TOTAL_PICKUPS_NUMBER + SceneManager.GetActiveScene().buildIndex))
            PlayerPrefs.SetInt(Constants.TOTAL_PICKUPS_NUMBER + SceneManager.GetActiveScene().buildIndex, pickupsTotal);
        return pickupsTotal;
    }

    private void setPassPickups() {
        if (!PlayerPrefs.HasKey(Constants.PASS_PICKUPS_NUMBER + SceneManager.GetActiveScene().buildIndex))
            PlayerPrefs.SetInt(Constants.PASS_PICKUPS_NUMBER + SceneManager.GetActiveScene().buildIndex, totalPickups / 2);
    }

    private int getPassPickups() {
        return PlayerPrefs.GetInt(Constants.PASS_PICKUPS_NUMBER + SceneManager.GetActiveScene().buildIndex, 100);
    }

    private void OnDestroy()
    {
        ItemPickup.ItemPickedUp -= handleItemPickup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void handleItemPickup(string tag, int pickupPoints) {
        print(tag + " picked up");
        //remainingPickups -= pickupPoints;
        remainingPickups -= 1;
        remainingPassPickups -= pickupPoints;
        setRemainingPickups();

        if (remainingPassPickups <= 0) {
            PlayerPrefs.SetInt("maze" + SceneManager.GetActiveScene().buildIndex, 1);
        }

        if (remainingPickups < 0)
            return;
        
        gameMenu.updatePickupText(remainingPickups, remainingPassPickups, totalPickups);
    }

}
