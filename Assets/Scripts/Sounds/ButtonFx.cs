using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour
{
    public AudioSource hoverSound;
    public AudioSource clickSound;

    public void ClickSound()
    {
        clickSound.Play();
    }

    public void HoverSound()
    {
        hoverSound.Play();
    }
}
