using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathUI : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverObject;

    // Start is called before the first frame update
    void Start()
    {
        gameOverObject.SetActive(false);
        Player.PlayerRef.OnDeath.AddListener(() => gameOverObject.SetActive(true));
    }
}
