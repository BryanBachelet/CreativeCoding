using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBetweenTrail : MonoBehaviour
{
    public GameObject trail;
    public GameObject particule;

    private TrailMove trailBehavior;
    private ManagerTrailBehavior manager;

    public bool add;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trail")
        {
            if (trail == null || other.gameObject == trail)
            {
                Instantiate(particule, other.transform.position, Quaternion.identity);
            }

            trail = other.gameObject;

            if (other.transform.parent != transform.parent)
            {
               
                trailBehavior = trail.GetComponent<TrailMove>();
                manager = trail.GetComponent<ManagerTrailBehavior>();

                TrailMove moveOther = other.GetComponent<TrailMove>();
                ManagerTrailBehavior managerTrailBehaviorOther = other.GetComponent<ManagerTrailBehavior>();

                for (int i = 0; i < manager.beheviorLine.Count; i++)
                {
                    add = true;
                    if (manager.beheviorLine[i] == 2)
                    {
                        if (moveOther.rotateProprios.Count > 0)
                        {
                           

                            for (int f = 0; f < moveOther.rotateProprios.Count; f++)
                            {
                              
                                int j = manager.CheckRotation(i);
                                if (moveOther.rotateProprios[f].radius == trailBehavior.rotateProprios[j].radius)
                                {
                                    
                                    add = false;
                                  
                                }
                            }
                        }
                       
                        if (add)
                        {
                          
                            int j = manager.CheckRotation(i);
                            moveOther.rotateProprios.Add(trailBehavior.rotateProprios[j]);
                            managerTrailBehaviorOther.beheviorLine.Add(manager.beheviorLine[i]);
                        }
                    }
                    if (manager.beheviorLine[i] < 2)
                    {
                        for (int k = 0; k < managerTrailBehaviorOther.beheviorLine.Count; k++)
                        {
                            if (manager.beheviorLine[i] == managerTrailBehaviorOther.beheviorLine[k])
                            {
                               
                                add = false;
                               
                            }
                        }
                        if (add)
                        {
                            managerTrailBehaviorOther.beheviorLine.Add(manager.beheviorLine[i]);
                        }
                    }

                }
            }
        }
    }
}
