using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelRotate : MonoBehaviour
{
    private GameSettingsManager gameSettings = null;

    [Range(-20.0f, 20.0f)]
    public float individualRotationalSpeed;

    public bool notLevelObject = false;
	
	private void Start ()
    {
        gameSettings = GameSettingsManager.Instance;
	}

    private void Update ()
    {
        switch (gameSettings.rotationDirection)
        {
            case GameSettingsManager.RotationDirection.CLOCKWISE:
                if (!notLevelObject)
                {
                    transform.Rotate(Vector3.up, gameSettings.levelRotationSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(Vector3.up, individualRotationalSpeed * Time.deltaTime);
                }

                break;
            case GameSettingsManager.RotationDirection.ANTI_CLOCKWISE:
                if (!notLevelObject)
                {
                    transform.Rotate(Vector3.up, -gameSettings.levelRotationSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(Vector3.up, -individualRotationalSpeed * Time.deltaTime);
                }
                break;
            default:
                break;
        }
    }
}
