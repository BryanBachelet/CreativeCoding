using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtCercle : MonoBehaviour
{
    public float speed;
    public float distanceDeplacement;
    public float rayonCircle;
    public float angleSpeed;
    public float angleToRotate;
    private Vector3 destination;
    private ActiveComportement activeComportement;

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
                if (angleRotated > angleToRotate)
                {

                    isRotating = false;
                    destination = transform.position + (new Vector3(-1, 0, 0).normalized * (distanceDeplacement));
                }
                if (!startRotation)
                {
                    startPosRotation = transform.position;
                    startRot = transform.eulerAngles;
                    startRotation = true;
                }


                if (angleRotated < angleToRotate)
                {
                    transform.RotateAround(startPosRotation + direction.normalized * rayonCircle, transform.up, angleSpeed * Time.deltaTime);
                    transform.eulerAngles = startRot;
                    angleRotated += angleSpeed * Time.deltaTime;

                }
            }


        }
        else
        {

            destination = transform.position + (new Vector3(-1, 0, 0).normalized * (distanceDeplacement));
            direction = destination - transform.position;
            isRotating = false;
            startRotation = false;
            angleRotated = 0;
        }
    }
}


