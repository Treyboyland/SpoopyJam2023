using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    Vector3 upPosition;

    [SerializeField]
    Vector3 downPosition;

    [SerializeField]
    Vector3 leftPosition;

    [SerializeField]
    Vector3 rightPosition;

    [SerializeField]
    PlayerAttackComponent attackObject;

    public static UnityEvent<int> OnAddCombo = new UnityEvent<int>();
    public static UnityEvent<int> OnComboUpdated = new UnityEvent<int>();

    public static UnityEvent OnComboReset = new UnityEvent();

    bool enemyDefeated = false;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnEnemyDefeated.AddListener((unused) => enemyDefeated = true);
    }

    // Update is called once per frame
    void Update()
    {
        MoveAttack();
    }

    void MoveAttack()
    {
        bool activateObject = true;
        if (Input.GetButton("Up"))
        {
            transform.position = upPosition;
            attackObject.SetRotationUp();
        }
        else if (Input.GetButton("Down"))
        {
            transform.position = downPosition;
            attackObject.SetRotationDown();
        }
        else if (Input.GetButton("Left"))
        {
            transform.position = leftPosition;
            attackObject.SetRotationLeft();
        }
        else if (Input.GetButton("Right"))
        {
            transform.position = rightPosition;
            attackObject.SetRotationRight();
        }
        else
        {
            activateObject = false;
        }
        if (attackObject.gameObject.activeInHierarchy && !activateObject)
        {
            CheckCombo();
        }
        attackObject.gameObject.SetActive(activateObject);
    }

    void CheckCombo()
    {
        if(!enemyDefeated)
        {
            Player.PlayerRef.OnResetCombo.Invoke();
        }
        enemyDefeated = false;
    }
}
