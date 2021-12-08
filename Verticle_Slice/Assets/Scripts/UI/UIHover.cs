using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHover : MonoBehaviour
{
    public void OnMouseEnter()
    {
        GetComponentInChildren<Transform>().localScale += new Vector3(0.1f, 0.1f);
    }
    public void OnMouseExit()
    {
        GetComponentInChildren<Transform>().localScale -= new Vector3(0.1f, 0.1f);
    }
}
