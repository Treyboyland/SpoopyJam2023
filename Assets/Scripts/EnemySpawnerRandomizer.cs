using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EnemySpawnerRandomizer : MonoBehaviour
{
    [SerializeField]
    PlayableDirector director;

    [Tooltip("Signal Receiver")]
    [SerializeField]
    SignalReceiver signalValue;

    [SerializeField]
    int numLoops;

    [SerializeField]
    SpawnThresholds patterns;

    int currentLoops;

    public void LoopCheck()
    {
        currentLoops++;
        if (currentLoops >= numLoops)
        {
            currentLoops = 0;
            SwapDirector();
        }
    }

    void SwapDirector()
    {
        director.ClearGenericBinding(director.playableAsset.outputs.First().sourceObject);
        //I do not understand this. This is probably not scalable to multiple tracks on timeline.
        director.playableAsset = patterns.GetRandomDirector(Player.PlayerRef.Combo);
        director.SetGenericBinding(director.playableAsset.outputs.First().sourceObject, signalValue);
        director.Play();
    }
}
