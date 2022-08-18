using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("mainCameraのオブジェクト")]
    [SerializeField] GameObject _mainCamera;
    [Header("Playerのスピード")]
    [SerializeField] float _speed = 5;
    [Header("プレイヤーが向く方向")]
    [SerializeField] GameObject _lookAtObj;

    [Tooltip("方向ベクトルを保存する")]
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
        //入力処理
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        //方向ベクトルを取得
        _dir = new Vector3(x, 0, z);
    }
}
