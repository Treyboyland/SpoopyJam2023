using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    GameObject attackObject;


    // Start is called before the first frame update
    void Start()
    {

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
        }
        else if (Input.GetButton("Down"))
        {
            transform.position = downPosition;
        }
        else if (Input.GetButton("Left"))
        {
            transform.position = leftPosition;
        }
        else if (Input.GetButton("Right"))
        {
            transform.position = rightPosition;
        }
        else
        {
            activateObject = false;
        }
        attackObject.SetActive(activateObject);
    }
}
