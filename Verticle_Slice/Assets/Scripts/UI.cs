using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;



public class UI : MonoBehaviour
{
    public static float timer;
    public TextMeshProUGUI time_text;
    public TextMeshProUGUI date_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnGUI()
    {
        time_text.text = string.Format(DateTime.Now.ToString("HH:m tt"));
        date_text.text = string.Format($"{DateTime.Now.DayOfWeek.ToString().Substring(0,3)}. {DateTime.Now.Day.ToString()}");
        
    }
}
