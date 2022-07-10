using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerAction : MonoBehaviour
{
    public Rigidbody propeller;
    public float angleY = 0f;
    public float posY = 0;
    public float time = 0f;
    private float waitTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
            
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            angleY += 0.005f;
            time += Time.deltaTime;
        }

        propeller.transform.Rotate(0f, angleY % 360, 0f);

        if (time >= waitTime)
        {
            posY += 0.001f;
        }

        propeller.AddForce(0f, posY, 0f);
    }
}
