using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitSound : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip hitclip;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnDamage.AddListener(PlaySound);
    }

    void PlaySound()
    {
        source.PlayOneShot(hitclip);
    }
}
