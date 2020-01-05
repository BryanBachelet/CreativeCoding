using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTrail : MonoBehaviour
{
    public GameObject trail;
    public float time = 35;
    private float compteur;
    public ActiveComportement activeComportement;
    public bool fin;
    public Material material;
    public Color color;
    public float t;
    public void Start()
    {
        activeComportement = trail.GetComponent<ActiveComportement>();
        material = trail.GetComponent<TrailRenderer>().material;
        color = material.color;
    }

    public void Update()
    {
        if (!activeComportement.isWorking)
        {
            if (fin)
            {
                t += 2 * Time.deltaTime;
                Color colorUse = color/ t;
                trail.GetComponent<TrailRenderer>().material.SetVector("_EmissionColor", colorUse);
                if(t >= 10)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
