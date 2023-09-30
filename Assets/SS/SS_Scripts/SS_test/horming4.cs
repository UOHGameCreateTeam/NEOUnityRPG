using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horming4 : MonoBehaviour
{
    [SerializeField] public float maxHeight = 5f; // �������̍ő卂��
    [SerializeField] public float throwAngle = 45f; // �������̊p�x
    [SerializeField] public float throwSpeed = 10f; // �������̑��x
    private GameObject player;
    private GameObject hasshadai;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float initialVelocity;

    void Start()
    {
        player = GameObject.FindWithTag("test_cube_1");
        hasshadai = GameObject.FindWithTag("test_hassha");
        if (hasshadai.transform == null || player.transform == null)
        {
            Debug.LogError("Start Object and Target Object must be assigned.");
            return;
        }

        initialPosition = hasshadai.transform.position;
        targetPosition = player.transform.position;

        // �����x���v�Z
        initialVelocity = CalculateInitialVelocity();

        // ��������`���R���[�`�����J�n
        StartCoroutine(ThrowObject());
    }

    float CalculateInitialVelocity()
    {
        // �����x���v�Z���鎮
        float distance = Vector3.Distance(initialPosition, targetPosition);
        float g = Physics.gravity.magnitude;
        float tanTheta = Mathf.Tan(throwAngle * Mathf.Deg2Rad);
        float velocity = Mathf.Sqrt((distance * g) / (2.0f * (maxHeight - initialPosition.y * tanTheta)));
        return velocity;
    }

    IEnumerator ThrowObject()
    {
        float startTime = Time.time;

        while (true)
        {
            float elapsedTime = Time.time - startTime;

            // �������̐��������̈ʒu���v�Z
            float horizontalDistance = initialVelocity * elapsedTime;
            Vector3 horizontalDirection = (targetPosition - initialPosition).normalized;
            Vector3 horizontalPosition = initialPosition + horizontalDirection * horizontalDistance;

            // �������̐��������̈ʒu���v�Z
            float verticalPosition = initialPosition.y + (Mathf.Tan(throwAngle * Mathf.Deg2Rad) * horizontalDistance - (Physics.gravity.magnitude * horizontalDistance * horizontalDistance) / (2.0f * initialVelocity * initialVelocity));

            // �I�u�W�F�N�g�̈ʒu���X�V
            transform.position = new Vector3(horizontalPosition.x, verticalPosition, horizontalPosition.z);

            if (elapsedTime >= (2.0f * initialVelocity * Mathf.Sin(throwAngle * Mathf.Deg2Rad) / Physics.gravity.magnitude))
            {
                // ���������I��������R���[�`�����I��
                yield break;
            }

            yield return null;
        }
    }
}
