using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackComponent : MonoBehaviour
{
    [SerializeField]
    float upRotation;

    [SerializeField]
    float downRotation;

    [SerializeField]
    float leftRotation;

    [SerializeField]
    float rightRotation;

    public void SetRotationUp()
    {
        SetRotation(upRotation);
    }

    public void SetRotationDown()
    {
        SetRotation(downRotation);
    }

    public void SetRotationLeft()
    {
        SetRotation(leftRotation);
    }

    public void SetRotationRight()
    {
        SetRotation(rightRotation);
    }

    void SetRotation(float angle)
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
