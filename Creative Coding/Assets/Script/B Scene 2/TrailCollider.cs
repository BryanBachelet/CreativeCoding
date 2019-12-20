using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollider : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private ActiveComportement active;
    public GameObject boxCollider;

    public float directionDiff;
    public int currentVerticeNumber;
    private Vector3 previousDirection;
    private int previousVertex;
    private GameObject previousCollider;

    [Header("Misc")]
    public int countVertices;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        active = GetComponent<ActiveComportement>();
    }

    void Update()
    {
        if (active.isWorking)
        {
            SetCollider();
        }
    }

    public void SetCollider()
    {
        Vector3[] vertices = new Vector3[trailRenderer.positionCount];
        countVertices = trailRenderer.positionCount;
        trailRenderer.GetPositions(vertices);

        if (vertices.Length > 1)
        {
            if (currentVerticeNumber < vertices.Length - 2)
            {
                Vector3 direction = vertices[currentVerticeNumber + 1] - vertices[currentVerticeNumber];
                float distance = Vector3.Distance(vertices[currentVerticeNumber], vertices[currentVerticeNumber + 1]);
                float angle = 0;


                if (currentVerticeNumber != 0)
                {
                    float angleDir = Vector3.Angle(previousDirection.normalized, direction.normalized);
                    if (angleDir <10f)
                    {
                        direction = vertices[currentVerticeNumber + 1] - vertices[previousVertex];
                        distance = Vector3.Distance(vertices[previousVertex], vertices[currentVerticeNumber + 1]);
                       
                        angle = Vector3.SignedAngle(previousCollider.transform.forward, direction.normalized, Vector3.up);
                      
                        previousCollider.transform.position = transform.TransformVector(vertices[previousVertex] + direction.normalized * distance / 2);

                        previousCollider.transform.eulerAngles += new Vector3(0, angle, 0);
                        BoxCollider box = previousCollider.GetComponent<BoxCollider>();
                        box.size = new Vector3(1, 1, distance);

                        previousDirection = direction;
                        currentVerticeNumber++;
                    }
                    else
                    {
                        SpawnCollider(vertices, distance, direction, angle);
                    }
                }
                else
                {

                    SpawnCollider(vertices, distance, direction, angle);
                }


            }
        }
    }

    public void SpawnCollider(Vector3[] vertices, float distance, Vector3 direction, float angle)
    {
        GameObject collider = Instantiate(boxCollider, transform.TransformVector(vertices[currentVerticeNumber] + direction.normalized * distance / 2), Quaternion.identity, transform.parent);
        collider.GetComponent<CollisionBetweenTrail>().trail = gameObject;
        BoxCollider box = collider.GetComponent<BoxCollider>();
        box.size = new Vector3(1, 1, distance);
        angle = Vector3.SignedAngle(collider.transform.forward, direction.normalized, Vector3.up);

        collider.transform.eulerAngles = new Vector3(0, angle, 0);

        previousCollider = collider;
        previousVertex = currentVerticeNumber;
        previousDirection = direction;
        currentVerticeNumber++;
    }
}
