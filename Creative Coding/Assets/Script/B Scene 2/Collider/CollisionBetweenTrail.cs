using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBetweenTrail : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Trail")
        {
            if (other.transform.parent != transform.parent)
            {  
          
                Destroy(other.gameObject);
            }
        }
    }
}
