using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public bool isGreen = false;
    public string carDirection;
    public Vector3 direction;
    public GameObject trafficLights;


    // Start is called before the first frame update
    void Start()
    {
 
      
    }

    // Update is called once per frame
    void Update()
    {
        if(isGreen == true)
        {
            switch (carDirection)
            {
                case "North":
                    direction = new Vector3(0, 2 * Time.deltaTime, 0);
                    break;

                case "East":
                    direction = new Vector3(2 * Time.deltaTime, 0, 0);
                    break;

                case "South":
                    direction = new Vector3(0, -2 * Time.deltaTime, 0);
                    break;

                case "West":
                    direction = new Vector3(-2 * Time.deltaTime, 0 ,0);
                    break;

            }

            gameObject.transform.position += direction;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "trafficLights")
        {
            isGreen = !(collision.gameObject.GetComponent<Traffic_Lights>().isRed);

            if(isGreen == false)
            {
                trafficLights = collision.gameObject;
                trafficLights.GetComponent<Traffic_Lights>().cars.Add(gameObject);
            }

        }
        else
        {
            isGreen = collision.gameObject.GetComponent<CarMovement>().isGreen;

            if(isGreen == false)
            {
                trafficLights = collision.gameObject.GetComponent<CarMovement>().trafficLights;
                trafficLights.GetComponent<Traffic_Lights>().cars.Add(gameObject);
            }

        }
    }
}
