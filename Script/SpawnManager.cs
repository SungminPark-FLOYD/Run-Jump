using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject spawnGround;
    [SerializeField]
    private GameController gameController;

    private float spawnTime = 0.0f;

    private void FixedUpdate()
    {
        if (gameController.IsGamePlay == false) return;

        spawnTime += Time.deltaTime;

        if (spawnTime >= 1f)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);

            Vector3 position = spawnPoints[spawnIndex].position;
            GameObject clone = Instantiate(spawnGround, position, Quaternion.identity);

            spawnTime = 0.0f;
        }
    }

    /*
    private IEnumerator SpawnGround()
    {
        yield return new WaitForSeconds(3);

        spawnTime += Time.deltaTime;

        if (spawnTime >= 1f)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);

            Vector3 position = spawnPoints[spawnIndex].position;
            GameObject clone = Instantiate(spawnGround, position, Quaternion.identity);

            spawnTime = 0.0f;
        }
    }
    */


    
}
