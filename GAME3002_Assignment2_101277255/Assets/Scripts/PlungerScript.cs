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
    private float plunger_pullStrength = 0.0f;
    private Vector3 pinball_tempPos;
    private Light plunger_light;

    // Start is called before the first frame update
    void Start()
    {
        plunger_spring = GetComponent<SpringJoint>();
        plunger_RB = GetComponent<Rigidbody>();
        plunger_light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Cap the strength to shoot pinball
            if (plunger_pullStrength <= 2.5f)
            {
                plunger_pullStrength += 1.5f * Time.deltaTime;
            }
            else
            {
                //At max power turns plunger's light green
                plunger_light.color = Color.green;
            }

            //Plunger pull is only valid if ball hasn't been launched
            if (!pinball.ball_launched)
            {
                plunger_pulled = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            plunger_RB.AddForce(new Vector3(0.0f, 0.0f, -1.0f) * 500.0f, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PinBall")
        {
            //Reset ball if it's back at launch lane without reaching endzone
            //Temp position so there isn't a position difference with reset.
            if (pinball.ball_launched)
            {
                pinball_tempPos = pinball.GetComponent<Rigidbody>().position;
                pinball.ballReset();
                pinball.GetComponent<Rigidbody>().position = pinball_tempPos;
            }

            if (plunger_pulled)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 1.0f) * plunger_pullStrength, ForceMode.Impulse);
                pinball.ball_launched = true;
                plunger_pulled = false;
                plunger_pullStrength = 0.0f;
                plunger_light.color = Color.white;
            }
        }
    }
}
