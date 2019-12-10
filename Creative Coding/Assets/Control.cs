using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject myCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            myCube.transform.Rotate(myCube.transform.right, 15 * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myCube.transform.Rotate(-myCube.transform.right, 15 * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myCube.transform.Rotate(myCube.transform.up, 15 * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myCube.transform.Rotate(-myCube.transform.up, 15 * Time.deltaTime);
            }
        }
    }

}
