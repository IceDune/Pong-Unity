using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private int ballSpeed = 3;

    void Start()
    {
        GameObject ball = Instantiate(ballPrefab, new Vector2(0.0f, 0.0f), Quaternion.identity);
        moveBallInRandomDirection(ball);
    }

    public void startAgain()
    {
        GameObject ball = Instantiate(ballPrefab, new Vector2(0.0f, 0.0f), Quaternion.identity);
        moveBallInRandomDirection(ball);
    }

    void moveBallInRandomDirection(GameObject ball)
    {
        List<int> coordinates = new List<int> { 100, -100 };
        System.Random random = new System.Random();
        int x = random.Next(coordinates.Count);
        int y = random.Next(coordinates.Count);

        Vector2 force = new Vector2(coordinates[x] * ballSpeed, coordinates[y] * ballSpeed);
        Rigidbody2D ballRigidbody2D = ball.GetComponent<Rigidbody2D>();
        ballRigidbody2D.AddForce(force);
    }
}
