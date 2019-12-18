using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtDemiCercle : MonoBehaviour
{
    public float speed;
    public float distanceDeplacement;
    public float rayonCircle;
    public float angleSpeed;
    public float angleToRotate;

    private Vector3 directionOfDeplacement;
    private Vector3 destination;
    private ActiveComportement activeComportement;

    private float currentAngleSpeed;
    private float distance;
    private Vector3 direction;
    private bool isRotating = false;
    private bool startRotation = false;
    private Vector3 startPosRotation = Vector3.zero;
    private Vector3 startRot = Vector3.zero;
    private float angleRotated;

    void Start()
    {
        activeComportement = GetComponent<ActiveComportement>();
        destination = destination == Vector3.zero ? transform.position : destination;
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
        if (transform.position != destination)
        {
            distance = Vector3.Distance(transform.position, destination);

            if (distance / (distanceDeplacement) < 0.5f && angleRotated < angleToRotate)
            {
                isRotating = true;
            }
            if (!isRotating)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            }

            if (isRotating)
            {
                if (angleRotated >= angleToRotate)
                {

                    isRotating = false;
                    destination = transform.position + (directionOfDeplacement.normalized * (distanceDeplacement));
                }
                if (!startRotation)
                {
                    startPosRotation = transform.position;
                    startRot = transform.eulerAngles;
                    startRotation = true;
                }

                float nextAngleRotated = angleRotated;
                nextAngleRotated += angleSpeed * Time.deltaTime;
                if (nextAngleRotated > angleToRotate)
                {
                    float frameTime = Time.deltaTime;
                    currentAngleSpeed = ((angleToRotate- angleRotated));
                    currentAngleSpeed/= frameTime;
                    Debug.Log("Speed = " + currentAngleSpeed);
                    angleRotated += currentAngleSpeed * Time.deltaTime;
                }
                else
                {
                    currentAngleSpeed = angleSpeed  ;
                    angleRotated += currentAngleSpeed * Time.deltaTime;
                }
                if (angleRotated < angleToRotate)
                {

                    transform.RotateAround(startPosRotation + direction.normalized * rayonCircle, transform.up, currentAngleSpeed *Time.deltaTime);
                    transform.eulerAngles = startRot;

                }
            }


        }
        else
        {

            destination = transform.position + (directionOfDeplacement.normalized * (distanceDeplacement));
            direction = destination - transform.position;
            isRotating = false;
            startRotation = false;
            angleRotated = 0;
        }
    }
}
