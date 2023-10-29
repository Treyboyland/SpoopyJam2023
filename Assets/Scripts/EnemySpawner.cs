using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ISpawnEnemy
{
    [SerializeField] GameObject _prefab;

    public override void Spawn()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
