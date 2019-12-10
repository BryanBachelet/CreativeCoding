using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtLine : MonoBehaviour
{
    public float speed;
    public float distanceDeplacement;
   
    private Vector3 directionOfDeplacement;
    private Vector3 destination;
    private ActiveComportement activeComportement;
   
    void Start()
    {
     
        activeComportement = GetComponent<ActiveComportement>();
        destination = destination== Vector3.zero ? transform.position : destination;
        directionOfDeplacement = activeComportement.directionOfDeplacement;
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
        if(transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        else
        {
            destination = transform.position + (directionOfDeplacement.normalized * distanceDeplacement);
        }
    }
    public void MouvementLineStart(float distanceMvt, float direction)
    {
        destination = transform.position + (new Vector3(0, 0, direction).normalized * distanceMvt);
    }
}
