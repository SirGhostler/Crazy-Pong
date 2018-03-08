using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    #region Singleton Attempt

    //After Awake
    public static GameSettingsManager Instance;
    
    /// <summary>
    /// Make sure nothing else is on the Awake call if calling for a reference of this.
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region Game Settings

        public GameObject soundManager = null;  

        public GameObject PlayerOneScoreDisplay = null;

        public GameObject PlayerTwoScoreDisplay = null;

        public enum RotationDirection
        {
            CLOCKWISE,
            ANTI_CLOCKWISE
        }
 
        public RotationDirection rotationDirection;

        [Range(0.0f, 20.0f)]
        public float levelRotationSpeed = 0.0f;

        [Range(0.0f, 20.0f)]
        public float levelRotationIncreaseAmount = 0.0f;

        [Range(0.0f, 100.0f)]
        public float objectMovementSpeed = 0.0f;

    #endregion

    #region Player One

        public KeyCode playerOneLeft = KeyCode.A;
    
        public KeyCode playerOneRight = KeyCode.D;
     
        [Range(0.0f, 10.0f)]
        public int playerOneScore = 0;

    #endregion

    #region Player Two
    
        public KeyCode playerTwoLeft = KeyCode.Keypad4;
    
        public KeyCode playerTwoRight = KeyCode.Keypad6;
          
        [Range(0.0f, 10.0f)]
        public int playerTwoScore = 0;

    #endregion

    #region Pong Ball

        public GameObject pongBallObject = null;

        [Range(0.0f, 100.0f)]
        public float pongBallMovementSpeed = 0.0f;

    #endregion

}
