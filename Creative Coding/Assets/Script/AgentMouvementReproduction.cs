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

    public Vector3 posToMove;

    public List<Vector3> pointTotravel = new List<Vector3>();
    public bool isTraveling = false;
    int currentPoint = 0;
    LineRenderer myLR;
    void Start()
    {
        Vector2 rnd = Random.insideUnitCircle * gameObject.transform.parent.GetComponent<RessourceSystem>().currentRadius;
        posToMove = gameObject.transform.parent.position + new Vector3(rnd.x, 0, rnd.y);

        meshAgent = GetComponent<NavMeshAgent>();
        agentReproduction = GetComponent<AgentReproduction>();
        agentCasteCurrent = GetComponent<AgentCaste>();
        myLR = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTraveling)
        {
            if (agentReproduction.reproduction == AgentReproduction.StateReproduction.InReproduction)
            {
                meshAgent.isStopped = false;
                partenaire = agentReproduction.parternaireReproduction.transform;
                partenaireCaste = partenaire.GetComponent<AgentCaste>();
                float distance = Vector3.Distance(transform.position, partenaire.position);
                meshAgent.SetDestination(partenaire.position);
                Debug.Log(gameObject.name + " + " + meshAgent.destination);
                if (distance < 3f)
                {
                    meshAgent.isStopped = true;
                    if (agentReproduction.asker)
                    {
                        InstantiateAgent();
                    }
                    agentReproduction.reproduction = AgentReproduction.StateReproduction.Work;
                }
            }
            if (agentReproduction.reproduction == AgentReproduction.StateReproduction.Work)
            {
                if (meshAgent.remainingDistance < 1)
                {
                    Vector2 rnd = Random.insideUnitCircle * gameObject.transform.parent.GetComponent<RessourceSystem>().currentRadius;
                    posToMove = gameObject.transform.parent.position + new Vector3(rnd.x, 0, rnd.y);
                }
                //gameObject.transform.parent.GetComponent<RessourceSystem>().currentRadius
                meshAgent.SetDestination(posToMove);
            }
        }
        else
        {

            myLR.enabled = true;
            myLR.SetVertexCount(pointTotravel.Count);
            transform.position = Vector3.MoveTowards(transform.position, pointTotravel[currentPoint], 10 * Time.deltaTime);
            if (Vector3.Distance(transform.position, pointTotravel[currentPoint]) <= 2 && currentPoint < pointTotravel.Count)
            {
                currentPoint++;
                myLR.SetPosition(currentPoint, pointTotravel[currentPoint]);

            }
            else if (Vector3.Distance(transform.position, pointTotravel[currentPoint]) <= 2 && currentPoint == pointTotravel.Count)
            {
                transform.parent = transform.parent.GetComponent<ManagerAgent>().cityToTravel.transform;
                isTraveling = false;

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
