using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;

public class PlayerComboUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [Tooltip("How high combo must be before text shows")]
    [SerializeField]
    int comboThreshold;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnComboUpdated.AddListener(UpdateText);
        UpdateText();
    }

    void UpdateText()
    {
        textBox.text = Player.PlayerRef.Combo < comboThreshold ? "" : "" + Player.PlayerRef.Combo + " Combo!";
    }
}
