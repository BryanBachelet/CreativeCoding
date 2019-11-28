using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputMouse : MonoBehaviour
{
    public float tempsMoveZoom = 2f;
    public RessourceSystem currentCity;
    float heighScreen;

    public Text cultiText;
    public Text marchandText;
    public Text protecteurText;
    public Text religionText;
    public Text totalPopul;

    public bool zoom = false;
    // Start is called before the first frame update
    void Start()
    {
        heighScreen = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        cultiText.text = ("" + currentCity.cultivateurpopul + " /" + (currentCity.cultivateurpopul * 100 / currentCity.currentPopul) + "%");
        marchandText.text = ("" + currentCity.marchandPopul + " /" + (currentCity.marchandPopul * 100 / currentCity.currentPopul) + "%");
        protecteurText.text = ("" + currentCity.protectionPopul + " /" + (currentCity.protectionPopul * 100 / currentCity.currentPopul) + "%");
        religionText.text = ("" + currentCity.religionPopul + " /" + (currentCity.religionPopul * 100 / currentCity.currentPopul) + "%");
        totalPopul.text = ("" + currentCity.currentPopul);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1<<10))
                {
                    Debug.DrawRay(Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction * hit.distance, Color.red);
                    currentCity = hit.collider.GetComponent<RessourceSystem>();
                    Debug.Log(Vector3.Distance(Camera.main.transform.position, currentCity.transform.position));
                    zoom = true;
                }
            }
            
        }
        if(zoom)
        {
            if (Vector3.Distance(Camera.main.transform.position, currentCity.transform.position) > currentCity.currentRadius*3)
            {
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, currentCity.transform.position, tempsMoveZoom);
            }
            else
            {
                zoom = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 10;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1;
        }
    }

    
    public void ClicOnCity()
    {

    }
}
