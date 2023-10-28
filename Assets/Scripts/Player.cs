using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    int startingLives;

    int lives;

    static Player _instance;

    public static Player PlayerRef => _instance;

    public UnityEvent OnDeath;

    public UnityEvent OnDamage;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = startingLives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damgage(int damage)
    {
        lives = Mathf.Max(lives - damage, 0);

        if (lives <= 0)
        {
            Die();
            return;
        }
        if (damage > 0)
        {
            OnDamage.Invoke();
        }
    }

    public void Die()
    {
        OnDeath.Invoke();
        gameObject.SetActive(false);
    }

    public void Attack()
    {

    }
}
