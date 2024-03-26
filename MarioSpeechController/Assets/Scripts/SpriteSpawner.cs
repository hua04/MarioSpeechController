using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public AudioCheck audioCheck;
    public AudioControl audioControl;

    public GameObject spritePrefab; // sprite itself
    public Transform[] lanes; // amount of lanes (4)

    public float spawnInterval = 1f; // interval between spawning sprites
    private float spawnTimer = 0f;
    public SpriteRenderer peachSprite;
    public Sprite talking;
    public Sprite notTalking;

    public Transform yellowHit;
    public Transform redHit;
    public Transform blueHit;
    public Transform greenHit;

    public bool yellowOn;
    public bool redOn;
    public bool blueOn;
    public bool greenOn;

    private List<GameObject> spawnedSprites = new List<GameObject>();

    public int Yscore = 10;
    public int Rscore = 16;
    public int Bscore = 4;
    public int Gscore = 8;
    public int totalScore;
    public int avgScore;

    public TMP_Text YscoreText;
    public TMP_Text RscoreText;
    public TMP_Text BscoreText;
    public TMP_Text GscoreText;

    public GameObject yellowSelect;
    public GameObject redSelect;
    public GameObject blueSelect;
    public GameObject greenSelect;

    void Start()
    {
        Yscore = 10;
        Rscore = 16;
        Bscore = 4;
        Gscore = 8;
        audioCheck = GameObject.Find("Arduino").GetComponent<AudioCheck>();
        audioControl = GameObject.Find("AudioControl").GetComponent<AudioControl>();
        yellowSelect.SetActive(false);
        redSelect.SetActive(false);
        blueSelect.SetActive(false);
        greenSelect.SetActive(false);
    }
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (audioControl.speaking)
        {
            peachSprite.sprite = talking;
        }
        else
        {
            peachSprite.sprite = notTalking;
        }

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            int laneIndex = Random.Range(0, lanes.Length);

            Vector3 spawnPosition = lanes[laneIndex].position;

            // spawn the sprite at the chosen lane position
            GameObject newSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = newSprite.GetComponent<Rigidbody2D>();
            rb = newSprite.AddComponent<Rigidbody2D>();

            // move the sprite upwards
            ConstantForce2D constantForce = newSprite.AddComponent<ConstantForce2D>();
            constantForce.force = Vector2.up * 15f; // adjust the force as needed

            // add the spawned sprite clone to the list
            spawnedSprites.Add(newSprite);
        }

        if (audioCheck.yellow == true)
        {
            yellowOn = true;
            redOn = false;
            blueOn = false;
            greenOn = false;
            yellowSelect.SetActive(true);
            redSelect.SetActive(false);
            blueSelect.SetActive(false);
            greenSelect.SetActive(false);

        }
        if (audioCheck.red == true)
        {
            yellowOn = false;
            redOn = true;
            blueOn = false;
            greenOn = false;
            yellowSelect.SetActive(false);
            redSelect.SetActive(true);
            blueSelect.SetActive(false);
            greenSelect.SetActive(false);

        }
        if (audioCheck.blue == true)
        {
            yellowOn = false;
            redOn = false;
            blueOn = true;
            greenOn = false;
            yellowSelect.SetActive(false);
            redSelect.SetActive(false);
            blueSelect.SetActive(true);
            greenSelect.SetActive(false);

        }
        if (audioCheck.green == true)
        {
            yellowOn = false;
            redOn = false;
            blueOn = false;
            greenOn = true;
            yellowSelect.SetActive(false);
            redSelect.SetActive(false);
            blueSelect.SetActive(false);
            greenSelect.SetActive(true);

        }

        foreach (GameObject clone in spawnedSprites)
        {
            if (clone != null)
            {
                if (yellowOn && audioControl.speaking)
                {

                    if (Vector2.Distance(clone.transform.position, yellowHit.position) < 0.8f)
                    {
                        Yscore += 4;
                        Debug.Log("Yellow, A");
                        Destroy(clone);
                    }
                }


                if (redOn == true && audioControl.speaking)
                {

                    if (Vector2.Distance(clone.transform.position, redHit.position) < 0.8f)
                    {
                        Rscore += 4;
                        Debug.Log("Red, S");
                        Destroy(clone);
                    }
                }

                if (blueOn == true && audioControl.speaking)
                {

                    if (Vector2.Distance(clone.transform.position, blueHit.position) < 0.8f)
                    {
                        Bscore += 4;
                        Debug.Log("Blue, D");
                        Destroy(clone);
                    }
                }

                if (greenOn == true && audioControl.speaking)
                {
                    if (Vector2.Distance(clone.transform.position, greenHit.position) < 0.8f)
                    {
                        Gscore += 4;
                        Debug.Log("Green, F");
                        Destroy(clone);
                    }
                }

            }
        }

        YscoreText.text = "Toad: " + Yscore + "%";
        RscoreText.text = "Cheep: " + Rscore + "%";
        BscoreText.text = "Koopa: " + Bscore + "%";
        GscoreText.text = "Goomba: " + Gscore + "%";
        totalScore = Gscore + Bscore + Rscore + Yscore;
        avgScore = totalScore / 4;
        //Debug.Log(avgScore);
    }
}
