using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsPlayerOne = true; 

    private new Rigidbody rigidbody = null;

    private GameSettingsManager gameSettings = null;

    /// <summary>
    /// Setup the rigidBody and grab an instance of the gameSettings
    /// </summary>
    private void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        
        gameSettings = GameSettingsManager.Instance;

        //Debug.Log(Vector3.Magnitude(new Vector3(0, transform.position.y, 0) - transform.position)); //11 units away from the center
    }
    
    /// <summary>
    /// Main Game Update
    /// </summary>
    private void FixedUpdate ()
    {
        transform.LookAt(new Vector3(0,transform.position.y, 0));       //Look at its relative height in x0z0

        rigidbody.AddForce(-transform.forward * gameSettings.objectMovementSpeed * 0.1f);

        #region Player One

        if (IsPlayerOne)
            {
                PlayerOneMovement();                        //Calls Player 1 movement
            }

        #endregion

        #region Player Two

            if (!IsPlayerOne)
            {
                PlayerTwoMovement();            //Calls Player 2 movement
            }

        #endregion
    }
        
    /// <summary>
    /// Handles the Player One movement.
    /// </summary>
    private void PlayerOneMovement()
    {
        if (Input.GetKey(gameSettings.playerOneLeft))
        {
            //Debug.Log("Player One Left" + rigidbody.velocity);

            rigidbody.AddForce(-transform.right * gameSettings.objectMovementSpeed);                //Moves the paddle to the left
        }

        if (Input.GetKey(gameSettings.playerOneRight))
        {
            //Debug.Log("Player One Right" + rigidbody.velocity);

            rigidbody.AddForce(transform.right * gameSettings.objectMovementSpeed);                 //Moves the paddle to the right
        }

        //Player - Stop
        if (Input.GetKeyUp(gameSettings.playerOneLeft) || Input.GetKeyUp(gameSettings.playerOneRight))
        {
            rigidbody.velocity = Vector3.zero;                                                      //Sets the paddles velocity to 0
        }
    }

    /// <summary>
    /// Handles the Player Two movement.
    /// </summary>
    private void PlayerTwoMovement()
    {
        if (Input.GetKey(gameSettings.playerTwoLeft))
        {
            //Debug.Log("Player Two Left" + rigidbody.velocity);

            rigidbody.AddForce(-transform.right * gameSettings.objectMovementSpeed);                //Moves the paddle to the left
        }

        if (Input.GetKey(gameSettings.playerTwoRight))
        {
            //Debug.Log("Player Two Right" + rigidbody.velocity);

            rigidbody.AddForce(transform.right * gameSettings.objectMovementSpeed);                 //Moves the paddle to the right
        }

        //Player - Stop
        if (Input.GetKeyUp(gameSettings.playerTwoLeft) || Input.GetKeyUp(gameSettings.playerTwoRight))
        {
            rigidbody.velocity = Vector3.zero;                                                      //Sets the paddles velocity to 0
        }
    }

}
