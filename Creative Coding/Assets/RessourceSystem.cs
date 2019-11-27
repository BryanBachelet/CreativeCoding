using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceSystem : MonoBehaviour
{
    public int currentPopul;
    public int religionPopul;
    public int protectionPopul;
    public int marchandPopul;
    public int cultivateurpopul;
    int maxReligion = 0;
    int maxProtection = 0;
    int maxMarchand = 0;
    int maxCultivateur = 0;

    public Text cultiText;
    public Text marchandText;
    public Text protecteurText;
    public Text religionText;
    public Text totalPopul;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPopul = religionPopul + protectionPopul + marchandPopul + cultivateurpopul;
        cultiText.text = ("" + cultivateurpopul + " /" + (cultivateurpopul * 100 / currentPopul) + "%");
        marchandText.text = (""+ marchandPopul + " /" + (marchandPopul * 100 / currentPopul) + "%");
        protecteurText.text = (""+ protectionPopul + " /" + (protectionPopul * 100 / currentPopul) + "%");
        religionText.text = ("" + religionPopul + " /" + (religionPopul * 100 / currentPopul) + "%");
        totalPopul.text = ("" + currentPopul);
    }
}
