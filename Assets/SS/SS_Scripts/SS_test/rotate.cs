using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // �p���x
    [SerializeField] private float _angleSpeed = 90;

    // ��]��
    [SerializeField] private Vector3 _axis = Vector3.forward;

    private Transform _transform;

    // ������
    private void Awake()
    {
        // transform�ɖ���A�N�Z�X����Əd���̂ŁA�L���b�V�����Ă���
        _transform = transform;
    }

    // ��]����
    private void Update()
    {
        // �P�t���[���ŉ�]����p�x���p���x����v�Z
        var angle = _angleSpeed * Time.deltaTime;

        // ������rotation�Ɏ���]�̃N�H�[�^�j�I�����|����
        // �N�H�[�^�j�I�����|���鏇���ɒ���
        _transform.rotation = Quaternion.AngleAxis(angle, _axis) * _transform.rotation;
    }
}
