using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HumanPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private string inputAxisName = "Player 1 Paddle";

    [SerializeField]
    private TextMeshProUGUI scoreUI;

    private Rigidbody2D rigidbody;
    private float vertical;
    private int score;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        score = 0;
        scoreUI.text = score.ToString();
    }

    void Update()
    {
        vertical = Input.GetAxis(inputAxisName);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position.y += Time.deltaTime * speed * vertical;
        if (position.y > -4.4f && position.y < 4.4f)
        {
            rigidbody.MovePosition(position);
        }
    }

    internal void increaseScore()
    {
        score++;
        scoreUI.text = score.ToString();
    }
}
