using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam4 : MonoBehaviour
{
    private Vector3 hitPos;
    public GameObject player; // �v���C���[�I�u�W�F�N�g
    public GameObject beamPrefab; // �r�[���̃v���n�u
    public float base_beamSpeed = 30f;
    private float beamSpeed; // �r�[���̑��x
    public float maxBeamLength = 100.0f; // �r�[���̍ő咷��
    public float mae = 0f;
    private Transform tttt;
    private Vector3 player_position;
    Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    private float currentBeamLength = 0.0f;
    private float lightdis = 0f;
    private bool beam_flag = false;
    private float time = 0f;
    public float intarval = 2f;
    public float lifeTime = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
       

        if (beam_flag == true)
        {
            beam_flag = beam_attack();
        }
}
    public void player_search() {
        beamSpeed = base_beamSpeed;
        currentBeamLength = 0;
        player_position = player.transform.position;
        // �r�[���̃v���n�u���C���X�^���X�����āA���݂̃r�[���Ƃ��Đݒ�
        currentBeam = Instantiate(beamPrefab, transform.position + transform.forward * mae, Quaternion.identity);
        Destroy(currentBeam, lifeTime);
        lineRenderer = currentBeam.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        endPosition = currentBeam.transform.position;
        lineRenderer.SetPosition(0, transform.position); // �r�[���̊J�n�ʒu��ݒ�
        lineRenderer.SetPosition(1, endPosition); // �r�[���̏I���ʒu���J�n�ʒu�Ɠ����ɐݒ�
    }

    public void attack_flag() { 
        beam_flag = true;
    }

    private bool beam_attack() {
        // �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o
        Vector3 vector3 = player_position - currentBeam.transform.position;
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


        //Debug.DrawRay(ray.origin, ray.direction * lightdis, Color.red, 5.0f); // �����R�O�A�ԐF�łT�b�ԉ�
        if (currentBeamLength < maxBeamLength)
        {
            if (Physics.Raycast(ray, out hit, lightdis))
            {
                hitPos = hit.point;
                Debug.Log(hit.collider.gameObject.name);
                lineRenderer.SetPosition(1, hitPos);
                //Destroy(currentBeam);
                return false;
            }
            else
            {
                // �r�[���̐L�ы���X�V
                currentBeamLength += beamSpeed * Time.deltaTime;
                currentBeamLength = Mathf.Clamp(currentBeamLength, 0.0f, maxBeamLength);

                // �r�[���̏I���ʒu���X�V
                endPosition = currentBeam.transform.position + currentBeam.transform.forward * currentBeamLength;
                lineRenderer.SetPosition(1, endPosition);
                return true;
            }

        }
        else { 
            return false;
        }
    }
}
