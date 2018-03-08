using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreDisplay : MonoBehaviour
{
    public List<GameObject> score;

    private GameSettingsManager gameSettings = null;
	private void Start ()
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            score.Add(transform.GetChild(index).gameObject);
        }

        foreach (GameObject scoreObbject in score)
        {
            scoreObbject.SetActive(false);
        }

        gameSettings = GameSettingsManager.Instance;
	}
	
	
	private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameSettings.playerOneScore > 0)
                score[gameSettings.playerOneScore - 1].SetActive(true);
        }
	}

    public void UpdateScorePlayerOne(int a_PlayerOneScore)
    {
        if (gameSettings.playerOneScore > 0  && gameSettings.playerOneScore <= 10 && score[gameSettings.playerOneScore - 1].activeSelf != true)
            score[gameSettings.playerOneScore - 1].SetActive(true);
    }

    public void UpdateScorePlayerTwo(int a_PlayerTwoScore)
    {
        if (gameSettings.playerTwoScore > 0 && gameSettings.playerTwoScore <= 10 && score[gameSettings.playerTwoScore - 1].activeSelf != true)
            score[gameSettings.playerTwoScore - 1].SetActive(true);
    }

}
