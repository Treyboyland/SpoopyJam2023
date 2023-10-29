using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EnemySpawnerOmni : MonoBehaviour
{
    [Header("Spawn Stuff")]

    [SerializeField]
    PlayableDirector director;

    [SerializeField]
    SignalReceiver signalValue;

    [SerializeField]
    SpawnThresholds patterns;

    [SerializeField]
    int numLoops;

    [Header("Direction Stuff")]

    [SerializeField] ISpawnEnemy spawnerUp;

    [SerializeField] ISpawnEnemy spawnerDown;
    [SerializeField] ISpawnEnemy spawnerLeft;
    [SerializeField] ISpawnEnemy spawnerRight;

    [SerializeField]
    List<SpawnCombo> initialCombos;

    [SerializeField]
    List<SpawnCombo> normalCombos;

    Queue<SpawnCombo.Direction> currentCombos = new Queue<SpawnCombo.Direction>();

    int currentLoops;

    // Start is called before the first frame update
    void Start()
    {
        NormalEnqueue(initialCombos);
    }

    List<SpawnCombo.Direction> GetDirections(List<SpawnCombo> possibilites)
    {
        int selectedIndex = Random.Range(0, possibilites.Count);
        return possibilites[selectedIndex].GetCombo();
    }

    void NormalEnqueue(List<SpawnCombo> spawnCombos)
    {
        int index = Random.Range(0, spawnCombos.Count);

        foreach (var comboPiece in spawnCombos[index].GetCombo())
        {
            currentCombos.Enqueue(comboPiece);
        }
    }

    SpawnCombo.Direction GetNextDirection()
    {
        if (currentCombos.Count == 0)
        {
            List<SpawnCombo> allCombos = new List<SpawnCombo>(normalCombos.Count + initialCombos.Count);
            allCombos.AddRange(normalCombos);
            allCombos.AddRange(initialCombos);
            NormalEnqueue(allCombos);
        }

        return currentCombos.Dequeue();
    }


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
        director.playableAsset = patterns.GetRandomDirectorGreater(Player.PlayerRef.Combo);
        director.time = 0;
        director.SetGenericBinding(director.playableAsset.outputs.First().sourceObject, signalValue);
        director.Play();
    }

    ISpawnEnemy GetSpawnerForDirection(SpawnCombo.Direction direction)
    {
        switch (direction)
        {
            case SpawnCombo.Direction.UP:
                return spawnerUp;
            case SpawnCombo.Direction.DOWN:
                return spawnerDown;
            case SpawnCombo.Direction.LEFT:
                return spawnerLeft;
            case SpawnCombo.Direction.RIGHT:
                return spawnerRight;
        }

        return spawnerUp;
    }

    public void Spawn()
    {
        GetSpawnerForDirection(GetNextDirection()).Spawn();
    }
}
