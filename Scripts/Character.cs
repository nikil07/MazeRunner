using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using ECM.Components;

public class Character : MonoBehaviour
{

    [SerializeField] BaseFirstPersonController firstPersonController;
    [SerializeField] CharacterMovement characterMovement;
 
    // Start is called before the first frame update
    void Start()
    {
        print("speed of character " + firstPersonController.speed);
        
    }

    // Update is called once per frame
    void Update()
    {
       // print("speed of character " + characterMovement.velocity);
    }
}
