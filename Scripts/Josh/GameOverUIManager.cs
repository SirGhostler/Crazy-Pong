using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour {

    // Get instance of gameSettings
    private GameSettingsManager gameSettings = null;

    // Canvas for the Game Over screen
    [SerializeField]
    [Tooltip("UI Canvas for the Game Over screen.")]
    public GameObject gameOverCanvas;

    public GameObject p1Win;
    public GameObject p2Win;
    public GameObject p1Loss;
    public GameObject p2Loss;

    // Use this for initialization
    void Start()
    {
        // Get instance of gameSettings
        gameSettings = GameSettingsManager.Instance;
        // Set Game Over canvas as inactive
        gameOverCanvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update()
    {
        // If either player reaches 10 points
		if (gameSettings.playerOneScore == 10)
        {
            // Set timeScale to 0.0f to pause gameplay
            Time.timeScale = 0.1f;
            // Set Game Over canvas as active
            gameOverCanvas.SetActive(true);

            p1Loss.SetActive(false);
            p2Loss.SetActive(true);
            p1Win.SetActive(true);
            p2Win.SetActive(false);

        }


        if (gameSettings.playerTwoScore == 10)
        {
            // Set timeScale to 0.0f to pause gameplay
            Time.timeScale = 0.1f;
            // Set Game Over canvas as active
            gameOverCanvas.SetActive(true);

            p2Loss.SetActive(false);
            p1Loss.SetActive(true);
            p2Win.SetActive(true);
            p1Win.SetActive(false);
        }
	}


    public void ChangeScene(int aSceneIndex)
    {
        SceneManager.LoadScene(aSceneIndex);
    }
}
