using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    SpringJoint plunger_spring;
    Rigidbody plunger_RB;
    public Vector3 plunger_PosInit; //Initial position

    // Start is called before the first frame update
    void Start()
    {
        plunger_spring = GetComponent<SpringJoint>();
        plunger_RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            plunger_RB.position = new Vector3(plunger_PosInit.x, plunger_PosInit.y, plunger_PosInit.z - 0.5f);
        }
    }

    //Reset plunger position after it hits the ball + not pushing when there is no ball
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PinBall")
        {
            plunger_RB.MovePosition(plunger_PosInit);
            print("ball");
        }
    }
}
