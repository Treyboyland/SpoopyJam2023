using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnCombo", menuName = "Game/Spawn Combo")]
public class SpawnCombo : ScriptableObject
{
    public enum Direction
    {
        UP, DOWN, LEFT, RIGHT
    }

    [Serializable]
    public struct DirectionCount
    {
        public Direction Direction;
        public int Count;
    }

    [SerializeField]
    List<DirectionCount> comboPieces;


    public List<Direction> GetCombo()
    {
        List<Direction> directions = new List<Direction>();

        foreach (var combo in comboPieces)
        {
            for (int i = 0; i < combo.Count; i++)
            {
                directions.Add(combo.Direction);
            }
        }

        return directions;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
