using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using ECM.Components;
using TMPro;
using System;

public class Character : MonoBehaviour
{

    [SerializeField] BaseFirstPersonController firstPersonController;
    [SerializeField] BaseCharacterController baseCharacterController;
    [SerializeField] TMP_Text textTimeToNextJump;
    [SerializeField] TMP_Text textJumpsLeft;

    private Transform currentPosition;
 
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        updateCharacterInfo();
        handleCheatCodes();
    }

    private void handleCheatCodes() {
        currentPosition = transform;
        if (Input.GetKey(KeyCode.C))
        {
            transform.position =  GameObject.FindGameObjectWithTag("Exit").gameObject.transform.position;
        }
    }

    private void updateCharacterInfo()
    {
       // if (!textJumpsLeft && !textTimeToNextJump)
        {
            string textTimeToNextJumpString = baseCharacterController.getTimeToNextJump() > 0 ? " in " + baseCharacterController.getTimeToNextJump() : "now";
            string textJumpsLeftString = baseCharacterController.getJumpsLeft().ToString() + " Jumps left";

            textTimeToNextJump.SetText("Can jump " + textTimeToNextJumpString);
            textJumpsLeft.SetText(textJumpsLeftString);
        }
    }
}
