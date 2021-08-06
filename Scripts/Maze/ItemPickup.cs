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
            //Destroy(gameObject.transform.parent.gameObject);
            //Destroy(gameObject);

            Instantiate(GameAssets.instance.ghostPickup, gameObject.transform.parent.gameObject.transform.position,Quaternion.identity);
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
            Instantiate(GameAssets.instance.ghostPickup, gameObject.transform.parent.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    private void handlePlayerCollectedItem() {
        if (pickupPoints == 1)
            SoundManager.pickupSoundGold();
        else if (pickupPoints == 3)
            SoundManager.pickupSoundDiamond();
        ItemPickedUp?.Invoke(gameObject.tag, pickupPoints);
    }
}
