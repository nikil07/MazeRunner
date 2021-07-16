using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ItemPickup : MonoBehaviour
{

    public static event Action<String> ItemPickedUp;

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
        if (other.gameObject.tag.Equals("Player")) {
            handlePlayerCollectedItem();
        }
    }

    private void handlePlayerCollectedItem() {
        //print("player picked up");
        ItemPickedUp?.Invoke(gameObject.tag);
    }
}
