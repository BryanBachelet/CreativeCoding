using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTrail : MonoBehaviour
{
    public GameObject trail;
    public float time= 35;
    private float compteur;
    public ActiveComportement activeComportement;

    public void Start()
    {
        activeComportement = trail.GetComponent<ActiveComportement>();
    }

    public void Update()
    {
        if (!activeComportement.isWorking)
        {
            gameObject.isStatic = true;
        }
    }
}
