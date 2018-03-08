using UnityEngine;

public class PongBallStart : MonoBehaviour
{
    private GameSettingsManager gameSettings = null;

    private new Rigidbody rigidbody = null;

    private SoundManager soundManagerRef;

    private bool spawnWait = false;
    private float timer = 0.0f;
 
    private void Start ()
    {
        gameSettings = GameSettingsManager.Instance;

        rigidbody = GetComponent<Rigidbody>();                                      //Pushes in Rigidbody 

        //rigidbody.AddForce(transform.right * gameSettings.pongBallMovementSpeed);   //Adds force to the ball 

        soundManagerRef = gameSettings.soundManager.GetComponent<SoundManager>();   //Calls soundManager

        spawnWait = true;
    }
	
	
	private void FixedUpdate ()
    {
        transform.LookAt(new Vector3(0, transform.position.y, 0));                  //Look at its relative height in x0z0

        if (spawnWait)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 1.0f)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                rigidbody.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)) * gameSettings.pongBallMovementSpeed * 2);  //Applies force to the ball after 1 second of the ball being stationary
                timer = 0.0f;
                spawnWait = false;
            }
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player1" || collision.transform.tag == "Player2")
        {
            rigidbody.AddForce(transform.forward * (gameSettings.pongBallMovementSpeed));                                         //Adds force to the ball away from the paddle it collided with
            //ResetPongBall();
        }

        if (collision.transform.tag == "Wall")
        {
            soundManagerRef.PongToWallSound();                                                                                    //Calls PongToWallSound
        }

        if (collision.transform.tag == "Player1")
        {
            soundManagerRef.Paddle1HitBall();                                                                                     //Calls Paddle1Hit sound
        }


        if (collision.transform.tag == "Player2")
        {
            soundManagerRef.Paddle2HitBall();                                                                                     //Calls Paddle2Hit sound
        }
    }

    /// <summary>
    /// Resets the pong balls location and increases the rotational speed of the level
    /// whilst getting it to turn the other way.
    /// </summary>
    /// 

    public void ResetPongBall()                                                                                                   //Resets the starting position of the ball
    {
        transform.GetChild(0).gameObject.SetActive(false);

        rigidbody.velocity = Vector3.zero;                                                                                        //Sets the balls X, Y and Z velocity to 0                                                         
        transform.position = new Vector3(0,1,0);                                                                                  //Sets the Y to 1

        spawnWait = true;

        gameSettings.levelRotationSpeed += gameSettings.levelRotationIncreaseAmount;                                              //Increases the rotation of the map

        gameSettings.rotationDirection = (gameSettings.rotationDirection == GameSettingsManager.RotationDirection.ANTI_CLOCKWISE) //Changes the direction of the rotation of the map
                                            ? GameSettingsManager.RotationDirection.CLOCKWISE 
                                            : GameSettingsManager.RotationDirection.ANTI_CLOCKWISE;

       
    }


}
