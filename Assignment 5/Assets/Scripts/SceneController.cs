using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start;
    public GameObject colorPicker;
    public GameObject spotLight;
    public GameObject pointLight;
    public GameObject VRReticle;
    void Start()
    {
        var VRRenderer = VRReticle.GetComponent<Renderer>();
        Color reticle = new Color(PlayerPrefs.GetFloat("ThemeRed", 0), PlayerPrefs.GetFloat("ThemeGreen", 0), PlayerPrefs.GetFloat("ThemeBlue", 0), PlayerPrefs.GetFloat("ThemeAlpha", 1f));
        VRRenderer.material.SetColor("_Color", reticle);
    }

    public void clickPlay() {
        start.SetActive(false);
        colorPicker.SetActive(true);
    }

    public void clickStart() {
        SceneManager.LoadScene("Scene2");
    }

    public void clickStop() { Application.Quit(); }
    // Update is called once per frame
    void Update()
    {
        
    }
}
