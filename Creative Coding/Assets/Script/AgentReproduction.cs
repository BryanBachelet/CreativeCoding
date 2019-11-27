using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentReproduction : MonoBehaviour
{
    public enum StateReproduction { SearchReproduction, InReproduction, Work }
   /* [HideInInspector]*/ public StateReproduction reproduction;

    public float reproductionTime=10;
    private float _reproductionTime;
    public float dectectionZone=10;

    public bool inReproduction = false;
    public GameObject parternaireReproduction;
    [Header("Demand")]
    [Range(0, 100)] public int demandChanceReproductionSameCast = 10;
    [Range(0, 100)] public int demandChanceReproductionSuperioCast = 10;
    [Range(0, 100)] public int demandChanceReproductionInferiorCast = 10;
    [Header("Acceptation")]
    [Range(0, 100)] public int chanceReproductionSameCast =10;
    [Range(0, 100)] public int chanceReproductionSuperioCast = 10;
    [Range(0, 100)] public int chanceReproductionInferiorCast = 10;

    public float durationBetweenAsk;
    private float _durationBetweenAsk;

    public Collider[] agentAround = new Collider[0];
    public int tryAgent = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reproduction == StateReproduction.SearchReproduction)
        {
            if (_reproductionTime > reproductionTime)
            {
                _reproductionTime = 0;
                reproduction = StateReproduction.Work;
            }
            else
            {
                _reproductionTime += Time.deltaTime;
                if (tryAgent == agentAround.Length)
                {
                    CheckAgentAround();
                    tryAgent = 0;
                }
                if (_durationBetweenAsk > durationBetweenAsk)
                {
                    TryoutAgent();
                    _durationBetweenAsk =0;
                }
                else
                {
                    _durationBetweenAsk += Time.deltaTime;
                }
            }
        }
    }

    public void CheckAgentAround()
    {
        agentAround = Physics.OverlapSphere(transform.position, dectectionZone,1<<9);

    }
    public void TryoutAgent()
    {
        if (!inReproduction)
        {
            GameObject agent = agentAround[tryAgent].gameObject;
            AgentReproduction partenaireScript = agent.GetComponent<AgentReproduction>();

            bool acceptDemand = partenaireScript.GetDemand(reproduction, gameObject);
            if (acceptDemand)
            {
                inReproduction = true;
                parternaireReproduction = agent;
                reproduction = StateReproduction.InReproduction;

            }
            else
            {
                tryAgent++;
            }
        }

    }

   

    public bool GetDemand(StateReproduction state, GameObject agentAsker)
    {
        bool accept = false;
        if (!inReproduction)
        {
            int chance = Random.Range(0, 100);
            if (state == reproduction)
            {
                if (chance < chanceReproductionSameCast)
                {
                    inReproduction = true;
                    parternaireReproduction = agentAsker;
                    reproduction = StateReproduction.InReproduction;
                    return accept = true;
                }
                else
                {
                    return accept = false;
                }

            }
            if (state < reproduction)
            {
                if (chance < chanceReproductionSameCast)
                {
                    inReproduction = true;
                    parternaireReproduction = agentAsker;
                    reproduction = StateReproduction.InReproduction;
                    return accept = true;
                }
                else
                {

                    return accept = false;
                }
            }
            if (state > reproduction)
            {
                if (chance < chanceReproductionSameCast)
                {
                    inReproduction = true;
                    parternaireReproduction = agentAsker;
                    reproduction = StateReproduction.InReproduction;
                    return accept = true;
                }
                else
                {

                    return accept = false;
                }

            }
        }

        return accept = false;
    }
}

