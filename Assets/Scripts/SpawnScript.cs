using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;

    public float xMin = -5f;
    public float xMax = 5f;
	
	void Start () {
        Spawn();
	}
	
	void Spawn()
    {
        float spawnSpeed = PublicSettingsManagerScript.spawnSpeed;
        if (spawnSpeed != 0)
        {
            Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(xMin, xMax), transform.position.y), Quaternion.identity);
            Invoke("Spawn", spawnSpeed);
        }
    }
}
