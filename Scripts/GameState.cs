using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private int remainingPickups;

    private int totalPickups;
    GameMenu gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        ItemPickup.ItemPickedUp += handleItemPickup;
        gameMenu = FindObjectOfType<GameMenu>();
        totalPickups = remainingPickups;
        gameMenu.updatePickupText(remainingPickups, totalPickups);
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
        
        gameMenu.updatePickupText(remainingPickups, totalPickups);
    }

}
