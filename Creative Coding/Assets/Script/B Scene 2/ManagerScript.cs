using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject trail;
    public TrailMouvement trailMvt;
    public GameObject currentTrail;
    int i = 0;
    private ActiveComportement activeComportement;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, Random.Range(-250, 250));
        currentTrail = Instantiate(trail, Vector3.up + new Vector3(249, 0, 0) + pos, Quaternion.identity);
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
            currentTrail = Instantiate(trail, Vector3.up + new Vector3(249, 0, 0) + pos, Quaternion.identity);
            activeComportement = currentTrail.GetComponent<ActiveComportement>();
            //trailMvt = currentTrail.GetComponent<TrailMouvement>();
            //trailMvt.i = i;
            //i++;
          
        }
        if (i >5)
        {
            i = 0;
        }
    }

}
