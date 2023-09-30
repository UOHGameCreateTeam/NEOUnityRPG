using UnityEngine;

public class SS_beam : MonoBehaviour
{
    private GameObject ppp;
    public GameObject tt;
    private Transform target; // �^�[�Q�b�g��Transform�R���|�[�l���g
    public float stretchSpeed = 1.0f; // �L�k�̑��x

    private Vector3 initialScale; // �I�u�W�F�N�g�̏����X�P�[��
    private bool isStretching = true; // �L�k�����ǂ���

    private void Start()
    {
        ppp = GameObject.FindWithTag("beam");

        target = tt.transform;
    }

    private void Update()
    {
        if (isStretching)
        {
            initialScale = ppp.transform.localScale;
            // �^�[�Q�b�g�̈ʒu����I�u�W�F�N�g�ւ̃x�N�g�����擾
            Vector3 directionToTarget = target.position - ppp.transform.position;

            // �^�[�Q�b�g�̈ʒu�Ɍ������ĐL�k
            float distanceToTarget = directionToTarget.magnitude;

            // �I�u�W�F�N�g�̃X�P�[����ύX���ĐL�k������
            ppp.transform.localScale = initialScale + Vector3.forward * (distanceToTarget * stretchSpeed);

            // �^�[�Q�b�g�ɓ��B������L�k���~
            if (distanceToTarget < 0.1f)
            {
                isStretching = false;
            }
        }
    }
}