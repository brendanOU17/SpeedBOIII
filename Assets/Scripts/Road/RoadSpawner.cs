using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 30f;
    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r=>r.transform.position.z).ToList();
        }
    }

   public void SpawnRoad()
    {
        GameObject spawnRoad = roads[0];
        roads.Remove(spawnRoad);
        float newZCoordinate = roads[roads.Count - 1].transform.position.z + offset;
        spawnRoad.transform.position = new Vector3(0,0,newZCoordinate);
        roads.Add(spawnRoad); 
    }
}
