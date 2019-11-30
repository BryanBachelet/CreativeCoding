using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allCity : MonoBehaviour
{
    public GameObject[] listCity;
    float tempsEcoule;
    float tempsEntreListing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempsEcoule += Time.deltaTime;
        if(tempsEcoule > 5)
        {
            listCity = null;
            tempsEcoule = 0;
            listCity = GameObject.FindGameObjectsWithTag("City");
        }
    }

    //public void giveACity(GameObject caller)
    //{
    //    if (listCity.Length >= 2)
    //    {
    //        int rnd = Random.Range(0, listCity.Length);
    //        for(int i = 0; i < listCity.Length; i++)
    //        {
    //            if (listCity[i].gameObject != caller)
    //            {
    //
    //            }
    //        }
    //    }
    //}
}
