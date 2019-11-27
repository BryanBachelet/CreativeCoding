using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiLinkValue : MonoBehaviour
{
    public Text myTextTempsEcoule;
    public Text myTextCalendar;
    public TimeInGame myTIG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTextTempsEcoule.text = myTIG.tempsEcoule.ToString("F1");
        myTextCalendar.text = ("" + myTIG.day + " Jour /"+ myTIG.week + " Semaine /" + myTIG.month + " Mois /" + myTIG.year + " Année");
    }
}
