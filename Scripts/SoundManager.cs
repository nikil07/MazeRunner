using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static void playJumpSound()
    {
        GameObject jumpSoundGameObject = new GameObject("JumpSound");
        AudioSource audioSource = jumpSoundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GameAssets.instance.jumpSound);
    }

    public static void buttonSound() {
        GameObject jumpSoundGameObject = new GameObject("ButtonClick");
        AudioSource audioSource = jumpSoundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GameAssets.instance.buttonClick);
    }
}
