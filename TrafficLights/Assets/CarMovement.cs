using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    public bool isGreen = false;
    public string carDirection;
    public Vector2 direction;
    public GameObject trafficLights;
    private const float SPEED = 10f;
    public GameObject car;
    public Rigidbody2D rb;
    public BoxCollider2D carCollider;
    private Vector2 bounds;
    public Sprite greenSprite;


    // Start is called before the first frame update
    void Start()
    {
 
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        carCollider = this.gameObject.GetComponent<BoxCollider2D>();
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (carDirection)
        {
            case "North":
                direction = new Vector2(0, -400 * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;

            case "East":
                direction = new Vector2(-400 * Time.deltaTime, 0);
                this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;

            case "South":
                direction = new Vector2(0, 400 * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;

            case "West":
                direction = new Vector2(400 * Time.deltaTime, 0);
                break;

        }
        rb.velocity = direction;
        
        if (this.gameObject.transform.position.x < -12.95)
        {
            Destroy(this.gameObject);
        }
        if (this.gameObject.transform.position.x > 11.95)
        {
            Destroy(this.gameObject);
        }
        if (this.gameObject.transform.position.y < -8.11)
        {
            Destroy(this.gameObject);
        }
        if (this.gameObject.transform.position.y > 7.49)
        {
            Destroy(this.gameObject);
        }


    }   
            

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "safety" )
        {
            if(collision.gameObject.name == "RedCar" || collision.gameObject.name == "RedCar(Clone)")
            {
                this.carCollider.isTrigger = true;
            }
            

        }
        else
        {
            this.carCollider.isTrigger = false;
        }
    }

   




}
