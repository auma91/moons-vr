using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GhostBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject powerUpControl;
    public GameObject exitButton;
    public int count;
    public int killed = 0;
    private int roundNumber;
    public float time;
    public float startPos;
    public float globalGhostSpeed = 2f;
    public Text killCount;
    public Text roundCount;
    public Text nextRoundText;
    public Text gameLost;
    public AudioClip SoundToPlay;
    AudioSource audio;
    private bool inRound;
    private bool startRound;
    private bool gameOver;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        inRound = false;
        startRound = false;
        gameOver = false;
        startPos = 10.25f;
        nextRound();
    }

    public void startFirstRound() {
        startRound = true;
    }

    public void PlaySound() { audio.PlayOneShot(SoundToPlay); }
    public void Killed() { if (!gameOver) { PlaySound(); killed++; killCount.text = "Killed: " + killed.ToString(); } }
    public void DestroyCount() { count-=1; }
    public int RandomSign() {
        return Random.value < .5 ? 1 : -1;
    }
    void nextRound() {
        //in the next round the ghost can spawn closer to you
        startPos -= (startPos >= 0) ? 0.25f: 0;
        inRound = false;
        roundNumber += 1;
        time = 0f;
        globalGhostSpeed = 2f;
        float val = Random.value;
        Debug.Log(val);
        if (val >= 0.4f) {
            if (val >= 0.7f) {
                powerUpControl.GetComponent<powerupgennerator>().makePowerUp(1);
            }
            else { powerUpControl.GetComponent<powerupgennerator>().makePowerUp(0); }
        }
    }

    public void gameLostfunc() {
        inRound = false;
        gameOver = true;
        killCount.text = "";
        roundCount.text = "";
        nextRoundText.text = "";
        gameLost.text = "The Ghosts got you!";
        exitButton.SetActive(true);
    }

    void makeGhost() {
        var child = Instantiate(prefab, new Vector3(RandomSign() * Random.Range(startPos, 29f), 1.15f, RandomSign() * Random.Range(startPos, 30.0f)), Quaternion.identity, transform.parent);
        //Make a ghost real quick
        child.transform.SetParent(transform);

        child.GetComponent<instantiate>().setGhostSpeed(globalGhostSpeed);
        //set parent atriibutes
        count++;
        //adjust count
        time = 0f;
        //reset timer
    }
    // Update is called once per frame
    void Update()
    {
        if (inRound)
        {
            //Debug.Log(count + " " + Random.value);
            if (count == 0)
            {
                //Round is over
                nextRound();
            }
            else{
                time += Time.deltaTime;
                if (count < 2 && Random.value > 0.7 && time >= 7f)
                {
                    makeGhost();
                }
            }
        }
        else {
            if (startRound && !gameOver) {
                if (time >= 3f)
                {
                    //3 second buffer to get to next round
                    inRound = true;
                    makeGhost();
                    makeGhost();
                    nextRoundText.text = "";
                    roundCount.text = "Round: " + roundNumber.ToString();
                }
                else
                {
                    time += Time.deltaTime;
                    roundCount.text = "";
                    nextRoundText.text = "Round " + roundNumber.ToString() + " starting in " + (3 - (int)time).ToString();

                }
            }
        }

    }
}
