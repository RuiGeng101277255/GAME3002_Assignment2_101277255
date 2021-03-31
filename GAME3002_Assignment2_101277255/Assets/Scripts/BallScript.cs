using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public bool ball_launched = false;
    public Vector3 ball_initialPos;

    private Rigidbody ball_RB;

    // Start is called before the first frame update
    void Start()
    {
        ball_RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball_RB.position.z < -7.0f)
        {
            ballReset();
        }
    }

    public void ballReset()
    {
        ball_launched = false;
        ball_RB.position = ball_initialPos;
    }
}
