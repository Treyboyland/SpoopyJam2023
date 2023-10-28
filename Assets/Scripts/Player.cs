using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.WSA;

public class Player : MonoBehaviour
{
    [SerializeField]
    int startingLives;

    int lives;

    int combo;

    public int Combo
    {
        get => combo;
        protected set
        {
            combo = value;
            OnComboUpdated.Invoke();
        }
    }

    public int Score
    {
        get => score;
        protected set
        {
            score = value;
            OnScoreUpdated.Invoke();
        }
    }

    int score = 0;

    static Player _instance;

    public static Player PlayerRef => _instance;

    public UnityEvent OnDeath;

    public UnityEvent OnDamage;

    public UnityEvent OnResetCombo;
    public UnityEvent<int> OnAddCombo;
    public UnityEvent OnComboUpdated;

    public UnityEvent<int> OnAddScore;
    public UnityEvent<Enemy> OnEnemyDefeated;

    public UnityEvent OnScoreUpdated;


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
        OnResetCombo.AddListener(() => Combo = 0);
        OnAddScore.AddListener(toAdd => Score += toAdd);
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
