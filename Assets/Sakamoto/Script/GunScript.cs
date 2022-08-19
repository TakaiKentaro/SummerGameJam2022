using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("マガジンのサイズ")]
    [Range(0,10),SerializeField] float _magagineSize = 10;
    public float MagazineSize => _magagineSize;

    [Header("銃の発射レート")]
    [SerializeField] float _fireRate = 0;
    [Header("フルオートにできるかどうか")]
    [SerializeField] bool _isFullAuto = false;
    [Header("弾のゲームオブジェクト")]
    [SerializeField] GameObject _bulletPrefab;
    [Header("残弾数のImageのList")]
    [SerializeField] GameObject[] FillList = new GameObject[10];
    [Header("AudioSource")]
    [SerializeField] AudioSource _audio;
    [Header("銃を打つ音")]
    [SerializeField] AudioClip _shotClip;

    [Tooltip("リロード中かどうか")]
    bool _isReloading = false;
    [Tooltip("現在の弾の数")]
    float _curMagazineAmo;
    public float CurMagazineAmo => _curMagazineAmo;
    [Tooltip("弾の時間カウント用")]
    float _fireTime = 0;

    IEnumerator _fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _curMagazineAmo = _magagineSize;
    }

    // Update is called once per frame
    void Update()
    {
        //発射ボタンを押したとき
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("売ってるよ");
            _fireCoroutine = RepeatFire();
            StartCoroutine(_fireCoroutine);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("銃を止めた魚");
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
            Debug.Log("鬱");
            DoFire();
            if (!_isFullAuto) yield break;
            yield return new WaitForSeconds(_fireRate);
        }
    }

    void DoFire()
    {

        //銃を打つ音
      //  _audio.PlayOneShot(_shotClip);

        //Debug.Log("Fire");
        _fireTime = Time.time;

        //UIのライフを減らす
        FillList[(int)_curMagazineAmo - 1].SetActive(false);
        //弾を減らす
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
        //弾を生成する
        GameObject obj = Instantiate(_bulletPrefab, barrelPos, Quaternion.LookRotation(fireRot));
    }

    /// <summary>
    /// アモを追加するスクリプト
    /// </summary>
    public void AddAmo(int amo) 
    {
        if (_curMagazineAmo >= _magagineSize) return;
        _curMagazineAmo += amo;
        //増えた玉野文ライフのUIをTrueにする
        FillList[(int)_curMagazineAmo - 1].SetActive(true);

    }
}
