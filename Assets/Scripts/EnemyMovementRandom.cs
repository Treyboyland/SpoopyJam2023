using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementRandom : MonoBehaviour
{
    [SerializeField]
    Vector4 restrictions;

    [SerializeField]
    Vector2 secondsPerMove;

    [SerializeField]
    Vector2 secondsBetweenMove;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(restrictions.x, restrictions.y);
        float y = Random.Range(restrictions.z, restrictions.w);

        return new Vector3(x, y, transform.position.z);
    }

    float GetRandom(Vector2 range)
    {
        return Random.Range(range.x, range.y);
    }

    IEnumerator LerpPosition()
    {
        float elapsed = 0;
        float total = GetRandom(secondsPerMove);
        Vector3 start = transform.position;
        Vector3 end = GetRandomPosition();

        while (elapsed < total)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, elapsed / total);
            yield return null;
        }

        transform.position = end;
    }

    IEnumerator Movement()
    {
        while (true)
        {
            yield return StartCoroutine(LerpPosition());
            yield return new WaitForSeconds(GetRandom(secondsBetweenMove));
        }
    }
}
