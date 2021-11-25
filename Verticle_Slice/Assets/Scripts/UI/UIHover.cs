using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        //FindObjectOfType<SoundManagerScript>().MouseOverButton();
        //increase size
    }

    public void OnPointerDown(PointerEventData ped)
    {
        //FindObjectOfType<SoundManagerScript>().ButtonPressed();
        //go back to normal size
    }
}
