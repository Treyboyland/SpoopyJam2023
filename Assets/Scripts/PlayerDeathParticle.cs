using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathParticle : MonoBehaviour
{
    [SerializeField]
    GameObject deathObject;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnDeath.AddListener(() => deathObject.gameObject.SetActive(true));
    }
}
