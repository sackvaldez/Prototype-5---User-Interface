using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    // Variable to store the difficulty level
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();   
        // Add a listener to the button so that when it is clicked, the SetDifficulty method is called
        button.onClick.AddListener(SetDifficulty);
        // Find the Game Manager object and get the GameManager component
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        // Call the StartGame method from the GameManager and pass in the difficulty level
        gameManager.StartGame(difficulty);
        // Debug.Log(gameObject.name + " was clicked");
    }
}
