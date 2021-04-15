using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    GameObject gameManager;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        if (transform.position.x < -12.0f)
        {
            //increase player 2 score
            updateScoreAndDestroy(player2);
        }
        else if (transform.position.x > 12.0f)
        {
            //increase player 1 score
            updateScoreAndDestroy(player1);
        }
    }

    private void updateScoreAndDestroy(GameObject player)
    {
        HumanPlayer playerScript = player.GetComponent<HumanPlayer>();
        if (playerScript != null)
        {
            playerScript.increaseScore();
        }
        else
        {
            throw new MissingComponentException("Player Script missing on player: " + player.name);
        }

        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
        gameManagerScript.startAgain();
        Destroy(gameObject);
    }
}
