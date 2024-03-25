using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab; // sprite itself
    public Transform[] lanes; // amount of lanes (4)

    public float spawnInterval = 1f; // interval between spawning sprites
    private float spawnTimer = 0f;

    public Transform yellowHit;
    public Transform redHit;
    public Transform blueHit;
    public Transform greenHit;

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

    void Update()
    {
        spawnTimer += Time.deltaTime;

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

      
            foreach (GameObject clone in spawnedSprites)
            {
            if (clone != null)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {

                    if (Vector2.Distance(clone.transform.position, yellowHit.position) < 0.8f)
                    {
                        Yscore += 2;
                        Debug.Log("Yellow, A");
                        Destroy(clone);
                    }
                }


                if (Input.GetKeyDown(KeyCode.S))
                {

                    if (Vector2.Distance(clone.transform.position, redHit.position) < 0.8f)
                    {
                        Rscore += 2;
                        Debug.Log("Red, S");
                        Destroy(clone);
                    }
                }

                if (Input.GetKeyDown(KeyCode.D))
                {

                    if (Vector2.Distance(clone.transform.position, blueHit.position) < 0.8f)
                    {
                        Bscore += 2;
                        Debug.Log("Blue, D");
                        Destroy(clone);
                    }
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (Vector2.Distance(clone.transform.position, greenHit.position) < 0.8f)
                    {
                        Gscore += 2;
                        Debug.Log("Green, F");
                        Destroy(clone);
                    }
                }
              
            }
        }

        YscoreText.text = "Y: " + Yscore + "%";
        RscoreText.text = "R: " + Rscore + "%";
        BscoreText.text = "B: " + Bscore + "%";
        GscoreText.text = "G: " + Gscore + "%";
        totalScore = Gscore + Bscore + Rscore + Yscore;
        avgScore = totalScore / 4;
        Debug.Log(avgScore);
    }
}
