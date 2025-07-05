using UnityEngine;
using DesignPatterns.Singleton;
using System.Collections.Generic;

public class ServerPlayerSpawnPoints : Singleton<ServerPlayerSpawnPoints>
{
    [SerializeField]
    private List<GameObject> m_SpawnPoints;
    public GameObject GetRandomSpawnPoint()
    {
        if (m_SpawnPoints.Count == 0)
            return null;
        return m_SpawnPoints[Random.Range(0, m_SpawnPoints.Count)];
    }
}
