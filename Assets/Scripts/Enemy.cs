using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int damage;

    public UnityEvent OnSmashed;

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

        var attack = other.gameObject.GetComponent<PlayerAttack>();
        if (attack)
        {
            OnSmashed.Invoke();
            gameObject.SetActive(false);
        }
    }
}
