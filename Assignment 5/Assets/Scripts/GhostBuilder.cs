using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GhostBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public int count;
    public int killed = 0;
    public float time;
    public Text txt;
    void Start()
    {

    }
    public void Killed() { killed++; txt.text = "Killed: " + killed.ToString(); }
    public void DestroyCount() { count-=1; }
    public int RandomSign() {
        return Random.value < .5 ? 1 : -1;
    }
// Update is called once per frame
void Update()
    {
        Debug.Log(count);
        if (count < 2 && Random.value > 0.7 && time > 3)
        {
            var child = Instantiate(prefab, new Vector3(RandomSign()*Random.Range(10f, 29f), 1.15f, RandomSign()*Random.Range(10f, 30.0f)), Quaternion.identity, transform.parent);
            child.transform.SetParent(transform);
            count++;
            time = 0f;
        }
        else { time += Time.deltaTime; }
        if (count == 0)
        {
            var child = Instantiate(prefab, new Vector3(RandomSign()*Random.Range(10f, 29f), 1.15f, RandomSign()*Random.Range(10f, 30.0f)), Quaternion.identity, transform.parent);
            child.transform.SetParent(transform);
            count++;
            time = 0f;
        }
        else { time += Time.deltaTime; }

    }
}
