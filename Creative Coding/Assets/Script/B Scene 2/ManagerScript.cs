using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject[] trail;
    private TrailMouvement trailMvt;
    public GameObject currentTrail;
    int i = 0;
    int j = 0;
    private ActiveComportement activeComportement;
    public Material first;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = StartPos();
        int i = Random.Range(0, trail.Length);
        currentTrail = Instantiate(trail[i], Vector3.up + pos, Quaternion.identity);
        currentTrail = currentTrail.GetComponent<InfoTrail>().trail;
        GetMaterial(currentTrail);
        activeComportement = currentTrail.GetComponent<ActiveComportement>();
        activeComportement.j = j;

    }

    // Update is called once per frame
    void Update()
    {
        if (!activeComportement.isWorking)
        {
            Vector3 pos = StartPos();
            int i = Random.Range(0, trail.Length);
            currentTrail = Instantiate(trail[i], Vector3.up + pos, Quaternion.identity);
            currentTrail = currentTrail.GetComponent<InfoTrail>().trail;
            GetMaterial(currentTrail);

            activeComportement = currentTrail.GetComponent<ActiveComportement>();
            activeComportement.j = j;



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
    public Vector3 StartPos()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        j = Random.Range(0, 4);
        if (j == 0)
        {
            pos = new Vector3(-300, 0, Random.Range(-200, 200));
        }
        if (j == 1)
        {
            pos = new Vector3(300, 0, Random.Range(-200, 200));
        }
        if (j == 2)
        {
            pos = new Vector3(Random.Range(-200, 200), 0, -300);
        }
        if (j == 3)
        {
            pos = new Vector3(Random.Range(-200, 200), 0, 300);
        }

        return pos;
    }

}
