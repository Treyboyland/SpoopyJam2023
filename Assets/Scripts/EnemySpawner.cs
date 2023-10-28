using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab;

    public void Spawn()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
