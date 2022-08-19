using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("mainCameraのオブジェクト")]
    [SerializeField] GameObject _mainCamera;
    [Header("Playerのスピード")]
    [SerializeField] float _speed = 5;
    [Header("プレイヤーが向く方向")]
    [SerializeField] GameObject _lookAtObj;
    [Header("巨大化する最大の大きさ")]
    [SerializeField] float _maxSize;
    [Header("GunScript")]
    [SerializeField] GunScript _gunScript;
    [Header("細菌を拾ったときに増えるアモの数")]
    [SerializeField] int _addAmo;

    public event Action<int> _sizeChanger;

    [Tooltip("方向ベクトルを保存する")]
    Vector3 _dir;
    [Tooltip("RigidBody")]
    Rigidbody _rb;
    bool _endBool = false;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_endBool)
        {
            InputPlayer();

            SizeChange();

            CameraControl();
        }

    }


    /// <summary>
    /// カメラ移動に関する関数
    /// </summary>
    void CameraControl()
    {
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

    /// <summary>
    /// プレイヤーのサイズを変える
    /// </summary>
    void SizeChange()
    {
        //マガジンのサイズからサイズの割合を出す
        float Size = _maxSize * (_gunScript.CurMagazineAmo / _gunScript.MagazineSize);
        gameObject.transform.localScale = new Vector3(Size, Size, Size);

        //消滅してしまった場合
        if (Size == 0)
        {
            _sizeChanger((int)Size);
        }
    }

    /// <summary>
    /// ゲームが終了した場合この関数を呼ぶ
    /// </summary>
    public void GameEndBool()
    {
        _endBool = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Heal"))
    //    {
    //        _gunScript.AddAmo(_addAmo);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Heal"))
        {
            _gunScript.AddAmo(_addAmo);
        }
    }
}
