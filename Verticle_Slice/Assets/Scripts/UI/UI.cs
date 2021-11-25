using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;



public class UI : MonoBehaviour
{
    public static float timer;
    public TextMeshProUGUI time_text;
    public TextMeshProUGUI date_text;
    public int currentItem;

    public List<Button> buttons = new List<Button>();
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
    public int ButtonGetPosition(int index)
    {
        return index;
    }
    public void ButtonPressed(Button button)
    {
        if (buttons.Contains(button))
        {
            int index = buttons.IndexOf(button);
            print(button.gameObject.name);
            ButtonGetPosition(index);
        }
    }
}
