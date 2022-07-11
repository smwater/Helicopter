using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerAction : MonoBehaviour
{ 
    public Rigidbody helicopter;

    private bool isWKeyOff = true;

    private float accelAngle = 0f;
    private const float addAngle = 0.005f;

    private float powerY = 0f;
    private const float speedY = 0.002f;

    private float time = 0f;
    private const float waitTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        // 키 입력 감지
        if (Input.GetKey(KeyCode.W) == true)
        {
            // 특정 시간에 도달하기 전까진 각도 변화를 증가시킴
            if (time < waitTime)
            {
                accelAngle += addAngle;
            }

            time += Time.deltaTime;

            isWKeyOff = false;
        }

        // 키 입력이 끝났다면
        if (Input.GetKeyUp(KeyCode.W) == true)
        {
            isWKeyOff = true;
        }

        // 키를 입력하지 않을 때
        if (isWKeyOff)
        {
            time = 0f;

            // 각도 변화를 감소시킴
            if (accelAngle > 0f)
            {
                accelAngle -= addAngle;
            }

            // 높이 변화를 감소시킴
            if (powerY > 0f)
            {
                powerY -= speedY;
            }    
        }

        // 특정 시간에 도달하면
        if (time >= waitTime)
        {
            // 높이 변화를 증가시킴
            if (powerY <= 1f)
            {
                powerY += speedY;
            }
        }

        // 위의 과정에서 나온 값을 vec에 반영
        gameObject.transform.Rotate(0f, accelAngle % 360, 0f);
        helicopter.AddForce(0f, powerY, 0f);
    }
}
