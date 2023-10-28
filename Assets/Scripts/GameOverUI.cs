using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    GameObject gameOverStuff;

    // Start is called before the first frame update
    void Start()
    {
        gameOverStuff.SetActive(false);
        Player.PlayerRef.OnDeath.AddListener(() =>
        {
            scoreText.text = "Score: " + Player.PlayerRef.Score;
            gameOverStuff.SetActive(true);
        });
    }
}
