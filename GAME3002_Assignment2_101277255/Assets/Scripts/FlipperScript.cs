using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float Flipper_SpringConst;
    public float Flipper_SpringDamp;
    public float Flipper_RotInit;
    public float Flipper_RotEnd;

    private HingeJoint Flipper_HJ;
    private JointSpring Flipper_jointSpring;

    // Start is called before the first frame update
    void Start()
    {
        Flipper_HJ = GetComponent<HingeJoint>();
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
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Flipper_jointSpring.targetPosition = Flipper_RotInit;
            Flipper_HJ.spring = Flipper_jointSpring;
        }
    }
}
