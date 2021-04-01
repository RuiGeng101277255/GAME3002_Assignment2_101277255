using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public bool ball_launched = false;
    public bool ball_autoReset = true;
    public Vector3 ball_initialPos;
    public ScoreNumberScript score_Num;

    private Rigidbody ball_RB;
    private int ballScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        ball_RB = GetComponent<Rigidbody>();
        ballScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Reset the ball to the shooting chamber any time
        if (Input.GetKeyDown(KeyCode.R))
        {
            ballReset();
        }

        score_Num.setScore(ballScore);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Puts pinball outside of the visible range on contact with the endzone
        if (collision.gameObject.name == "EndZone")
        {
            ball_RB.position = new Vector3(1.0f, 1.0f, 1.0f) * -1000.0f;

            if(ball_autoReset)
            {
                ballReset();
            }
        }
    }

    public void ballReset()
    {
        ball_launched = false;
        ball_RB.position = ball_initialPos;
        ballScore = 0;
    }

    public void addBallScore(int score)
    {
        ballScore += score;
    }
}
