/*
* Created by Daniel Mak
*/

using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float border;
    [Min(0)] public float timeBetweenSpawn;

    private GameManager manager;
    private float timer = 0;

	public void Spawn() {
        if (timer >= timeBetweenSpawn) {
            Vector3 spawnPosition;
            while (true) {
                spawnPosition = (Vector2)Camera.main.ScreenToWorldPoint(
                    new Vector3(
                        Random.Range(border, Camera.main.pixelWidth + 1 - border),
                        Random.Range(border, Camera.main.pixelHeight + 1 - border)
                    )
                );

                if (!manager.circle.InsideCenterCircle(spawnPosition)) break;
            }

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            print("Item spawned at " + spawnPosition);

            timer = 0;
        }
    }

    private void Start() {
        manager = GameManager.instance;
    }

    private void Update() {
        if (timer < timeBetweenSpawn) timer += Time.deltaTime;
    }
}