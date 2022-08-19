using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]GameObject _spawnPrefab;
    float RespawnTime;
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
            _spawnPrefab.GetComponent<Renderer>().material.color = Color.white;
        }
        
    }
}