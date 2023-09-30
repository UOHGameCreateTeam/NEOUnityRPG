using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam2 : MonoBehaviour
{
    public GameObject player; // �v���C���[�I�u�W�F�N�g
    public GameObject beamPrefab; // �r�[���̃v���n�u
    public float beamSpeed = 5.0f; // �r�[���̑��x
    public float maxBeamLength = 10.0f; // �r�[���̍ő咷��
    private Transform tttt;
    Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    private float currentBeamLength = 0.0f;

    void Start()
    {
        // �r�[���̃v���n�u���C���X�^���X�����āA���݂̃r�[���Ƃ��Đݒ�
        currentBeam = Instantiate(beamPrefab, transform.position, Quaternion.identity);
        lineRenderer = currentBeam.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        endPosition = transform.position;
        lineRenderer.SetPosition(0, transform.position); // �r�[���̊J�n�ʒu��ݒ�
        lineRenderer.SetPosition(1, endPosition); // �r�[���̏I���ʒu���J�n�ʒu�Ɠ����ɐݒ�
    }

    void Update()
    {
        // �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o
        Vector3 vector3 = player.transform.position - currentBeam.transform.position;
        // �����㉺�����̉�]�͂��Ȃ��悤�ɂ�������Έȉ��̂悤�ɂ���B
        // vector3.y = 0f;

        // Quaternion(��]�l)���擾
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        // �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
        currentBeam.transform.rotation = quaternion;
        if (currentBeamLength < maxBeamLength)
        {
            // �r�[���̐L�ы���X�V
            currentBeamLength += beamSpeed * Time.deltaTime;
            currentBeamLength = Mathf.Clamp(currentBeamLength, 0.0f, maxBeamLength);

            // �r�[���̏I���ʒu���X�V
            endPosition = endPosition + currentBeam.transform.forward * currentBeamLength;
            lineRenderer.SetPosition(1, endPosition);
        }
    }
}
