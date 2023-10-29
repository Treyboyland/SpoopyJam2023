using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    int startingLives;

    int lives;

    public int Lives
    {
        get => lives;
        protected set
        {
            lives = value;
            OnLivesUpdated.Invoke();
        }
    }

    int combo;

    public int Combo
    {
        get => combo;
        set
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

    public bool IsAlive { get; protected set; } = true;

    public UnityEvent OnDeath;

    public UnityEvent OnDamage;

    public UnityEvent OnResetCombo;
    public UnityEvent<int> OnAddCombo;
    public UnityEvent OnComboUpdated;

    public UnityEvent<int> OnAddScore;
    public UnityEvent<Enemy> OnEnemyDefeated;

    public UnityEvent OnScoreUpdated;

    public UnityEvent OnLivesUpdated;


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
        Lives = startingLives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damgage(int damage)
    {
        Lives = Mathf.Max(lives - damage, 0);

        if (lives <= 0)
        {
            Die();
            return;
        }
        if (damage > 0)
        {
            OnResetCombo.Invoke();
            OnDamage.Invoke();
        }
    }

    public void Die()
    {
        OnDeath.Invoke();
        IsAlive = false;
        gameObject.SetActive(false);
    }
}
