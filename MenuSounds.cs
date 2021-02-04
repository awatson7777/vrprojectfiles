using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{

    public AudioSource sourceSound;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        sourceSound.PlayOneShot(hoverSound, 1.0f);
    }

    public void ClickSound()
    {
        sourceSound.PlayOneShot(clickSound, 1.0f);
    }

}
