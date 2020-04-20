using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsScript : MonoBehaviour
{
    public GameObject sliderVolume;
    public GameObject playButton;

    public void OnEnable()
    {
        EventSystem eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(sliderVolume);
    }

    public void Back()
    {
        EventSystem eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(playButton);
    }
}
