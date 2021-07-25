using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource walkingSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMovementSound(bool isWalking) {
        print("playmvementsound  " + isWalking );
        if(isWalking)
            walkingSound.Stop();
        else
            walkingSound.Stop();
    }

    public bool isAudioPlaying() {
        return walkingSound.isPlaying;
    }
}
