using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Lights : MonoBehaviour
{
    public Sprite green;
    public Sprite yellow;
    public Sprite red;
    public ArrayList cars = new ArrayList();
    public bool isRed = false;
    public float num; 


    // Start is called before the first frame update
    void Start()
    {
        //initialize on red light
        this.gameObject.GetComponent<SpriteRenderer>().sprite = red;
        Invoke("Execute",num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Execute()
    {
        StartCoroutine(trafficLights());
    }

    IEnumerator trafficLights()
    {
        while (true)
        {
            isRed = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = red;

            yield return new WaitForSeconds(5);

            isRed = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = green;
            proceed();

            yield return new WaitForSeconds(4);

            this.gameObject.GetComponent<SpriteRenderer>().sprite = yellow;

            yield return new WaitForSeconds(2);
            StopCoroutine(move());

        }

        IEnumerator move()
        {
            while(cars.Count > 0)
            {
                GameObject car = cars[0] as GameObject;
                car.GetComponent<CarMovement>().isGreen = true;
                car.GetComponent<CarMovement>().trafficLights = null;
                cars.Remove(car);
            }
            yield return new WaitForSeconds(0);
        }

        IEnumerator proceed()
        {
            GameObject triggerStreet = GameObject.Find("TriggerStreet");
            while(triggerStreet.GetComponent<StreetCounter>().objs > 0)
            {
                await Task.Yield();
            }
            StartCoroutine(move());
        }
    }
}
