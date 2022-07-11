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
    private const float highRotaSpeed = 2.5f;

    public float ySpeed = 0f;
    private const float speed = 5f;

    private float timer = 0f;
    private const float waitTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // 키 입력 감지
        if (Input.GetKeyUp(KeyCode.R) == true)
        {
            // 시동 끄고 켜기
            isBoot = !isBoot;
        }

        // 시동이 켜졌을 때
        if (isBoot == true)
        {
            // 특정 시간에 도달하기 전까진 각도 변화를 증가시킴
            if (timer < waitTime)
            {
                accelAngle += addAngle;
            }

            timer += Time.deltaTime;
        }

        // 시동이 꺼졌을 때
        if (isBoot == false)
        {
            timer = 0f;

            // 프로펠러가 천천히 멈춤
            if (accelAngle > 0f)
            {
                accelAngle -= addAngle;
            }

            // 헬리콥터가 하강함
            if (ySpeed >= 0f)
            {
                ySpeed = -speed * 2;
            }    
        }

        // 특정 회전 속도에 도달하면
        if (accelAngle >= highRotaSpeed)
        {
            // 헬리콥터를 이동할 수 있게 한다.
            ySpeed = yInput * speed;
        }

        // 위의 값을 헬리콥터에 반영
        gameObject.transform.Rotate(0f, accelAngle % 360, 0f);
        helicopter.velocity = new Vector3(0f, ySpeed, 0f);
    }
}
