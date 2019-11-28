using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMouvement : MonoBehaviour
{
    public float speed;
    public Vector3 destination;
    public Vector3 middleDestination;
    public bool visible = true;
    public TrailRenderer rend;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    public int i = 0;
    public Vector3 direction;
    public float distance;
    public bool rotating;
    public float rotate;
    private Vector3 startPos;
    private Vector3 rotatePos;
    public float checkdist;
    public Material first;
    public int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        rend = GetComponent<TrailRenderer>();
        gradient = new Gradient();
        Color color = new Color(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        Material mat = new Material(first);
        mat.color = color * 5;
        mat.SetFloat("_EmissionEnabled", 1);
        mat.SetVector("_EmissionColor", color * 15);

        rend.material = mat;
        rend.colorGradient = gradient;


    }

    // Update is called once per frame
    void Update()
    {


        if (visible)
        {
            if (i == 0)
            {
                if (transform.position != destination)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                }
                else
                {
                    destination = transform.position + new Vector3(Random.Range(-1, 0), 0, 0).normalized * 20;
                }
            }
            if (i == 1)
            {
                if (transform.position != destination)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                }
                else
                {
                    destination = transform.position + new Vector3(Random.Range(-1, 0), 0, Random.Range(-1, 2)) * 20;
                }
            }
            if (i == 2)
            {
                if (Vector3.Distance(transform.position, destination) > 0.5f)
                {
                    float dis = Vector3.Distance(transform.position, destination);
                    Debug.Log(dis / distance);
                    checkdist = dis / distance;
                    if (!rotating)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, middleDestination, speed * Time.deltaTime);
                    }
                    if (dis / distance <= 0.51f && !rotating)
                    {
                        rotating = true;
                        startPos = transform.position;
                        rotatePos = transform.eulerAngles;
                    }
                    if (rotating && rotate < 180)
                    {
                        rotate += 1000 * Time.deltaTime;
                        transform.RotateAround(startPos + direction.normalized * 5, transform.up, 1000 * Time.deltaTime);
                        transform.eulerAngles = rotatePos;
                    }
                    if (rotate >= 180)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                    }
                }
                else
                {
                    destination = transform.position + new Vector3(Random.Range(-1, 0), 0, Random.Range(-1, 2)).normalized * 40;
                    distance = Vector3.Distance(transform.position, destination);
                    direction = destination - transform.position;
                    middleDestination = transform.position + direction.normalized * 20;
                    rotating = false;
                    rotate = 0;

                }
            }
            if (i == 3)
            {
                if (Vector3.Distance(transform.position, destination) > 0.5f)
                {
                    float dis = Vector3.Distance(transform.position, destination);
                    Debug.Log(dis / distance);
                    checkdist = dis / distance;
                    if (!rotating)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, middleDestination, speed * Time.deltaTime);
                    }
                    if (dis / distance <= 0.51f && !rotating)
                    {
                        rotating = true;
                        startPos = transform.position;
                        rotatePos = transform.eulerAngles;
                    }
                    if (rotating && rotate < (190 + 360))
                    {
                        rotate += 1000 * Time.deltaTime;
                        transform.RotateAround(startPos + direction.normalized * 5, transform.up, 1000 * Time.deltaTime);
                        transform.eulerAngles = rotatePos;
                    }
                    if (rotate >= (190 + 360))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                    }
                }
                else
                {
                    destination = transform.position + new Vector3(Random.Range(-1, 0), 0, Random.Range(-1, 2)).normalized * 40;
                    distance = Vector3.Distance(transform.position, destination);
                    direction = destination - transform.position;
                    middleDestination = transform.position + direction.normalized * 20;
                    rotating = false;
                    rotate = 0;

                }
            }
            if (i == 4)
            {
                if (rotate < 90)
                {
                    float dis = Vector3.Distance(transform.position, destination);
                    Debug.Log(dis / distance);
                    checkdist = dis / distance;
                    if (!rotating)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                    }
                    if (transform.position == destination && !rotating)
                    {
                        rotating = true;
                        startPos = transform.position;
                        rotatePos = transform.eulerAngles;
                    }
                    if (rotating && rotate < 90)
                    {
                        rotate += 1000 * Time.deltaTime;
                        transform.RotateAround(startPos + direction.normalized * 25, transform.up, 1000 * Time.deltaTime);
                        transform.eulerAngles = rotatePos;
                    }

                }
                else
                {
                    destination = transform.position + new Vector3(Random.Range(-1, 0), 0, Random.Range(-1, 2)).normalized * 20;
                    distance = Vector3.Distance(transform.position, destination);
                    direction = destination - transform.position;
                    middleDestination = transform.position + direction.normalized * 20;
                    rotating = false;
                    rotate = 0;

                }
            }
            if (i == 5)
            {
                if (Vector3.Distance(transform.position, destination) > 0.5f)
                {
                    float dis = Vector3.Distance(transform.position, destination);
                    Debug.Log(dis / distance);
                    checkdist = dis / distance;
                    if (!rotating)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, middleDestination, speed * Time.deltaTime);
                    }
                    if (dis / distance <= 0.51f && !rotating)
                    {
                        rotating = true;
                        startPos = transform.position;
                        rotatePos = transform.eulerAngles;
                    }
                    if (rotating && rotate < (190 + 360))
                    {
                        rotate += 1000 * Time.deltaTime;
                        transform.RotateAround(startPos + direction.normalized * 5, transform.up, 1000 * Time.deltaTime);
                        transform.eulerAngles = rotatePos;
                    }
                    if (rotate >= (190 + 360) && j == 0)
                    {
                        rotate = 0;
                        
                        startPos = transform.position;
                        rotatePos = transform.eulerAngles;
                        j = 1;
                    }
                    if (rotate >= (190 + 360) && j == 1)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                    }
                }
                else
                {
                    destination = transform.position + new Vector3(Random.Range(-1, 0), 0, Random.Range(-1, 2)).normalized * 40;
                    distance = Vector3.Distance(transform.position, destination);
                    direction = destination - transform.position;
                    middleDestination = transform.position + direction.normalized * 20;
                    rotating = false;
                    rotate = 0;
                    j = 0;

                }
            }
        }

    }


}
