using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject[] trail;
    private TrailMouvement trailMvt;
    private GameObject currentTrail;
    int i = 0;
    private ActiveComportement activeComportement;
    public Material first;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, Random.Range(-250, 250));
        int i = Random.Range(0, trail.Length);
        currentTrail = Instantiate(trail[i], Vector3.up + new Vector3(249, 0, 0) + pos, Quaternion.identity);
        GetMaterial(currentTrail);
        activeComportement = currentTrail.GetComponent<ActiveComportement>();
        //trailMvt = currentTrail.GetComponent<TrailMouvement>();
        //trailMvt.i = i;
        //i++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activeComportement.isWorking)
        {
            Vector3 pos = new Vector3(0, 0, Random.Range(-100, 100));
            int i = Random.Range(0, trail.Length);
            currentTrail = Instantiate(trail[i], Vector3.up + new Vector3(249, 0, 0) + pos, Quaternion.identity);
            GetMaterial(currentTrail);
            activeComportement = currentTrail.GetComponent<ActiveComportement>();
            //trailMvt = currentTrail.GetComponent<TrailMouvement>();
            //trailMvt.i = i;
            //i++;

        }
        if (i > 5)
        {
            i = 0;
        }
    }

    void GetMaterial(GameObject currentMat)
    {
        Color color = new Color(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        Material mat = new Material(first);
        mat.color = color * 5;
        mat.SetFloat("_EmissionEnabled", 1);
        mat.SetVector("_EmissionColor", color * 15);

        currentMat.GetComponent<Renderer>().material = mat;
    }

}
