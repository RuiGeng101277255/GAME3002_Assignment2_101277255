using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    public Vector3 plunger_PosInit; //Initial position

    private SpringJoint plunger_spring;
    private Rigidbody plunger_RB;

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
            //Changing spring's position attached to the plunger
            plunger_spring.transform.position = new Vector3(plunger_PosInit.x, plunger_PosInit.y, plunger_PosInit.z - 0.5f);
            
            //Alternative method to change the rigidbody to produce the same effect
            //Since anchor and connected anchors are already set via the inspector section
            //plunger_RB.position = new Vector3(plunger_PosInit.x, plunger_PosInit.y, plunger_PosInit.z - 0.5f);
        }
    }

    //Reset plunger position after it hits the ball + not pushing when there is no ball
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PinBall")
        {
            plunger_RB.MovePosition(plunger_PosInit);
        }
    }
}
