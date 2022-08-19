using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletScript : MonoBehaviour
{
    [Header("RigibBodyのコンポーネント")]
    [SerializeField]Rigidbody _rb;

    [Header("弾のスピード")]
    [SerializeField] float _speed = 5;

    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("=Player=/Player");
        gameObject.transform.localScale = _player.transform.localScale;

        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _speed, ForceMode.Impulse);

        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
