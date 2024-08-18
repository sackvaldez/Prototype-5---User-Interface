using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TextMeshPro is a library that allows us to use TextMeshPro in Unity
using TMPro;
// SceneManagement it is a library that allows us to manage scenes in Unity
using UnityEngine.SceneManagement;
// UI is a library that allows us to access the UI elements in Unity
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // We need to store the targets in a list of GameObjects so that we can randomly select them
    public List<GameObject> targets;
    // Reference to the score text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
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

    // This method will start the game and it will take a difficulty parameter to adjust the spawn rate
    public void StartGame(int difficulty){
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        score = 0;
        scoreText.text = "Score: " + score;
        StartCoroutine(SpawnTarget());
    }
}
