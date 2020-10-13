using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start;
    public GameObject colorPicker;
    public GameObject spotLight;
    public GameObject pointLight;
    void Start()
    {
        
    }

    public void clickPlay() {
        start.SetActive(false);
        colorPicker.SetActive(true);
    }

    public void clickStart() {
        colorPicker.SetActive(false);
        spotLight.SetActive(true);
        pointLight.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
