using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_ground_shock : MonoBehaviour
{
    [SerializeField] private GameObject createObject; // ��������I�u�W�F�N�g

    [SerializeField] private int itemCount = 40; // ��������I�u�W�F�N�g�̐�

    [SerializeField] private float radius = 5f; // ���a

    [SerializeField] private float repeat = 2f; // ���������邩

    [SerializeField] private float Jump_speed = 2f; // ���������邩
    [SerializeField] private float speed = 5f;
    public float jumpForce = 3f;
    public float jumpDelay = 2f;
    public float jumpRange = 50f;
    private float lastJumpTime;
    private Rigidbody rb;
    private Transform player;
    private float ct = 0f;
    private int count = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ct = 0f;

    }

    private void Update()
    {
        ct += Time.deltaTime;
        player = GameObject.FindWithTag("Player").transform; // "Player"�^�O���t�����I�u�W�F�N�g���擾
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (ct >= 2 && count == 0)
        {
            Jump();
            count++;
        }
        if (ct >= 4 && count == 1)
        {
            tackle();
            count++;
        }
    }
    public void Initialize()
    {
        // �ϐ��̏�������������������

        ct = 0f;
        count = 0;
    }
    private void Jump()
    {
        rb.velocity = Vector3.zero;
        Vector3 uppow = new Vector3(0, 0, 0);
        uppow.y += 0.5f;


        rb.AddForce(uppow * jumpForce, ForceMode.Impulse);
        lastJumpTime = Time.time;
    }
    private void tackle()
    {
        rb.velocity = Vector3.zero;
        Vector3 downpow = new Vector3(0, 0, 0);
        downpow.y -= 1;
        rb.AddForce(downpow * jumpForce, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (ct >= 2)
        {
            if (this.GetComponent<SS_ground_shock>().enabled == true)
            {

                Debug.Log("����������");
                if (collision.gameObject.tag == "ground")
                {
                    inpact_object();
                    this.GetComponent<SS_ground_shock>().enabled = false;
                }
            }
        }
        
      
    }

    public void inpact_object()
    {
        var oneCycle = 2.0f * Mathf.PI; // sin �̎����� 2��

        for (var i = 0; i < itemCount; ++i)
        {

            var point = ((float)i / itemCount) * oneCycle; // �����̈ʒu (1.0 = 100% �̎� 2�� �ƂȂ�)
            var repeatPoint = point * repeat; // �J��Ԃ��ʒu

            var x = Mathf.Cos(repeatPoint) * radius;
            var z = Mathf.Sin(repeatPoint) * radius;

            var position = new Vector3(this.transform.position.x + x, 0, this.transform.position.z + z);

            GameObject inpact = Instantiate(
                createObject,
                position,
                Quaternion.identity
            );

            Destroy(inpact, 1.0f);
        }
    }
}
