using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Reference to the GameManager script
    private GameManager gameManager;
    private Rigidbody targetRb;
    public ParticleSystem explosionParticle;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        // Find the GameManager script and assign it to the gameManager variable
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),  ForceMode.Impulse);
        transform.position = RandomSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            // When the target is clicked, update the score by the point value
            gameManager.UpdateScore(pointValue);
            // Instantiate the explosion particle effect
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        // If the target is not tagged as "Bad", end the game
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
}
