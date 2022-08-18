using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBullet : MonoBehaviour
{
    [SerializeField] Color m_colors = default;
    [SerializeField] GameObject _child;
    [SerializeField] GameObject _cube;
    [SerializeField] float _waitTime;
    [SerializeField, Range(3, 100)]
    float _forceAngle = 5;

    void Start()
    {

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
    IEnumerator CubeCount()
    {
        GetComponent<Renderer>().material.color = m_colors;
        yield return new WaitForSeconds(_waitTime);
        DestroyEnemy();
    }
    void DestroyEnemy()
    {
        for (int i = 0; i < _forceAngle; i++)
        {
            Instantiate(_child, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
