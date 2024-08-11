using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // Reference to the score text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        scoreText.text = "Score: " + score;
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to end the game
    public void GameOver()
    {
        isGameActive = false;
        Debug.Log("Game Over");
        gameOverText.gameObject.SetActive(true);
    }

    // Coroutine to spawn targets
    IEnumerator SpawnTarget()
    {
        // Temporary loop to spawn targets
        while (isGameActive)
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
