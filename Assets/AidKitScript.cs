using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKitScript : MonoBehaviour
{
    private MovementScript movementScript;
    public float SecondsOfLife;
    public float WaitFrom;
    public float WaitTill;

    private bool hasArrived = false;


    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ToAppear();

    }


    void ToAppear()
    {
        if (!hasArrived)
        {
            hasArrived = true;
            StartCoroutine(MoveToPoint());
        }
    }

    private IEnumerator MoveToPoint()
    {

        transform.position = new Vector3(14.24f, -3.65f, -2);
        yield return new WaitForSeconds(Random.Range(WaitFrom, WaitTill));

        movementScript.StartPosition(Random.Range(1, 45));
        //float x = Random.Range(-9.5f, 7);
        //float y = Random.Range(-4.5f, 3 / 3f);

        //transform.position = new Vector3(x, y, -2);


        yield return new WaitForSeconds(SecondsOfLife);

        hasArrived = false;
    }
}
