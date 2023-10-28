using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ComboThresholds", menuName = "Game/Combo Threshold")]
public class ComboThresholds : ScriptableObject
{
    [SerializeField]
    List<ComboMultiplier> multipliers;

    [Serializable]
    public struct ComboMultiplier : IComparable
    {
        public int ComboCount;
        public float Multiplier;

        public int CompareTo(object obj)
        {
            if(obj == null || obj is not ComboMultiplier)
            {
                return 1;
            }

            return ComboCount.CompareTo(((ComboMultiplier)obj).ComboCount);
        }
    }

    public float GetMultiplier(int combo)
    {
        multipliers.Sort();

        return multipliers.Where(x => x.ComboCount <= combo).Last().Multiplier;
    }
}
