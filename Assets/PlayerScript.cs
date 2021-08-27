using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private MoveScript MoveScript;

    public GameObject Player;


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

        transform.position = Vector3.MoveTowards(transform.position, MoveScript.Movement(), Time.deltaTime * 5 );

    }


}



