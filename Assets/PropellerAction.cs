using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerAction : MonoBehaviour
{ 
    public Rigidbody helicopter;

    private bool isBoot = false;

    private float propellerYAngle = 0f;
    private const float accelAngle = 0.005f;
    private const float highAngleSpeed = 2.5f;

    private float helicopterYAngle = 0f;
    private const float angle = 10f;

    private float helicopterYSpeed = 0f;
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
                propellerYAngle += accelAngle;
            }

            timer += Time.deltaTime;
        }

        // �õ��� ������ ��
        if (isBoot == false)
        {
            timer = 0f;

            // �����緯�� õõ�� ����
            if (propellerYAngle > 0f)
            {
                propellerYAngle -= accelAngle;
            }

            // �︮���Ͱ� �߶���
            if (helicopterYSpeed >= 0f)
            {
                helicopterYSpeed = -speed * 2;
            }    
        }

        // �õ��� �����ְ�, Ư�� ȸ�� �ӵ��� �����ϸ�
        if (propellerYAngle >= highAngleSpeed && isBoot)
        {
            // �︮���͸� ������ �� �ִ�.
            helicopterYAngle = xInput / angle;
            helicopterYSpeed = yInput * speed;
        }

        // ���� ���� �︮���Ϳ� �ݿ�
        gameObject.transform.Rotate(0f, propellerYAngle % 360, 0f);
        helicopter.transform.Rotate(0f, helicopterYAngle, 0f);
        helicopter.velocity = new Vector3(0f, helicopterYSpeed, 0f);
    }
}
