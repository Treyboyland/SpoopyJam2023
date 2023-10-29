using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitParticle : MonoBehaviour
{
    [SerializeField]
    DisableAfterParticlePlay hitParticle;


    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnDamage.AddListener(SpawnParticle);
    }

    void SpawnParticle()
    {
        var obj = ObjectPool.Instance.Spawn(hitParticle);
        obj.transform.position = transform.position;
        obj.gameObject.SetActive(true);
    }
}
