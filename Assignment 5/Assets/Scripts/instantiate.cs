using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle;
    public float speed = 2f;
    public float hoverspeed = 2f;
    public AudioClip SoundToPlay;
    AudioSource audio;
    private float convertDeg = 180 / Mathf.PI;
    private float convertRad = Mathf.PI / 180;
    public Vector3 init;
    void Start()
    {
        init = transform.position;
        //transform.LookAt(target);
        float opposite = transform.position.x;
        float adjacent = transform.position.z;
        float hyptonenuse = Mathf.Sqrt(Mathf.Pow(opposite,2) + Mathf.Pow(adjacent, 2));
        /*if (opposite <= 0) {
            Mathf.in
        }
        else { }*/
        
        //Debug.Log(opposite + " " + adjacent);
        angle = convertDeg * Mathf.Asin(opposite/hyptonenuse);
        //Debug.Log(angle);
        if (adjacent <=0) {
            if (adjacent <= 0) { transform.localEulerAngles = new Vector3(0, -90 + (-1 * angle), 0); }
            else { transform.eulerAngles = new Vector3(0, -90 + angle, 0); }
        }
        else {
            if (adjacent <= 0) { transform.localEulerAngles = new Vector3(0, 90 + (-1 * angle), 0); }
            else { transform.eulerAngles = new Vector3(0, 90 + angle, 0); }
        }

        audio = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) <= 0.5 || Mathf.Abs(transform.position.z) <= 0.5) {
            //you lost the game 
            RemoveGhost();
            gameObject.GetComponentInParent<GhostBuilder>().gameLostfunc();
            return;
        }
        if (Mathf.Abs(transform.position.x) > 0.5 || Mathf.Abs(transform.position.z)  > 0.5) {
            Vector3 pos = new Vector3(Mathf.Sign(transform.position.x) * -1 * (speed) * Mathf.Abs(Mathf.Sin(convertRad * angle)), 0, Mathf.Sign(transform.position.z) * -1 * (speed) * Math.Abs(Mathf.Cos(convertRad * angle)));
            transform.Translate(pos * Time.deltaTime, Space.World);
        }
        Vector3 localpos = transform.localPosition;
        transform.localPosition = new Vector3(localpos.x, 0.1f * Mathf.Sin(hoverspeed * Time.time) + 0.5f, localpos.z);

    }

    public void setGhostSpeed(float speed) {
        this.speed = speed;
    }

    public void PlaySound() { audio.PlayOneShot(SoundToPlay); }
    public void RemoveGhost() {
        gameObject.GetComponentInParent<GhostBuilder>().Killed();
        gameObject.GetComponentInParent<GhostBuilder>().DestroyCount();
        GameObject.Destroy(gameObject); }
    public void Seen() { Debug.Log("Seen"); }
}
