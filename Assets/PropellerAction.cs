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
        // Ű �Է� ����
        if (Input.GetKey(KeyCode.W) == true)
        {
            // Ư�� �ð��� �����ϱ� ������ ���� ��ȭ�� ������Ŵ
            if (time < waitTime)
            {
                accelAngle += addAngle;
            }

            time += Time.deltaTime;

            isWKeyOff = false;
        }

        // Ű �Է��� �����ٸ�
        if (Input.GetKeyUp(KeyCode.W) == true)
        {
            isWKeyOff = true;
        }

        // Ű�� �Է����� ���� ��
        if (isWKeyOff)
        {
            time = 0f;

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
        if (time >= waitTime)
        {
            // ���� ��ȭ�� ������Ŵ
            if (powerY <= 1f)
            {
                powerY += speedY;
            }
        }

        // ���� �������� ���� ���� vec�� �ݿ�
        gameObject.transform.Rotate(0f, accelAngle % 360, 0f);
        helicopter.AddForce(0f, powerY, 0f);
    }
}
