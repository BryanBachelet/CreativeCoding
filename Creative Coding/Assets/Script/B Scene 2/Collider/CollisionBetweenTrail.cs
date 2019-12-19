using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBetweenTrail : MonoBehaviour
{
    public GameObject trail;

    private TrailMove trailBehavior;
    private ManagerTrailBehavior manager;
  

    

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Trail")
        {
            if (other.transform.parent != transform.parent)
            {
               
                trailBehavior = trail.GetComponent<TrailMove>();
                manager = trail.GetComponent<ManagerTrailBehavior>();

                TrailMove moveOther = other.GetComponent<TrailMove>();
                ManagerTrailBehavior managerTrailBehaviorOther = other.GetComponent<ManagerTrailBehavior>();

                for (int i = 0; i <manager.beheviorLine.Count; i++)
                {
                    managerTrailBehaviorOther.beheviorLine.Add(manager.beheviorLine[i]);
                    if(manager.beheviorLine[i] == 2)
                    {
                       int j = manager.CheckRotation(i);
                        moveOther.rotateProprios.Add(trailBehavior.rotateProprios[j]);
                    }

                }


            }
        }
    }
}
