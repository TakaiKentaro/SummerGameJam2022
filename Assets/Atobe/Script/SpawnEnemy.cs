using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]GameObject _spawnPrefab;
    [SerializeField]GameObject _enemyHead;
    float RespawnTime;
    bool check = false;
    void Start()
    {
        
    }
    void Update()
    {
        /*GameObject enemyObj = GameObject.Find(_spawnPrefab.name);

        if (enemyObj == null)
        {
            GameObject newPlayerObj = Instantiate(_spawnPrefab, transform.position, Quaternion.identity);
            newPlayerObj.name = _spawnPrefab.name;
            this._spawnPrefab.SetActive(true);
        }*/
        if (_spawnPrefab.activeSelf == false)
        {
            
            _spawnPrefab.SetActive(true);
            StartCoroutine("Spawn");
        }
        
    }

    IEnumerator Spawn()
    {
        check = true;
        yield return new WaitForSeconds(5f);
        _spawnPrefab.SetActive(true);
        _enemyHead.GetComponent<Renderer>().material.color = Color.white;
        check = false;
    }
}