using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject carPrefab;
    public float respawnTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnCar()
    {
        GameObject car = Instantiate(carPrefab) as GameObject;
    }
}
