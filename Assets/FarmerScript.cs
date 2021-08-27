using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerScript : MonoBehaviour
{
   

    private MoveScript MoveScript;
    public int speed;
    public GameObject Farmer;



    private void Awake()
    {
        MoveScript = GetComponent<MoveScript>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Farmer.transform.position = Vector3.MoveTowards(transform.position, MoveScript.Movement(true), Time.deltaTime * speed);
        
    }

   
}
