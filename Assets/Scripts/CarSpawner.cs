using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    private GameObject playerCar;
    public List<GameObject> otherCars = new List<GameObject>();
    public List<float> lanesX = new List<float>();
    private List<GameObject> activeCars = new List<GameObject>();
        
    public float minSpawnTime, maxSpawnTime;
    public int minSpawnCount, maxSpawnCount;
    public int spawnOffset;
        
    public static CarSpawner Instance;   
    

    private void Awake()
    {
        Instance = this;        
        playerCar = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        Global.isCarSpawnerOn = true;
        StartCoroutine("SpawnCars");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnCars()
    {
        while (Global.isCarSpawnerOn)
        {
            for (int i = 1; i <= Random.Range(minSpawnCount, maxSpawnCount + 1); i++)
            {
                GameObject selectedCar = otherCars[Random.Range(0, otherCars.Count)];
                Vector3 selectedLane = new Vector3(lanesX[Random.Range(0, lanesX.Count)], playerCar.transform.position.y, playerCar.transform.position.z + spawnOffset);
                GameObject spawnedCar = Instantiate(selectedCar, selectedLane, Quaternion.Euler(0, -90, 0));
                activeCars.Add(spawnedCar);
            }

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
        
    }

    public void RemoveFromActiveCars(GameObject car)
    {
        activeCars.Remove(car);
    }

    public void DestroyActiveCars()
    {
        foreach(GameObject car in activeCars.ToArray())
        {
            activeCars.Remove(car);
            Destroy(car);
        }
        

        

    }
}
