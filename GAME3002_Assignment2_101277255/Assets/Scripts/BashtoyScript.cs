using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashtoyScript : MonoBehaviour
{
    public int BashtoyPoints;
    public GameObject bash_light;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        bash_light.GetComponent<Light>().color = Color.green;
    }

    private void OnCollisionExit(Collision collision)
    {
        bash_light.GetComponent<Light>().color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
    }
}
