using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] int pickupPoints;
    
    public static event Action<String, int> ItemPickedUp;


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
            Destroy(gameObject);
        }
    }

    private void handlePlayerCollectedItem() {
        //print("player picked up");
        ItemPickedUp?.Invoke(gameObject.tag, pickupPoints);
    }
}
