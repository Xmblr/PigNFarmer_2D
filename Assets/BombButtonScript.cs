using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButtonScript : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject Player;


    public float waitBeforeInstall;
    private bool hasArrived = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IfPressed();
        }

    }


    void OnMouseDown()
    {
        IfPressed();
    }

    void IfPressed()
    {
        if (!hasArrived)
        {
            hasArrived = true;
            StartCoroutine(MoveToPoint());
        }
    }

    private IEnumerator MoveToPoint()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
        GameObject bomb = Instantiate(Bomb);
        bomb.transform.position = Player.transform.position;

        yield return new WaitForSeconds(waitBeforeInstall);

        GetComponent<SpriteRenderer>().color = Color.white;
        hasArrived = false;
    }
}
