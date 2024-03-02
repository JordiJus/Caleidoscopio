using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public bool canSpawn = true; // 1
    public GameObject AsteroidPrefab; // 2
    public List<Transform> AsteroidSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns;
    private List<GameObject> AsteroidList = new List<GameObject>(); // 5
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnAsteroid()
    {
        Vector3 randomPosition = AsteroidSpawnPositions[Random.Range(0, AsteroidSpawnPositions.Count)].position; // 1
        GameObject asteroid = Instantiate(AsteroidPrefab, randomPosition, AsteroidPrefab.transform.rotation); // 2
        AsteroidList.Add(asteroid); // 3
        asteroid.GetComponent<AsteroidController>().SetSpawner(this); 
    }

    private IEnumerator SpawnRoutine() {
        while (canSpawn) {
            SpawnAsteroid(); // 3
    yield return new WaitForSeconds(timeBetweenSpawns); // 4
                                                        }
    }
}