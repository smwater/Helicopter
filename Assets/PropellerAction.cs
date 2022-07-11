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

        // Ű �Է� ����
        if (Input.GetKeyUp(KeyCode.R) == true)
        {
            // �õ� ���� �ѱ�
            isBoot = !isBoot;
        }

        // �õ��� ������ ��
        if (isBoot == true)
        {
            // Ư�� �ð��� �����ϱ� ������ ���� ��ȭ�� ������Ŵ
            if (timer < waitTime)
            {
                accelAngle += addAngle;
            }

            timer += Time.deltaTime;
        }

        // �õ��� ������ ��
        if (isBoot == false)
        {
            timer = 0f;

            // �����緯�� õõ�� ����
            if (accelAngle > 0f)
            {
                accelAngle -= addAngle;
            }

            // �︮���Ͱ� �ϰ���
            if (ySpeed >= 0f)
            {
                ySpeed = -speed * 2;
            }    
        }

        // Ư�� ȸ�� �ӵ��� �����ϸ�
        if (accelAngle >= highRotaSpeed)
        {
            // �︮���͸� �̵��� �� �ְ� �Ѵ�.
            ySpeed = yInput * speed;
        }

        // ���� ���� �︮���Ϳ� �ݿ�
        gameObject.transform.Rotate(0f, accelAngle % 360, 0f);
        helicopter.velocity = new Vector3(0f, ySpeed, 0f);
    }
}
