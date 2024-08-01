using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // Reference to the score text
    public TextMeshProUGUI scoreText;
    private float spawnRate = 1.0f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // 
        scoreText.text = "Score: " + score;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to spawn targets
    IEnumerator SpawnTarget()
    {
        // Temporary loop to spawn targets
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            // Randomly select a target from the list and instantiate it
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(5);
        }
    }

    // Method to update the score
    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
