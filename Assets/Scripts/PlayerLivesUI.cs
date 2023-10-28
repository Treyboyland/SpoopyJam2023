using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLivesUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnLivesUpdated.AddListener(UpdateLives);
        UpdateLives();
    }

    void UpdateLives()
    {
        textBox.text = "Lives: " + Player.PlayerRef.Lives;
    }
}
