using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> activeRoads = new List<GameObject>();
    public GameObject[] roadPrefabs;
    public float zSpawn = 0;
    public float offset = 30f;
    public Transform player;
    public int numberOfRoads = 5;
    void Start()
    {
        for (int i = 0; i < numberOfRoads; i++)
        {
            if (i == 0)
                SpawnRoad(0);
            else
                SpawnRoad(Random.Range(0, roadPrefabs.Length));
        }
    }

    void Update()
    {
        if(player.position.z -35 > zSpawn - (numberOfRoads * offset))
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }
    public void SpawnRoad(int roadIndex)
    {
        GameObject road = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation);
        activeRoads.Add(road);
        zSpawn += offset;
    }

    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}
