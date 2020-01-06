using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMove : MonoBehaviour
{

    [HideInInspector] public bool getDestination;
    private Vector3 directionOfDeplacement;
    private Vector3 destination;
    public float speedForward = 100;
    public float distanceOfMouvement;
    private bool firstDestination;


    private bool inRotate;
    private float angleRotated;
    public float angularSpeed = 360;
    private Vector3 startPos;
    private Vector3 startRot;

    public List<RotateProprio> rotateProprios = new List<RotateProprio>(0);
    int interation = 0;
    Vector3
        startPoint;

    [System.Serializable]
    public struct RotateProprio
    {
        public float angleToRotate;
        public float radius;

    }


    public void GenerateRotateStart()
    {
        RotateProprio rotates = new RotateProprio();
        rotates.angleToRotate = Random.Range(90, 360);
        rotates.radius = Random.Range(10, 50f);
        rotateProprios.Add(rotates);
    }


    private void Start()
    {
        directionOfDeplacement = GetComponent<ActiveComportement>().directionOfDeplacement;
        startPoint = transform.position;
    }
    private void Update()
    {
        Debug.DrawLine(startPoint, transform.position, Color.white);
    }




    public bool Line()
    {
        if (!getDestination)
        {
            Destination(distanceOfMouvement);
            getDestination = true;
        }

        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            getDestination = false;
            return false;
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, destination, speedForward * Time.deltaTime);

            return true;
        }
    }

    public bool SinLine()
    {
        if (!getDestination)
        {
            Destination(distanceOfMouvement * 5);
            getDestination = true;
        }

        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            getDestination = false;
            return false;
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, destination, speedForward * Time.deltaTime);
            if (Vector3.Distance(transform.position, destination) > 3f)
            {
                
                if (Mathf.Abs(directionOfDeplacement.z) == 1)
                {
                    transform.position += new Vector3(Mathf.Sin(Time.time * 50) * 15, 0, 0);
                }
                else
                {
                    transform.position += new Vector3(0, 0, Mathf.Sin(Time.time * 50) * 15);
                }
            }


            return true;
        }
    }

    public bool ZigZagLine()
    {
        if (!getDestination)
        {
            if (interation == 0)
            {
                DestinationZigZag(distanceOfMouvement, 45);
            }
            if (interation == 1)
            {
                DestinationZigZag(distanceOfMouvement, -45);
            }
            getDestination = true;
        }
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            interation++;
            getDestination = false;
            if (interation > 1)
            {
                interation = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speedForward * Time.deltaTime);
            return true;
        }
    }
    public bool LineRotate()
    {
        if (!getDestination)
        {
            if (firstDestination)
            {
                ChangeDirection();
            }
            Destination(distanceOfMouvement);
            getDestination = true;
        }

        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            getDestination = false;
            return false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speedForward * Time.deltaTime);
            return true;
        }
    }


    public bool Rotate(int i)
    {
        if (!getDestination)
        {
            Destination(distanceOfMouvement);
            getDestination = true;
        }

        if (!inRotate)
        {
            if (Vector3.Distance(transform.position, destination) < 1f)
            {
                if (angleRotated > rotateProprios[i].angleToRotate)
                {
                    angleRotated = 0;
                    return false;
                }
                else
                {
                    inRotate = true;
                    startPos = transform.position;
                    startRot = transform.eulerAngles;
                    return true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speedForward * Time.deltaTime);
                return true;
            }
        }
        else
        {
            if (angleRotated < rotateProprios[i].angleToRotate)
            {
                transform.RotateAround(startPos + directionOfDeplacement.normalized * rotateProprios[i].radius, transform.up, angularSpeed * Time.deltaTime);
                transform.eulerAngles = startRot;
                angleRotated += angularSpeed * Time.deltaTime;
            }
            else
            {
                //transform.position = (startPos + directionOfDeplacement.normalized * radius) +  Quaternion.Euler(0, angleToRotate, 0) * startPos;
                transform.eulerAngles = startRot;
                Destination(distanceOfMouvement);
                inRotate = false;
            }
            return true;

        }
    }

    public void ChangeDirection()
    {

        int i = Random.Range(0, 2);
       
        if (i == 0)
        {
            directionOfDeplacement = Quaternion.Euler(0, 90, 0) * directionOfDeplacement;
            
        }
        else
        {
            directionOfDeplacement = Quaternion.Euler(0, -90, 0) * directionOfDeplacement;
            
        }

    }

    public void Destination(float distance)
    {
        destination = transform.position + (directionOfDeplacement * distance);
        firstDestination = true;
    }
    public void DestinationZigZag(float distance, float angle)
    {
        destination = transform.position + ((Quaternion.Euler(0f, angle, 0f) * directionOfDeplacement) * distance);
    }



}
