using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private MovementScript movementScript;

    public GameObject Enemy;
    public Sprite DirtySprite;
    public Text Score;



    public float movementDuration;
    public float waitBeforeMoving;
    private bool hasArrived = false;

    void Awake()
    {
        movementScript = GetComponent<MovementScript>();

        movementScript.StartPosition(27);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!hasArrived)
        {
            hasArrived = true;
            int rnd = Random.Range(1, 5);
            StartCoroutine(MoveToPoint(movementScript.Movement(rnd)));
        }

    }
    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        //Debug.Log("start move");
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }
        // finish move of farmer
        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            print("BOOOOOM");

            int currentScore = 0;
            int.TryParse(Score.text, out currentScore);
            Score.text = (currentScore + 5).ToString();

            GetComponent<SpriteRenderer>().sprite = DirtySprite;

            Destroy(other.gameObject);

            if (currentScore % 3 == 0)
            {
                Instantiate(GameObject.Find("Dog"));
            }


        }

    }



}
