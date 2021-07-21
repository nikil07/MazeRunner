using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private int remainingPickups;
    private int totalPickups;
    GameMenu gameMenu;

    private string REMAINING_PICKUPS_KEY;

    // Start is called before the first frame update
    void Start()
    {
        REMAINING_PICKUPS_KEY = "REMAINING_PICKUPS"+"maze" + SceneManager.GetActiveScene().buildIndex;
        ItemPickup.ItemPickedUp += handleItemPickup;
        gameMenu = FindObjectOfType<GameMenu>();
        StartCoroutine(setPickups());
    }

    IEnumerator setPickups()
    {
        yield return new WaitForSeconds(1f);
        totalPickups = getTotalPickups();
        remainingPickups = getRemainingPickups();
        gameMenu.updatePickupText(remainingPickups, totalPickups);
    }

    private void setRemainingPickups() {
        PlayerPrefs.SetInt(REMAINING_PICKUPS_KEY, remainingPickups);
        PlayerPrefs.Save();
    }

    private int getRemainingPickups() {
        if (PlayerPrefs.HasKey(REMAINING_PICKUPS_KEY))
            return PlayerPrefs.GetInt(REMAINING_PICKUPS_KEY);
        else
            return getTotalPickups();
    }

    private int getTotalPickups() {
        return GameObject.Find("Pickups").gameObject.transform.childCount;
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
        remainingPickups -= pickupPoints;
        if (remainingPickups < 0) {
            PlayerPrefs.SetInt("maze" + SceneManager.GetActiveScene().buildIndex, 1);
            return;
        }
        setRemainingPickups();
        gameMenu.updatePickupText(remainingPickups, totalPickups);
    }

}
