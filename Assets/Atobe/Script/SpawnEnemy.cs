using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]private GameObject _spawnPrefab;

    void Update()
    {
        GameObject playerObj = GameObject.Find(_spawnPrefab.name);

        if (playerObj == null)
        {
            GameObject newPlayerObj = Instantiate(_spawnPrefab, transform.position, Quaternion.identity);
            newPlayerObj.name = _spawnPrefab.name;
        }
    }
}