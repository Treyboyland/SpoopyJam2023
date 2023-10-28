using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int damage;

    [SerializeField]
    int score;

    public static UnityEvent<Vector3> OnSmashed = new UnityEvent<Vector3>();

    public int Score { get => score; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player)
        {
            player.Damgage(damage);
            gameObject.SetActive(false);
            return;
        }

        var attack = other.gameObject.GetComponent<PlayerAttackComponent>();
        if (attack)
        {
            OnSmashed.Invoke(transform.position);
            Player.PlayerRef.OnEnemyDefeated.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
