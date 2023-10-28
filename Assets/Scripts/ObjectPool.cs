using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    static ObjectPool _instance;

    public static ObjectPool Instance => _instance;

    Dictionary<GameObject, List<GameObject>> pool = new Dictionary<GameObject, List<GameObject>>();

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

    GameObject Create(GameObject prefab)
    {
        if (!pool.ContainsKey(prefab))
        {
            pool.Add(prefab, new List<GameObject>());
        }

        var newPrefab = Instantiate(prefab);
        newPrefab.gameObject.SetActive(false);

        pool[prefab].Add(newPrefab);

        return newPrefab;
    }

    public GameObject Spawn(GameObject prefab)
    {
        if (!pool.ContainsKey(prefab))
        {
            return Create(prefab);
        }
        foreach (var obj in pool[prefab])
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return Create(prefab);
    }

    public T Spawn<T>(T prefab) where T : MonoBehaviour
    {
        var newObj = Spawn(prefab.gameObject);

        return newObj.GetComponent<T>();
    }
}
