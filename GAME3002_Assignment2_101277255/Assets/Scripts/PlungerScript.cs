using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    SpringJoint plunger_spring;
    Rigidbody plunger_RB;
    public Vector3 plunger_PosInit;
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
            plunger_spring.spring = 100.0f;
            plunger_RB.MovePosition(new Vector3(plunger_RB.position.x, plunger_RB.position.y, plunger_RB.position.z - 10));
        }

        //if (Mathf.Abs(plunger_RB.velocity.z) < 0.01f)
        //{
        //    plunger_RB.MovePosition(plunger_PosInit);
        //}
        print(plunger_RB.position);
    }
}
