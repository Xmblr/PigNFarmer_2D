using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private MovementScript movementScript;
    private HealthScript healthScript;
    public Image HearthImage;

    public int speed;

    //private int countOfHealt = 3;



    void Awake()
    {
        movementScript = GetComponent<MovementScript>();
        movementScript.StartPosition(0);

        healthScript = GetComponent<HealthScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    //Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movementScript.Movement(0), Time.deltaTime * speed);

        if(healthScript.health == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            movementScript.StartPosition(0);
            healthScript.health--;
        }

        if (other.gameObject.tag == "AidKit")
        {
            other.gameObject.transform.position = new Vector3(-11.5f, -4, -2);
            healthScript.health++;
        }

    }



}
