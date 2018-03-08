using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    public AudioSource[] wallSounds;                                          //Array of wall collision sounds
    public AudioSource scoreSoundP1;                                          //Scoring of Player 1
    public AudioSource scoreSoundP2;                                          //Scoring of Player 2
    public AudioSource Paddle1;                                               //Player 1 hitting the ball
    public AudioSource Paddle2;                                               //Player 2 hitting the ball
    public AudioSource backgroundMusic;                                       //Plays background music

	public static SoundManager instance = null;                               //Sets instance to null

	public float lowPitchRange;										          //Represents + or - 5% of our original pitch
	public float highPitchRange; 									          //Represents + or - 5% of our original pitch

    //private GameSettingsManager gameSettings = null;                          //Sets ggameSettings to null

    private void Start()
    {
        //gameSettings = GameSettingsManager.Instance;                          //Sets instance to gameSettings
    }

    // Use this for initialization
    void Awake () 															  //Each time the scene is loaded the music will not reset
	{
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this) 
		{
			Destroy (gameObject);	
		}
		DontDestroyOnLoad (gameObject);
	}

    public void Player1Score()                                                //Plays the audio when Player 1 scores
    {
        scoreSoundP1.Play();
    }

    public void Player2Score()                                                //Plays the audio when Player 2 scores
    {
        scoreSoundP2.Play();
    }

    public void Paddle1HitBall()                                              //Plays the audio when Player hits the ball
    {
        Paddle1.Play();
    }

    public void Paddle2HitBall()                                              //Plays the audio when Player 2 hits the ball
    {
        Paddle2.Play();
    }

    public void PongToWallSound(params AudioClip[] clips)
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);	//Randomises the pitch so the sound doesnt sound repetitive	

        int randomClip = Random.Range(0, 3);                                //Pushes in the random range of the array into randomClip

        wallSounds[randomClip].pitch = randomPitch;                         //Randomises the pitch of each clip

        wallSounds[randomClip].Play();                                      //Plays the audio of the randomly selected clip

        //Debug.Log(randomClip.ToString() + " : " + wallSounds[randomClip].name); //Debug
       

    }
    public void BackGroundMusic()                                           //Plays the background music
    {
        backgroundMusic.Play();
    }
}
