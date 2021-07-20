using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] Image lockImage;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        setButtonStatus();
    }

    private void setButtonStatus() {
        // Update button clickablity, Alpha and the lock image

    }
}
