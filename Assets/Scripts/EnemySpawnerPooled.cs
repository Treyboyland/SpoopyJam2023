using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerPooled : ISpawnEnemy
{
    [SerializeField]
    EnemyMovementLerp _prefab;

    public override void Spawn()
    {
        if (!Player.PlayerRef.IsAlive)
        {
            return;
        }
        var enemy = ObjectPool.Instance.Spawn(_prefab);
        enemy.transform.position = transform.position;
        enemy.StartPos = enemy.transform.position;
        enemy.gameObject.SetActive(true);
    }
}
