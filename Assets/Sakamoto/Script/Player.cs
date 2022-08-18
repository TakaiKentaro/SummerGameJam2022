using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("mainCamera�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _mainCamera;
    [Header("Player�̃X�s�[�h")]
    [SerializeField] float _speed = 5;
    [Header("�v���C���[����������")]
    [SerializeField] GameObject _lookAtObj;

    [Tooltip("�����x�N�g����ۑ�����")]
    Vector3 _dir;
    [Tooltip("RigidBody")]
    Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();

        _dir = _mainCamera.transform.TransformDirection(_dir);

        _dir.y = 0;

        if (_dir != Vector3.zero)
        {

            Quaternion targetRotetion = Quaternion.LookRotation(_dir);
        }
        else
        {

        }

        _rb.velocity = _dir.normalized * _speed + new Vector3(0, _rb.velocity.y, 0f);

        transform.LookAt(new Vector3(_lookAtObj.transform.position.x, transform.position.y, _lookAtObj.transform.position.z));
    }

    void InputPlayer()
    {
        //���͏���
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        //�����x�N�g�����擾
        _dir = new Vector3(x, 0, z);
    }
}
