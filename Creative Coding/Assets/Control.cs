using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject myCube;
    public float speedOfRotation;
    private float horizontalSave;
    private
        float verticalSave;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalSave = 0; horizontalSave = 0;
        }
        if(horizontal> 0)
        {
            horizontalSave = 1;
        }
        if(horizontal<0)
        {
            horizontalSave = -1;
        }
        if (vertical > 0)
        {
            verticalSave = 1;
        }
        if (vertical < 0)
        {
            verticalSave = -1;
        }
        myCube.transform.Rotate(Vector3.up, horizontalSave * speedOfRotation * Time.deltaTime, Space.World);
        myCube.transform.Rotate(Vector3.right, verticalSave * speedOfRotation * Time.deltaTime, Space.World);



    }

}
