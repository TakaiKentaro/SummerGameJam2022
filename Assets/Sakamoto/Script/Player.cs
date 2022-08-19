using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("mainCamera�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _mainCamera;
    [Header("Player�̃X�s�[�h")]
    [SerializeField] float _speed = 5;
    [Header("�v���C���[����������")]
    [SerializeField] GameObject _lookAtObj;
    [Header("���剻����ő�̑傫��")]
    [SerializeField] float _maxSize;
    [Header("GunScript")]
    [SerializeField] GunScript _gunScript;
    [Header("�׋ۂ��E�����Ƃ��ɑ�����A���̐�")]
    [SerializeField] int _addAmo;

    public event Action<int> _sizeChanger;

    [Tooltip("�����x�N�g����ۑ�����")]
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
    /// �J�����ړ��Ɋւ���֐�
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
        //���͏���
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        //�����x�N�g�����擾
        _dir = new Vector3(x, 0, z);
    }

    /// <summary>
    /// �v���C���[�̃T�C�Y��ς���
    /// </summary>
    void SizeChange()
    {
        //�}�K�W���̃T�C�Y����T�C�Y�̊������o��
        float Size = _maxSize * (_gunScript.CurMagazineAmo / _gunScript.MagazineSize);
        gameObject.transform.localScale = new Vector3(Size, Size, Size);

        //���ł��Ă��܂����ꍇ
        if (Size == 0)
        {
            _sizeChanger((int)Size);
        }
    }

    /// <summary>
    /// �Q�[�����I�������ꍇ���̊֐����Ă�
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
