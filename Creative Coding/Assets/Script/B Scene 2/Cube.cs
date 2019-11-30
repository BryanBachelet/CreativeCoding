﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TrailMouvement>())
        {
            other.GetComponent<TrailMouvement>().visible = false;
        }
        if (other.GetComponent<ActiveComportement>())
        {
            other.GetComponent<ActiveComportement>().isWorking = false;
        }
    }
}
