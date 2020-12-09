using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChoser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chooseLagoon() {SceneManager.LoadScene(2); }
    public void chooseForest() {
        SceneManager.LoadScene(1);
    }
}
