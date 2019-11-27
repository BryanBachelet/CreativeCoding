using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAgent : MonoBehaviour
{
    public GameObject CultiSpawn;
    public GameObject MarchaSpawn;
    public GameObject ReligeSpawn;
    public GameObject ProtecSpawn;
    public int cultivateurPercentStart = 2;
    public int marchandPercentStart = 2;
    public int protectionPercentStart = 2;
    public int religieuxPercentStart = 2;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
