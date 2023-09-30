using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_beam_hassha : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3.0f;
    [SerializeField] private GameObject beamPrefab; // �r�[���̃v���n�u
    private GameObject player; // �v���C���[�I�u�W�F�N�g
    private Vector3 player_position;
    private Vector3 endPosition;
    private GameObject currentBeam;
    private LineRenderer lineRenderer;
    
    void Start()
    {
        player = GameObject.FindWithTag("test_cube_1");
    }

    void Update()
    {
    }
    public void player_search()
    {
        player_position = player.transform.position;
        Vector3 instanse_position = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
        // �r�[���̃v���n�u���C���X�^���X�����āA���݂̃r�[���Ƃ��Đݒ�
        currentBeam = Instantiate(beamPrefab, instanse_position, Quaternion.identity);
        Destroy(currentBeam, lifeTime);

        // �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o
        Vector3 vector3 = player_position - currentBeam.transform.position;

        // Quaternion(��]�l)���擾
        Quaternion quaternion = Quaternion.LookRotation(vector3);

        // �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
        currentBeam.transform.rotation = quaternion;
    }
}