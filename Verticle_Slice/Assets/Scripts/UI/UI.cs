using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UI : MonoBehaviour
{
    
    public TextMeshProUGUI time_text;
    public TextMeshProUGUI date_text;
    public int currentItem;

    

    public List<Button> buttons = new List<Button>();
    private KeyCode[] InputList = new KeyCode[]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.Alpha0,
        KeyCode.Minus,
        KeyCode.Equals

    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
    }
    void InputUpdate()
    {
        if (!Input.anyKeyDown)
            return;

        foreach (KeyCode key in InputList)
            if (Input.GetKeyDown(key))
                switch (key)
                {
                    case KeyCode.Alpha1:
                        currentItem = 0;
                        break;
                    case KeyCode.Alpha2:
                        currentItem = 1;
                        break;
                    case KeyCode.Alpha3:
                        currentItem = 2;
                        break;
                    case KeyCode.Alpha4:
                        currentItem = 3;
                        break;
                    case KeyCode.Alpha5:
                        currentItem = 4;
                        break;
                    case KeyCode.Alpha6:
                        currentItem = 5;
                        break;
                    case KeyCode.Alpha7:
                        currentItem = 6;
                        break;
                    case KeyCode.Alpha8:
                        currentItem = 7;
                        break;
                    case KeyCode.Alpha9:
                        currentItem = 8;
                        break;
                    case KeyCode.Alpha0:
                        currentItem = 9;
                        break;
                    case KeyCode.Minus:
                        currentItem = 10;
                        break;
                    case KeyCode.Equals:
                        currentItem = 11;
                        break;
                }
        
    }
    private void OnGUI()
    {
        time_text.text = string.Format(DateTime.Now.ToString("HH:m tt"));
        date_text.text = string.Format($"{DateTime.Now.DayOfWeek.ToString().Substring(0,3)}. {DateTime.Now.Day.ToString()}");
    }
    
    public void ButtonPressed(Button button)
    {
        if (buttons.Contains(button))
        {
            int index = buttons.IndexOf(button);
            currentItem = buttons.IndexOf(button);
            
        }
    }
    
}
