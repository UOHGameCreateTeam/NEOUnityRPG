using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam3 : MonoBehaviour
{
    private Vector3 hitPos;
    public GameObject player; // �v���C���[�I�u�W�F�N�g
    public GameObject beamPrefab; // �r�[���̃v���n�u
    public float beamSpeed = 5.0f; // �r�[���̑��x
    public float maxBeamLength = 100000.0f; // �r�[���̍ő咷��
    public float mae = 0f;
    private Transform tttt;
    Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    private float currentBeamLength = 0.0f;
    private float lightdis = 0f;

    void Start()
    {
        // �r�[���̃v���n�u���C���X�^���X�����āA���݂̃r�[���Ƃ��Đݒ�
        currentBeam = Instantiate(beamPrefab, transform.position + transform.forward * mae, Quaternion.identity);
        lineRenderer = currentBeam.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        endPosition = currentBeam.transform.position;
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

        lightdis = Vector3.Distance(currentBeam.transform.position, endPosition);
        Vector3 direction = currentBeam.transform.forward * lightdis;
        //Vector3 rayStartPosition = hand.transform.forward * lazerStartPointDistance;
        //Vector3 pos = hand.transform.position;
        RaycastHit hit;
        Ray ray = new Ray(currentBeam.transform.position, currentBeam.transform.forward);

        //lineRenderer.SetPosition(0, pos + rayStartPosition);
        /*
        if (Physics.Raycast(ray, out hit, lightdis))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
        }
        else
        {
            lineRenderer.SetPosition(1, pos + direction);
        }*/


        Debug.DrawRay(ray.origin, ray.direction * lightdis, Color.red, 5.0f); // �����R�O�A�ԐF�łT�b�ԉ�
        if (currentBeamLength < maxBeamLength)
        {
            if (Physics.Raycast(ray, out hit, lightdis))
            {
                hitPos = hit.point;
                Debug.Log(hit.collider.gameObject.name);
                lineRenderer.SetPosition(1, hitPos);
                Destroy(currentBeam);
                enabled = false;
            }
            else {
                // �r�[���̐L�ы���X�V
                currentBeamLength += beamSpeed * Time.deltaTime;
                currentBeamLength = Mathf.Clamp(currentBeamLength, 0.0f, maxBeamLength);

                // �r�[���̏I���ʒu���X�V
                endPosition = currentBeam.transform.position + currentBeam.transform.forward * currentBeamLength;
                lineRenderer.SetPosition(1, endPosition);
            }
            
        }
    }
}