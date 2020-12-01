using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupgennerator : MonoBehaviour
{
    public GameObject slowdown;
    public GameObject wipeout;
    public GameObject GhostController;
    public float startPos = 10.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int RandomSign()
    {
        return Random.value < .5 ? 1 : -1;
    }
    public void makePowerUp(int type)
    {
        var child = (type==0) ? Instantiate(slowdown, new Vector3(RandomSign() * Random.Range(startPos, 13f), 0.4f, RandomSign() * Random.Range(startPos, 15.0f)), Quaternion.identity, transform.parent) : Instantiate(wipeout, new Vector3(RandomSign() * Random.Range(startPos, 13f), 0.4f, RandomSign() * Random.Range(startPos, 15.0f)), Quaternion.identity, transform.parent);
        //Make a ghost real quick
        child.transform.SetParent(transform);
        child.GetComponent<powerupcontroller>().GhostController = GhostController;
        //set parent atriibutes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
