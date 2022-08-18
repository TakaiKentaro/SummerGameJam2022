using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("�}�K�W���̃T�C�Y")]
    [SerializeField] int _magagineSize = 0;
    [Header("�e�̔��˃��[�g")]
    [SerializeField] float _fireRate = 0;
    [Header("�t���I�[�g�ɂł��邩�ǂ���")]
    [SerializeField] bool _isFullAuto = false;
    [Header("�e�̃Q�[���I�u�W�F�N�g")]
    [SerializeField] GameObject _bulletPrefab;

    [Tooltip("�����[�h�����ǂ���")]
    bool _isReloading = false;
    [Tooltip("���݂̒e�̐�")]
    float _curMagazineAmo;
    [Tooltip("�e�̎��ԃJ�E���g�p")]
    float _fireTime = 0;

    IEnumerator _fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _curMagazineAmo = _magagineSize;
    }

    // Update is called once per frame
    void Update()
    {
        //���˃{�^�����������Ƃ�
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("�����Ă��");
            _fireCoroutine = RepeatFire();
            StartCoroutine(_fireCoroutine);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("�e���~�߂���");
            StopCoroutine(_fireCoroutine);
            _fireCoroutine = null;
        }
    }

    protected virtual IEnumerator RepeatFire()
    {
        float _fireDelay = Time.time - _fireTime;
        //Debug.Log($"{_fireDelay}");
        if (_fireRate > _fireDelay)
        {
            float a = _fireRate - _fireDelay;
            yield return new WaitForSeconds(a);
        }
        while (true)
        {
            Debug.Log("�T");
            DoFire();
            if (!_isFullAuto) yield break;
            yield return new WaitForSeconds(_fireRate);
        }
    }

    void DoFire()
    {
        if (_isReloading) return;

        if (_curMagazineAmo <= 0)
        {
            Reload();
            return;
        }
        //Debug.Log("Fire");
        _fireTime = Time.time;

        _curMagazineAmo--;

        Vector3 _pos = transform.forward * 2.0f + transform.position;

        Camera cam = Camera.main;
        RaycastHit ray;
        Vector3 firePos = cam.transform.position;
        Vector3 barrelPos = transform.position + transform.forward;
        Vector3 fireRot = transform.forward;
        Debug.DrawRay(firePos, cam.transform.forward * 10000, Color.green, 3);
        if (Physics.Raycast(firePos, cam.transform.forward * 10000, out ray))
        {
            fireRot = ray.point - barrelPos;
        }
        else
        {
            Vector3 nonHitPos = cam.transform.position + cam.transform.forward * 100;
            fireRot = nonHitPos - barrelPos;
        }
        Debug.DrawRay(barrelPos, fireRot, Color.red, 3);
        //�e�𐶐�����
        GameObject obj = Instantiate(_bulletPrefab, barrelPos, Quaternion.LookRotation(fireRot));
    }

    void Reload()
    {


    }
}
