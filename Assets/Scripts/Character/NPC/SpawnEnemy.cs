using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnEnemy : NetworkBehaviour
{
    public Transform spawnedObjectParent;
    public GameObject spawnPrefab;
    public float spawnTime;
    private float spawnTimer;

    private void Start()
    {
        if (!isServer)
        {
            Destroy(this);
            return;
        }

        spawnTimer = spawnTime;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) {
            CmdSpawnNewEnemy();
            spawnTimer = spawnTime;
        }
    }

    [Command]
    public void CmdSpawnNewEnemy()
    {
        // create server-side instance
        GameObject obj = (GameObject)Instantiate(spawnPrefab, new Vector3(8,1,0), Quaternion.identity);

        obj.transform.parent = spawnedObjectParent;

        // spawn on the clients
        NetworkServer.Spawn(obj);
    }
}
