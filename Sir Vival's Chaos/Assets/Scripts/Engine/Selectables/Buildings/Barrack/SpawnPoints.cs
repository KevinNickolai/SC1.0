using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints{

    /// <summary>
    /// The underlying list of spawn points
    /// </summary>
    private List<Vector3> spawnPoints;

    /// <summary>
    /// current position of the spawn point we will serve next
    /// </summary>
    private int pos;

    /// <summary>
    /// SpawnPoints constructor
    /// </summary>
    /// <param name="initialPoint">the first point in the SpawnPoints object</param>
    public SpawnPoints(Vector3 initialPoint)
    {
        spawnPoints = new List<Vector3>();
        spawnPoints.Add(initialPoint);
        pos = 0;
    }

    /// <summary>
    /// SpawnPoints constructor
    /// </summary>
    /// <param name="spawns">List of spawn points for the SpawnPoints object</param>
    public SpawnPoints(List<Vector3> spawns)
    {
        if(spawns.Count == 0)
        {
            Debug.LogWarning("SpawnPoints object initialized with empty Spawn List; \n Make sure constructor passed list with more than 0 elements in it.");
            spawns.Add(new Vector3(0, 0, 0));
        }
        spawnPoints = spawns;
        pos = 0;
    }

    /// <summary>
    /// Add a spawn point
    /// </summary>
    /// <param name="point"></param>
    public void AddSpawnPoint(Vector3 point)
    {
        spawnPoints.Add(point);
    }

    /// <summary>
    /// Get the next spawn point in the list of spawn points
    /// </summary>
    /// <returns>Vector3 of the next spawn point</returns>
    public Vector3 GetNextSpawnPoint()
    { 
        //making sure we're in bounds of spawnpoints to give out
        if(pos >= spawnPoints.Count)
        {
            pos = 0;
        }

        return spawnPoints[pos];
    }

}
