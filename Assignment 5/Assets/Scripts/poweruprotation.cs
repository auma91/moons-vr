using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poweruprotation : MonoBehaviour
{
    public float RotationSpeed= 25f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-1, -1, 0) * (RotationSpeed * Time.deltaTime));
    }

}
