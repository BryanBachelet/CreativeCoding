using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTexture : MonoBehaviour
{
    public int CameraWidth;
    public int CameraHeaight;

    public Texture2D myText;
    // Start is called before the first frame update
    void Start()
    {
        CameraWidth = Camera.main.pixelWidth;
        CameraHeaight = Camera.main.pixelHeight;
        myText = new Texture2D(CameraWidth, CameraHeaight, TextureFormat.ARGB32, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateText()
    {
        //olor[] = getpi
    }
}
