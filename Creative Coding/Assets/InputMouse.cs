using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputMouse : MonoBehaviour
{
    public RessourceSystem currentCity;
    float heighScreen;

    public Text cultiText;
    public Text marchandText;
    public Text protecteurText;
    public Text religionText;
    public Text totalPopul;
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
                }
            }
            
        }
    }

    
    public void ClicOnCity()
    {

    }
}
