using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public string FlipperName;
    public float Flipper_SpringConst;
    public float Flipper_SpringDamp;
    public float Flipper_RotInit;
    public float Flipper_RotEnd;

    private Rigidbody Flipper_RB;
    private HingeJoint Flipper_HJ;
    private JointSpring Flipper_jointSpring;

    // Start is called before the first frame update
    void Start()
    {
        Flipper_HJ = GetComponent<HingeJoint>();
        Flipper_RB = GetComponent<Rigidbody>();
        Flipper_jointSpring = new JointSpring();
        Flipper_jointSpring.spring = Flipper_SpringConst;
        Flipper_jointSpring.damper = Flipper_SpringDamp;
        Flipper_HJ.spring = Flipper_jointSpring;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flipper_jointSpring.targetPosition = Flipper_RotEnd;
            Flipper_HJ.spring = Flipper_jointSpring;

            //to be deleted
            if (FlipperName == "LeftFlipper")
            {
                //Flipper_RB.AddTorque(Vector3.left * -5.0f);
                
                //Flipper_HJ.transform.rotation = new Quaternion(0.0f, -90.0f, 0.0f, 1.0f);
            }
            else if (FlipperName == "RightFlipper")
            {
                //Flipper_HJ.transform.rotation = new Quaternion(0.0f, 90.0f, 0.0f, 1.0f);
            }
            else
            {
                print("Flipper Not Found");
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Flipper_jointSpring.targetPosition = Flipper_RotInit;
            Flipper_HJ.spring = Flipper_jointSpring;
        }
    }
}
