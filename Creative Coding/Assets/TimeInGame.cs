using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInGame : MonoBehaviour
{
    public float second;
    public int minute;
    public int hour;
    public int day = 1;
    public int week = 1;
    public int month = 1;
    public int year = 1;
    public float tempsEcoule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempsEcoule += Time.deltaTime * 1209600;
        second = tempsEcoule;
        minute = ((int) second / 60);
        hour = minute / 60;
        if(hour >= 24)
        {
            day++;
            tempsEcoule = 0;
            second = 0;
            minute = 0;
            hour = 0;
        }
        if(day > 7)
        {
            week++;
            day = 1;
        }
        if(week > 4)
        {
            month++;
            week = 1;
        }
        if(month > 12)
        {
            year++;
            month = 1;
        }
        
    }

    
}
