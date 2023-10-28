using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementLerp : MonoBehaviour
{
    [SerializeField]
    float secondsToReach;

    float elapsed = 0;

    Vector3 startPos;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        elapsed = 0;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if (Player.PlayerRef != null)
        {
            transform.position = Vector3.Lerp(startPos, Player.PlayerRef.transform.position, elapsed / secondsToReach);
        }
    }
}
