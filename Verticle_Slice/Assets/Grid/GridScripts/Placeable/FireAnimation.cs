using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    private bool _isOn = false;
    public Animation ani;

    void Start()
    {
        ani = this.gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isOn == false)
            {
                _isOn = true;
                ani.Play();
                return;
            }
            if (_isOn == true) 
            {
                _isOn = false;
                ani.Stop();
                return;
            }
        }
    }
}
