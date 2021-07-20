using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private int remainingPickups;
    private int totalPickups;
    GameMenu gameMenu;

    // Start is called before the first frame update
    void Start()
    {
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
        PlayerPrefs.SetInt("REMAINING_PICKUPS", remainingPickups);
        PlayerPrefs.Save();
    }

    private int getRemainingPickups() {
        if (PlayerPrefs.HasKey("REMAINING_PICKUPS"))
            return PlayerPrefs.GetInt("REMAINING_PICKUPS");
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
            return;
        }
        setRemainingPickups();
        gameMenu.updatePickupText(remainingPickups, totalPickups);
    }

}
