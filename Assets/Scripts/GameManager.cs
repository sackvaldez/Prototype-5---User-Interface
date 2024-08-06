using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // Reference to the score text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // 
        scoreText.text = "Score: " + score;
        StartCoroutine(SpawnTarget());
        gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to end the game
    public void GameOver()
    {
        Debug.Log("Game Over");
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
        }
    }

    // Method to update the score and its public so that it can be accessed from other scripts
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
