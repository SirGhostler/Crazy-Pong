using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoScoreManager : MonoBehaviour {

    // Get instance of gameSettings
    private GameSettingsManager gameSettings = null;

    // Get instance of soundManager
    private SoundManager soundManagerRef;

    // Slider for the Player's score
    [SerializeField]
    [Tooltip("Slider for the Player's score.")]
    public Slider scoreSlider;

    // Use this for initialization
    void Start()
    {
        // Get instance of gameSettings
        gameSettings = GameSettingsManager.Instance;

        // Get instance of soundManager
        soundManagerRef = gameSettings.soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the value of the slider to the Player's score
        scoreSlider.value = gameSettings.playerTwoScore;
    }

    // When collision occurs
    private void OnTriggerEnter(Collider other)
    {
        // If the collision is with an object with the PongBall tag
        if (other.tag == "PongBall")
        {
            // Increment Player score by 1
            gameSettings.playerOneScore += 1;
            gameSettings.pongBallObject.GetComponent<PongBallStart>().ResetPongBall();

            gameSettings.PlayerOneScoreDisplay.GetComponent<PlayerScoreDisplay>().UpdateScorePlayerOne(gameSettings.playerOneScore);

            soundManagerRef.Player1Score();
        }
    }
}
