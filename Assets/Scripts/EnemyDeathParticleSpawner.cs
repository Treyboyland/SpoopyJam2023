using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathParticleSpawner : MonoBehaviour
{
    [SerializeField]
    DisableAfterParticlePlay prefab;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnSmashed.AddListener(SpawnParticle);
    }

    void SpawnParticle(Vector3 position)
    {
        var obj = ObjectPool.Instance.Spawn(prefab);
        obj.transform.position = position;
        obj.gameObject.SetActive(true);
    }
}
