using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerAction : MonoBehaviour
{ 
    public Rigidbody propeller;
    public Rigidbody helicopter;
    public float accelAngle = 0f;
    public float posY = 1.7f;
    public float time = 0f;
    private float waitTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        propeller = GetComponent<Rigidbody>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            if (time < waitTime)
            {
                accelAngle += 0.005f;
            }

            time += Time.deltaTime;
        }

        propeller.transform.Rotate(0f, accelAngle % 360, 0f);

        if (time >= waitTime)
        {
            posY += 0.005f;
        }

        helicopter.AddForce(0f, posY, 0f);
    }
}
