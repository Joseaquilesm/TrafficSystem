using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject car;
    float randX;
    Vector2 location;
    public float spawnRate = 2f;
    float nextSpawn = 0;
    string direction;
    public Sprite greenSprite;
    public Sprite redSprite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            location = randomLocation();
            Instantiate(car, location, Quaternion.identity);
            
        }
    }

    private Vector2 randomLocation()
    {
        System.Random r = new System.Random();
        int newLocation;
        newLocation = r.Next(1, 5);
        switch (newLocation)
        {
            case 1:
                location = new Vector2(-5.12f, -0.44f);
                car.GetComponent<CarMovement>().carDirection = "West";
                break;

            case 2:
                location = new Vector2(5.31f, 1.07f);
                car.GetComponent<CarMovement>().carDirection = "East";
                break;

            case 3:
                location = new Vector2(1.13f, -5.13f);
                car.GetComponent<CarMovement>().carDirection = "South";
                    
                break;

            case 4:
                location = new Vector2(-0.13f, 4.22f);
                car.GetComponent<CarMovement>().carDirection = "North";
                
                break;

        }
        return location;
    }
    
}
