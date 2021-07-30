using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPresenter : MonoBehaviour
{
    [SerializeField] Canvas controlsCanvas;
    [SerializeField] Canvas pickupsCanvas;
    [SerializeField] Canvas settingsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            //shutdown controls canvas
            Time.timeScale = 1;
            if(controlsCanvas)
                controlsCanvas.gameObject.SetActive(false);
             else if (pickupsCanvas)
                pickupsCanvas.gameObject.SetActive(false);
            else if (settingsCanvas)
                settingsCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.name) {
            case "1":
                print("First block");
                Time.timeScale = 0;
                if(controlsCanvas)
                    controlsCanvas.gameObject.SetActive(true);
                break;
            case "2":
                print("Second block");
                Time.timeScale = 0;
                if (pickupsCanvas)
                    pickupsCanvas.gameObject.SetActive(true);
                break;
            case "3":
                print("First block");
                Time.timeScale = 0;
                if (settingsCanvas)
                    settingsCanvas.gameObject.SetActive(true);
                break;
            case "4":
                print("First block");
                break;
            case "5":
                print("First block");
                break;
        }
    }
}
