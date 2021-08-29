using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKitScript : MonoBehaviour
{
    public float SecondsOfLife;
    public float WaitFrom;
    public float WaitTill;

    private bool hasArrived = false;


    // Start is called before the first frame update
    void Start()
    {

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

        transform.position = new Vector3(-11.5f, -4, -2);
        yield return new WaitForSeconds(Random.Range(WaitFrom, WaitTill));


        float x = Random.Range(-9.5f, 7);
        float y = Random.Range(-4.5f, 3 / 3f);

        transform.position = new Vector3(x, y, -2);


        yield return new WaitForSeconds(SecondsOfLife);

        hasArrived = false;
    }
}
