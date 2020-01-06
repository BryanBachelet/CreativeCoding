using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject[] trail;
    public GameObject neutralTrail;
    private TrailMouvement trailMvt;
    public GameObject currentTrail;
    public List<GameObject> ActiveTrail;
    public int lastTrailAdd;
    public int limitTrail;
    int i = 0;
    int j = 0;
    private ActiveComportement activeComportement;
    public Material first;
    public bool horizontal;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = StartPos();
        int i = Random.Range(0, trail.Length);
        currentTrail = Instantiate(neutralTrail, Vector3.up + pos, Quaternion.identity);
        RandomizeCurrentTrail(currentTrail);
        RetainsTrail(currentTrail);
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
            currentTrail = Instantiate(neutralTrail, Vector3.up + pos, Quaternion.identity);
            RandomizeCurrentTrail(currentTrail);
            RetainsTrail(currentTrail);
            currentTrail = currentTrail.GetComponent<InfoTrail>().trail;
            GetMaterial(currentTrail);

            activeComportement = currentTrail.GetComponent<ActiveComportement>();
            if (horizontal)
            {
                activeComportement.j = 2 + j;
            }
            else
            {
                activeComportement.j = j;
            }
        }
    }


    private void RandomizeCurrentTrail( GameObject trail)
    {
      
        ManagerTrailBehavior managerTrail = trail.GetComponentInChildren<ManagerTrailBehavior>();
        for (int i = 0; i < 3; i++)
        {
            managerTrail.beheviorLine.Add((int)Random.Range(0, 4));
        }


    }

    private void RetainsTrail(GameObject trailToAdd)
    {
        if (ActiveTrail.Count > limitTrail)
        {
            GameObject trail = ActiveTrail[lastTrailAdd];
            ActiveTrail.RemoveAt(lastTrailAdd);
            trail.GetComponent<InfoTrail>().fin = true;
            ActiveTrail.Insert(lastTrailAdd, trailToAdd);

            lastTrailAdd = Count(lastTrailAdd);
        }
        else
        {
            ActiveTrail.Add(trailToAdd);
            lastTrailAdd = Count(lastTrailAdd);
        }
    }


    private int Count(int countEnter)
    {
        int countExit = 0;

        if (countEnter < limitTrail)
        {
            countExit = countEnter + 1;
        }
        else
        {
            countExit = 0;
        }

        return countExit;
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

        j = Random.Range(0, 2);
        if (horizontal)
        {
            if (j == 0)
            {
                pos = new Vector3(-200, 0, Random.Range(-200, 200));
            }
            if (j == 1)
            {
                pos = new Vector3(200, 0, Random.Range(-200, 200));
            }
            horizontal = false;
        }
        else
        {
            horizontal = true;
            if (j == 0)
            {
                pos = new Vector3(Random.Range(-200, 200), 0, -200);
            }
            if (j == 1)
            {
                pos = new Vector3(Random.Range(-200, 200), 0, 200);
            }
        }

        return pos;
    }

}
