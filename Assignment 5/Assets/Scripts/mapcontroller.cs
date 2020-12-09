using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mapcontroller : MonoBehaviour
    
{
    public Text text;
    public Text text1;
    public Text text2;
    public Text text3;
    public GameObject VRReticle;

    // Start is called before the first frame update
    void Start()
    {
        Color theme = new Color(PlayerPrefs.GetFloat("ThemeRed", 0), PlayerPrefs.GetFloat("ThemeGreen", 0), PlayerPrefs.GetFloat("ThemeBlue", 0), PlayerPrefs.GetFloat("ThemeAlpha", 1f));
        text.color = theme;
        text1.color = theme;
        text2.color = theme;
        text3.color = theme;
        var VRRenderer = VRReticle.GetComponent<Renderer>();
        VRRenderer.material.SetColor("_Color", theme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitApp() { Application.Quit(); }

}
