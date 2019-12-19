using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTrailBehavior : MonoBehaviour
{
    public List<int> beheviorLine;
    private int currentMove;
    private TrailMove trailMove;
    private ActiveComportement active;
    void Start()
    {
        trailMove = GetComponent<TrailMove>();
        currentMove = Random.Range(0, beheviorLine.Count);
        active = GetComponent<ActiveComportement>();
        CheckRotationChain();
    }
   

    public void CheckRotationChain()
    {
        for (int i = 0; i < beheviorLine.Count; i++)
        {
            if(beheviorLine[i] == 2)
            {
                trailMove.GenerateRotateStart();
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (active.isWorking)
        {

            switch (beheviorLine[currentMove])
            {
                case 0:

                    if (!trailMove.Line())
                    {
                        currentMove = Random.Range(0, beheviorLine.Count);

                    }

                    break;
                case 1:

                    if (!trailMove.LineRotate())
                    {
                        currentMove = Random.Range(0, beheviorLine.Count);

                    }
                    break;
                case 2:
                    int j = CheckRotation(currentMove);
                    if (!trailMove.Rotate(j))
                    {
                        currentMove = Random.Range(0, beheviorLine.Count);

                    }
                    break;
            }

        }
        
    }

  public  int CheckRotation( int currrent)
    {
        int k = -1;

        for (int i = 0; i < currrent + 1; i++)
        {
            if(beheviorLine[i] == 2)
            {
                k++;
            }
        }


        return k;
    }
  
}
