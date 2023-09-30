using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam5 : MonoBehaviour
{
    private Vector3 hitPos;
    private GameObject player; // �v���C���[�I�u�W�F�N�g
    [SerializeField] private GameObject beamPrefab; // �r�[���̃v���n�u
    [SerializeField] private float base_beamSpeed = 50f;
    private float beamSpeed; // �r�[���̑��x
    [SerializeField] private float maxBeamLength = 10000.0f; // �r�[���̍ő咷��
    //[SerializeField] private float mae = 0f;
    private Transform tttt;
    private Vector3 player_position;
    Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    private float currentBeamLength = 0.0f;
    private float lightdis = 0f;
    private bool beam_flag = false;
    private float time = 0f;
    [SerializeField] private float intarval = 2f;
    [SerializeField] private float lifeTime = 3.0f;
    void Start()
    {
        player = GameObject.FindWithTag("test_cube_1");
        beamSpeed = base_beamSpeed;
        currentBeamLength = 0;
        player_position = player.transform.position;
        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        endPosition = this.transform.position;
        lineRenderer.SetPosition(0, transform.position); // �r�[���̊J�n�ʒu��ݒ�
        lineRenderer.SetPosition(1, endPosition); // �r�[���̏I���ʒu���J�n�ʒu�Ɠ����ɐݒ�
    }

    void Update()
    {

        lightdis = Vector3.Distance(this.transform.position, endPosition);
        Vector3 direction = this.transform.forward * lightdis;
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, this.transform.forward);

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
                //Debug.Log(hit.collider.gameObject.name);
                lineRenderer.SetPosition(1, hitPos);
                Destroy(currentBeam);
            }
            else
            {
                // �r�[���̐L�ы���X�V
                currentBeamLength += beamSpeed * Time.deltaTime;
                currentBeamLength = Mathf.Clamp(currentBeamLength, 0.0f, maxBeamLength);

                // �r�[���̏I���ʒu���X�V
                endPosition = this.transform.position + this.transform.forward * currentBeamLength;
                lineRenderer.SetPosition(1, endPosition);
            }

        }
    }
  
}