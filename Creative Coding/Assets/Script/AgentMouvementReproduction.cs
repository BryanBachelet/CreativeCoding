using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMouvementReproduction : MonoBehaviour
{
    AgentReproduction agentReproduction;
    private Transform partenaire;
    NavMeshAgent meshAgent;
    private GameObject agentSpawn;
    private GameObject parentSpawner;

    public AgentCaste agentCasteCurrent;
    public AgentCaste partenaireCaste;

    [Range(0, 100)] public int changeToGiveSuperiorClass = 50;
    [Range(0, 100)] public int changeToGiveInferiorClass = 50;

    public ManagerAgent managerAgent;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        agentReproduction = GetComponent<AgentReproduction>();
        agentCasteCurrent = GetComponent<AgentCaste>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agentReproduction.reproduction == AgentReproduction.StateReproduction.InReproduction)
        {
            partenaire = agentReproduction.parternaireReproduction.transform;
            partenaireCaste = partenaire.GetComponent<AgentCaste>();
            float distance = Vector3.Distance(transform.position, partenaire.position);
            meshAgent.SetDestination(partenaire.position);
            if (distance < 3f)
            {
                meshAgent.Stop();
                if (agentReproduction.asker)
                {
                    InstantiateAgent();
                }
                    agentReproduction.reproduction = AgentReproduction.StateReproduction.Work;
            }
        }
    }

    public void InstantiateAgent()
    {

        int chance = Random.Range(0, 100);
        if (agentCasteCurrent.CurrentCaste == partenaireCaste.CurrentCaste)
        {
            gameObject.transform.parent.GetComponent<ManagerAgent>().CasteSpawner((int)agentCasteCurrent.CurrentCaste);

        }
        if (agentCasteCurrent.CurrentCaste > partenaireCaste.CurrentCaste)
        {
            if (chance < changeToGiveSuperiorClass)
            {
                gameObject.transform.parent.GetComponent<ManagerAgent>().CasteSpawner((int)agentCasteCurrent.CurrentCaste);
            }
            else
            {
                gameObject.transform.parent.GetComponent<ManagerAgent>().CasteSpawner((int)partenaireCaste.CurrentCaste);
            }

        }
        if (agentCasteCurrent.CurrentCaste < partenaireCaste.CurrentCaste)
        {
            if (chance < changeToGiveInferiorClass)
            {
                gameObject.transform.parent.GetComponent<ManagerAgent>().CasteSpawner((int)agentCasteCurrent.CurrentCaste);
            }
            else
            {
                gameObject.transform.parent.GetComponent<ManagerAgent>().CasteSpawner((int)partenaireCaste.CurrentCaste);
            }
        }
    }
}
