using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randam_sha : MonoBehaviour
{
    public GameObject objectToLaunch; // �ˏo����I�u�W�F�N�g
    public float launchForce = 10f; // �ˏo��

    void Start()
    {
        // �I�u�W�F�N�g�������������A�����_���ȕ����Ɏˏo����
        StartCoroutine(LaunchObjects());
    }

    IEnumerator LaunchObjects()
    {
        while (true)
        {
            // �V�����I�u�W�F�N�g�𐶐�
            GameObject newObject = Instantiate(objectToLaunch, transform.position, Quaternion.identity);

            // �����_���ȕ����Ɏˏo����x�N�g�����v�Z
            Vector3 launchDirection = Random.onUnitSphere;
            launchDirection.y = 1;

            // �ˏo�͂�K�p
            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
            }
           
            Destroy(newObject, 6.0f);
            

            // ���̊Ԋu�ŃI�u�W�F�N�g�𐶐�
            yield return new WaitForSeconds(1.0f);

        }
    }
}