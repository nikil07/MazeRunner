using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        ItemPickup.ItemPickedUp += handleItemPickup;
    }

    private void OnDestroy()
    {
        ItemPickup.ItemPickedUp -= handleItemPickup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void handleItemPickup(string tag) {
        print(tag + "picked up");
    }

}
