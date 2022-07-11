using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerAction : MonoBehaviour
{ 
    public Rigidbody helicopter;

    private bool isWKeyOff = true;
    private bool isBoot = false;

    private float accelAngle = 0f;
    private const float addAngle = 0.005f;

    private float powerY = 0f;
    private const float speedY = 0.002f;

    private float timer = 0f;
    private const float waitTime = 2f;
    private const float highSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        // 키 입력 감지
        if (Input.GetKeyUp(KeyCode.R) == true)
        {
            // 시동 끄고 켜기
            isBoot = !isBoot;
        }

        // 시동이 켜졌을 때
        if (isBoot)
        {
            // 특정 시간에 도달하기 전까진 각도 변화를 증가시킴
            if (timer < waitTime)
            {
                accelAngle += addAngle;
            }

            timer += Time.deltaTime;
        }

        // 시동이 꺼졌을 때
        if (!isBoot)
        {
            timer = 0f;

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
        if (timer >= waitTime)
        {
            //// 높이 변화를 증가시킴
            //if (powerY <= highSpeed)
            //{
            //    powerY += speedY;
            //}
        }

        // 위의 과정에서 나온 값을 vec에 반영
        gameObject.transform.Rotate(0f, accelAngle % 360, 0f);
        helicopter.AddForce(0f, powerY, 0f);
    }
}
