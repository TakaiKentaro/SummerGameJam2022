using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBullet : MonoBehaviour
{
    [SerializeField] Color m_colors = default;
    [SerializeField] GameObject _child;
    [SerializeField] GameObject _cube;
    [SerializeField] float _waitTime;
    [SerializeField] GameObject _head;
    [SerializeField, Range(3, 100)]
    AudioSource _audio;
    
    float _forceAngle = 5;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine("CubeCount");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine("CubeCount");
        }
    }




    IEnumerator CubeCount()
    {
        _audio.Play();
        _head.GetComponent<Renderer>().material.color = m_colors;

        yield return new WaitForSeconds(_waitTime);
        DestroyEnemy();
    }
    void DestroyEnemy()
    {
        for (int i = 0; i < _forceAngle; i++)
        {
            Instantiate(_child, transform.position, Quaternion.identity);
        }
        GameManager.Instance.AdeScore();
        this.gameObject.SetActive(false);
    }
}
