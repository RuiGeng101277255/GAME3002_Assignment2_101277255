using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    public bool isPassive;

    private CapsuleCollider bumperCollider;
    private MeshRenderer bumperRenderer;
    private Light bumperLight;

    // Start is called before the first frame update
    void Start()
    {
        bumperCollider = GetComponent<CapsuleCollider>();
        bumperRenderer = GetComponent<MeshRenderer>();
        bumperLight = GetComponent<Light>();

        if (isPassive)
        {
            bumperCollider.material.bounciness = 0.0f;
            bumperRenderer.material.color = Color.yellow;
            bumperLight.color = Color.yellow;
        }
        else
        {
            bumperCollider.material.bounciness = 1.0f;
            bumperRenderer.material.color = Color.green;
            bumperLight.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        bumperLight.color = Color.red;

        //Extra boost for active bumper
        if(!isPassive)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.contacts[0].normal, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(isPassive)
        {
            bumperLight.color = Color.yellow;
        }
        else
        {
            bumperLight.color = Color.green;
        }
    }
}
