using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] Image lockImage;
    [SerializeField] int buttonNumber;

    Image mainImage;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        mainImage = GetComponent<Image>();
        button = GetComponent<Button>();
        setButtonStatus();
    }

    private void setButtonStatus() {
        // Update button clickablity, Alpha and the lock image
        if (PlayerPrefs.GetInt("maze" + buttonNumber, -1) == 1)
        {
            lockImage.gameObject.SetActive(false);
            button.interactable = true;
            mainImage.color = new Color(mainImage.color.r, mainImage.color.g, mainImage.color.b, 1f);
        }
        else {
            lockImage.gameObject.SetActive(true);
            //mainImage.color = new Color(mainImage.color.r, mainImage.color.g, mainImage.color.b, 0.3f);
            button.interactable = false;
        }
    }
}
