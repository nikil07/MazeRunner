using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;
    
    public static GameAssets instance
    {
        get {
            if (_instance == null)
                _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _instance;
        }
    }

    public AudioClip jumpSound;

    public AudioClip buttonClick;

    public AudioClip goldPickupSound;

    public AudioClip diamondPickupSound;

    public GameObject ghostPickup;

}
