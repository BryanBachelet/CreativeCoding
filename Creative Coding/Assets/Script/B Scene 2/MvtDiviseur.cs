using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtDiviseur : MonoBehaviour
{
    public float speed;
    public float distanceDeplacement;
    public float divisionChange;
    public GameObject trailinstan;
    private Vector3 destination;
    private ActiveComportement activeComportement;
    private bool tryStart = true;
    private int j = 1;
    private int i = 1;
    void Start()
    {
        activeComportement = GetComponent<ActiveComportement>();
        destination = destination == Vector3.zero ? transform.position : destination;
    }
    // Update is called once per frame
    void Update()
    {
        if (activeComportement.isWorking)
        {
            MouvementLine();
        }
    }
    public void MouvementLine()
    {
        if (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        else
        {
            if (!tryStart)
            {
                i = -i;

                destination = transform.position + (new Vector3(0, 0, i).normalized * 5);
                GameObject gamObject = Instantiate(trailinstan, transform.position, Quaternion.identity);
                MvtDiviseur mLine = gamObject.GetComponent<MvtDiviseur>();

                mLine.MouvementLineStart(5, -i);
                tryStart = true;

            }
            else
            {


                if (j % 5 == 0)
                {
                    tryStart = false;
                }
                destination = transform.position + (new Vector3(-1, 0, 0).normalized * distanceDeplacement);
                j++;
            }
        }
    }
    public void MouvementLineStart(float distanceMvt, float direction)
    {
        destination = transform.position + (new Vector3(0, 0, direction).normalized * distanceMvt);
    }
}
