using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[CreateAssetMenu(fileName = "SpawnThresholds", menuName = "Game/Spawn Threshold")]
public class SpawnThresholds : ScriptableObject
{
    [SerializeField]
    List<SpawnPattern> patterns;

    [Serializable]
    public struct SpawnPattern : IComparable
    {
        public int ComboCount;
        public TimelineAsset Pattern;

        public int CompareTo(object obj)
        {
            if (obj == null || obj is not SpawnPattern)
            {
                return 1;
            }

            return ComboCount.CompareTo(((SpawnPattern)obj).ComboCount);
        }
    }

    public TimelineAsset GetRandomDirector(int combo)
    {
        var possibleTimelines = patterns.Where(x => x.ComboCount <= combo).Select(x => x.Pattern).ToList();

        int randomIndex = UnityEngine.Random.Range(0, possibleTimelines.Count);
        return possibleTimelines[randomIndex];
    }

    public TimelineAsset GetRandomDirectorGreater(int combo)
    {
        int maxValueCombo = patterns.Where(x => x.ComboCount <= combo).Max(x => x.ComboCount);
        var possibleTimelines = patterns.Where(x => x.ComboCount == maxValueCombo).Select(x => x.Pattern).ToList();

        if (possibleTimelines.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, possibleTimelines.Count);
            return possibleTimelines[randomIndex];
        }
        else
        {
            patterns.Sort();
            return patterns[patterns.Count - 1].Pattern;
        }
    }
}
