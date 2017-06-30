using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PatrykKonior

public class Spawner : MonoBehaviour {
    public Primitive[] primitivePrefabs;
    public int spawnInterval;
    public Vector2 spawnRange;

	// Use this for initialization
	void Start () {
        spawnRange = new Vector2(4, 4);
        StartCoroutine(SpawnCor(spawnInterval));
	}

    private IEnumerator SpawnCor(float delay) {
        while(true) {
            int i = Random.Range(0, primitivePrefabs.Length);
            Primitive prefabToSpawn = primitivePrefabs[i];

            float x = Random.Range(-spawnRange.x, spawnRange.x);
            float y = 10.0f;
            float z = Random.Range(-spawnRange.y, spawnRange.y);
            Vector3 prefabToSpawnPosition = new Vector3(x, y, z);

            Instantiate(prefabToSpawn, prefabToSpawnPosition + transform.position, Quaternion.identity);

            yield return new WaitForSeconds(delay);
        }
    }
}
