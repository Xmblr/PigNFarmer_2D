using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject TargetPoints;
    public GameObject[] Arr;

    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = TargetPoints.transform.GetChild(0).position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player.transform.Translate(Arr[1].transform.position * 0.01f * Time.deltaTime);
        }

    }
}
