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
    public bool add2;



    private void OnTriggerEnter(Collider other)
    {
        add = true;
        if (other.tag == "Trail")
        {

            if (other.transform.parent != transform.parent)
            {

                trailBehavior = trail.GetComponent<TrailMove>();
                manager = trail.GetComponent<ManagerTrailBehavior>();

                TrailMove moveOther = other.GetComponent<TrailMove>();
                ManagerTrailBehavior managerTrailBehaviorOther = other.GetComponent<ManagerTrailBehavior>();

                for (int i = 0; i < managerTrailBehaviorOther.hitGameObject.Count; i++)
                {
                    if (managerTrailBehaviorOther.hitGameObject[i] == trail)
                    {
                        add = false;
                    }

                }



                if (add)
                {
                   

                    managerTrailBehaviorOther.hitGameObject.Add(trail);
                    for (int i = 0; i < manager.beheviorLine.Count; i++)
                    {

                        if (manager.beheviorLine[i] == 2)
                        {
                            int j = manager.CheckRotation(i);
                            moveOther.rotateProprios.Add(trailBehavior.rotateProprios[j]);
                            managerTrailBehaviorOther.beheviorLine.Add(manager.beheviorLine[i]);
                        }
                        if (manager.beheviorLine[i] < 2 || manager.beheviorLine[i]>2)
                        {
                            managerTrailBehaviorOther.beheviorLine.Add(manager.beheviorLine[i]);

                        }

                    }
                }
            }
        }
    }
}
