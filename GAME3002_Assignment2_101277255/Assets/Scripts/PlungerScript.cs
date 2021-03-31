using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    public Vector3 plunger_PosInit; //Initial position
    public BallScript pinball;

    private SpringJoint plunger_spring;
    private Rigidbody plunger_RB;
    private bool plunger_pulled = false;

    // Start is called before the first frame update
    void Start()
    {
        plunger_spring = GetComponent<SpringJoint>();
        plunger_RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            plunger_RB.AddForce(new Vector3(0.0f, 0.0f, -1.0f) * 500.0f, ForceMode.Impulse);
            plunger_pulled = true;
        }
        if (pinball.ball_launched)
        {
            plunger_pulled = false;
        }
    }

    //Reset plunger position after it hits the ball + not pushing when there is no ball
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PinBall")
        {
            if (plunger_pulled)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 1.0f) * 2.5f, ForceMode.Impulse);
                pinball.ball_launched = true;
                plunger_pulled = false;
            }
        }
    }
}
