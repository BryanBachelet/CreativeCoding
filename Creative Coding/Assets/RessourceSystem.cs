using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceSystem : MonoBehaviour
{
    public float currentRadius = 10f;
    public int currentPopul = 0;
    public int religionPopul;
    public int protectionPopul;
    public int marchandPopul;
    public int cultivateurpopul;
    int maxReligion = 0;
    int maxProtection = 0;
    int maxMarchand = 0;
    int maxCultivateur = 0;

    SphereCollider mySC;
    // Start is called before the first frame update
    void Start()
    {
        mySC = gameObject.AddComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPopulRepartition();
        currentRadius = currentPopul;
        currentPopul = religionPopul + protectionPopul + marchandPopul + cultivateurpopul;
        mySC.radius = currentRadius;
    }

    void GetPopulRepartition()
    {
        religionPopul = 0;
        cultivateurpopul = 0;
        protectionPopul = 0;
        marchandPopul = 0;

        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<AgentCaste>())
            {
                if(transform.GetChild(i).GetComponent<AgentCaste>().CurrentCaste == AgentCaste.Caste.Farmer)
                {
                    cultivateurpopul++;
                }
                else if(transform.GetChild(i).GetComponent<AgentCaste>().CurrentCaste == AgentCaste.Caste.Seller)
                {
                    marchandPopul++;
                }
                else if (transform.GetChild(i).GetComponent<AgentCaste>().CurrentCaste == AgentCaste.Caste.Protector)
                {
                    protectionPopul++;
                }
                else if (transform.GetChild(i).GetComponent<AgentCaste>().CurrentCaste == AgentCaste.Caste.Priest)
                {
                    religionPopul++;
                }

            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.4f);
        Gizmos.DrawSphere(transform.position, currentRadius);
        Gizmos.DrawWireSphere(transform.position, currentRadius);
    }

    public void ChooseAName()
    {

    }
}
