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
        // Ű �Է� ����
        if (Input.GetKeyUp(KeyCode.R) == true)
        {
            // �õ� ���� �ѱ�
            isBoot = !isBoot;
        }

        // �õ��� ������ ��
        if (isBoot)
        {
            // Ư�� �ð��� �����ϱ� ������ ���� ��ȭ�� ������Ŵ
            if (timer < waitTime)
            {
                accelAngle += addAngle;
            }

            timer += Time.deltaTime;
        }

        // �õ��� ������ ��
        if (!isBoot)
        {
            timer = 0f;

            // ���� ��ȭ�� ���ҽ�Ŵ
            if (accelAngle > 0f)
            {
                accelAngle -= addAngle;
            }

            // ���� ��ȭ�� ���ҽ�Ŵ
            if (powerY > 0f)
            {
                powerY -= speedY;
            }    
        }

        // Ư�� �ð��� �����ϸ�
        if (timer >= waitTime)
        {
            //// ���� ��ȭ�� ������Ŵ
            //if (powerY <= highSpeed)
            //{
            //    powerY += speedY;
            //}
        }

        // ���� �������� ���� ���� vec�� �ݿ�
        gameObject.transform.Rotate(0f, accelAngle % 360, 0f);
        helicopter.AddForce(0f, powerY, 0f);
    }
}
