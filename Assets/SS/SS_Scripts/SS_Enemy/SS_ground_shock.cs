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
    private Vector3 velocity;

    void Start()
    {

        velocity = new Vector3(0, Jump_speed, 0);

    }
    void Update()
    {
        velocity.y += Physics.gravity.y * Time.deltaTime;
        transform.Translate(0f, velocity.y * Time.deltaTime, 0f);
    }

    void OnCollisionEnter(Collision collision)
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

            Instantiate(
                createObject,
                position,
                Quaternion.identity
            );

        }
    }
}
