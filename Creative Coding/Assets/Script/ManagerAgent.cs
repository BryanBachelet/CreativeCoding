using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAgent : MonoBehaviour
{
    public GameObject CultiSpawn;
    public GameObject MarchaSpawn;
    public GameObject ReligeSpawn;
    public GameObject ProtecSpawn;
    public GameObject ExploSpawn;
    public int cultivateurPercentStart = 2;
    public int marchandPercentStart = 2;
    public int protectionPercentStart = 2;
    public int religieuxPercentStart = 2;

    public GameObject explorateur;
    public List<Vector3> allPoint = new List<Vector3>();
    public GameObject cityToTravel;

    float tempsEcouleTravelTime = 0;
    float tempsEntreTravel = 20;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < cultivateurPercentStart; i++)
        {
            CasteSpawner(0);
        }
        for (int i = 0; i < marchandPercentStart; i++)
        {
            CasteSpawner(1);
        }
        for (int i = 0; i < protectionPercentStart; i++)
        {
            CasteSpawner(2);
        }
        for (int i = 0; i < religieuxPercentStart; i++)
        {
            CasteSpawner(3);
        }
        CasteSpawner(4);
    }

    // Update is called once per frame
    void Update()
    {
        if(cityToTravel != null)
        {
            tempsEcouleTravelTime += Time.deltaTime;
            if(tempsEcouleTravelTime > tempsEntreTravel)
            {
                tempsEcouleTravelTime = 0;
                ChooseChild();

            }
        }
    }

    public void CasteSpawner(int casteValue)
    {
        if(casteValue == 0)
        {
            CultiSpawner();
        }
        else if (casteValue == 1)
        {
            MarchaSpawner();
        }
        else if (casteValue == 2)
        {
            ProtecSpawner();
        }
        else if (casteValue == 3)
        {
            ReligeSpawner();
        }
        else if (casteValue == 4)
        {
            ExploSpawner();
        }
    }
    public void CultiSpawner()
    {
        GameObject newVillager = Instantiate(CultiSpawn, transform.position, transform.rotation, transform);
        newVillager.GetComponent<AgentMouvementReproduction>().managerAgent = gameObject.GetComponent<ManagerAgent>();
    }
    public void MarchaSpawner()
    {
        GameObject newVillager = Instantiate(MarchaSpawn, transform.position, transform.rotation, transform);
        newVillager.GetComponent<AgentMouvementReproduction>().managerAgent = gameObject.GetComponent<ManagerAgent>();
    }
    public void ReligeSpawner()
    {
        GameObject newVillager = Instantiate(ReligeSpawn, transform.position, transform.rotation, transform);
        newVillager.GetComponent<AgentMouvementReproduction>().managerAgent = gameObject.GetComponent<ManagerAgent>();
    }
    public void ProtecSpawner()
    {
        GameObject newVillager = Instantiate(ProtecSpawn, transform.position, transform.rotation, transform);
        newVillager.GetComponent<AgentMouvementReproduction>().managerAgent = gameObject.GetComponent<ManagerAgent>();
    }
    public void ExploSpawner()
    {
        explorateur = Instantiate(ExploSpawn, transform.position, transform.rotation, transform);
    }

    public void GivePath(GameObject villagerToGive)
    {
        if (allPoint.Count > 1)
        {
            villagerToGive.GetComponent<AgentMouvementReproduction>().pointTotravel = allPoint;
            villagerToGive.GetComponent<AgentMouvementReproduction>().isTraveling = true;
        }
    }

    public void ChooseChild()
    {
        int rnd = Random.Range(0, transform.childCount);
        GivePath(transform.GetChild(rnd).gameObject);
  
        
    }
}
