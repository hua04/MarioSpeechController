using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab; // sprite itself
    public Transform[] lanes; // amount of lanes (4)

    public float spawnInterval = 1f; // interval between spawning sprites
    private float spawnTimer = 0f;

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
        }
    }

    void ButtonPressSpeech()
    {

    }
}
