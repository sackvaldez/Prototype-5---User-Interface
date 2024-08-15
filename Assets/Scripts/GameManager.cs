using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// SceneManagement it is a library that allows us to manage scenes in Unity
using UnityEngine.SceneManagement;
// UI is a library that allows us to access the UI elements in Unity
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // Reference to the score text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    private float spawnRate = 1.0f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {

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
        // Set the restart button to be active
        restartButton.gameObject.SetActive(true);
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

    public void StartGame(){
        isGameActive = true;
        score = 0;
        scoreText.text = "Score: " + score;
        StartCoroutine(SpawnTarget());
    }
}
