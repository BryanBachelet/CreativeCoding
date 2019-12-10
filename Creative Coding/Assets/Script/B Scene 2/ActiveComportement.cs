using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveComportement : MonoBehaviour
{
    public bool isWorking= true;
    [HideInInspector] public int j;
    public Vector3 directionOfDeplacement;
    private void Start()
    {
        if (j == 0)
        {
            directionOfDeplacement = Vector3.right;
        }
        if(j==1)
        {
            directionOfDeplacement = -Vector3.right;
        }
        if(j == 2)
        {
            directionOfDeplacement = Vector3.forward;
        }
        if (j == 3)
        {
            directionOfDeplacement = -Vector3.forward;
        }
    }

}
