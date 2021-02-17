using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Lights_WE : MonoBehaviour
{
    public Sprite green;
    public Sprite yellow;
    public Sprite red;
    public bool isRed = false;
    public float num;
    public BoxCollider2D boxcollider;
    public GameObject safety;


    // Start is called before the first frame update
    void Start()
    {
        //initialize on red light
        this.gameObject.GetComponent<SpriteRenderer>().sprite = red;
        boxcollider = this.gameObject.GetComponent<BoxCollider2D>();
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
            boxcollider.isTrigger = false;
            yield return new WaitForSeconds(7);

            isRed = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = green;
            boxcollider.isTrigger = true;
            

            yield return new WaitForSeconds(5);

            this.gameObject.GetComponent<SpriteRenderer>().sprite = yellow;

            yield return new WaitForSeconds(2);
            

        }

        }

    
    }
    

