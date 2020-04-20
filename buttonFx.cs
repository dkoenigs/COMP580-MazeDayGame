using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFx: MonoBehaviour
{

    public AudioSource myFx;
    public AudioClip selectFx;

    public void SelectSound()
    {
        myFx.PlayOneShot(selectFx);
    }

}

