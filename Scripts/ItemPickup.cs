using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] int pickupPoints;

    String myKey;

    public static event Action<String, int> ItemPickedUp;


    // Start is called before the first frame update
    void Start()
    {
        myKey = SceneManager.GetActiveScene().buildIndex +"::" + transform.position.ToString();
        if (PlayerPrefs.HasKey(myKey) && getIsPickedUp() == 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
        else {
            setIsPickedUp(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setIsPickedUp(int state) {
        PlayerPrefs.SetInt(myKey, state);
        PlayerPrefs.Save();
    }

    private int getIsPickedUp() {
      return  PlayerPrefs.GetInt(myKey);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            handlePlayerCollectedItem();
            setIsPickedUp(0);
            Destroy(gameObject);
        }
    }

    private void handlePlayerCollectedItem() {
        ItemPickedUp?.Invoke(gameObject.tag, pickupPoints);
    }
}
