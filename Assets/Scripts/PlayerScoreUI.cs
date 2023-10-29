using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    ComboThresholds comboThresholds;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnEnemyDefeated.AddListener(AddScore);
        Player.PlayerRef.OnScoreUpdated.AddListener(UpdateScore);
        UpdateScore();
    }

    void AddScore(Enemy enemy)
    {
        float multiplier = comboThresholds.GetMultiplier(Player.PlayerRef.Combo);
        int toAdd = (int)(enemy.Score * multiplier);
        Player.PlayerRef.OnAddScore.Invoke(toAdd);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + Player.PlayerRef.Score;
    }
}
