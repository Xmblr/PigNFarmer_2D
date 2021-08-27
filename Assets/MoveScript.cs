using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private int rnd;

    public GameObject Person;

    public GameObject TargetPoints;
    private GameObject[,] arrayOfPoints = new GameObject[5, 9];
    private int CurrentI;
    private int CurrentJ;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private bool detectSwipeOnlyAfterRelease = true;

    private float SWIPE_THRESHOLD = 1f;


    private void Awake()
    {
        //move Person to strat point
        if (Person.name == "Player")
        {
            Person.transform.position = TargetPoints.transform.GetChild(0).position;
            CurrentI = 2;
            CurrentJ = -1;
        }
        else
        {
            CurrentI = 4;
            CurrentJ = 8;
        }


        // set multidimensional array of points
        int k = 1;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                arrayOfPoints[i, j] = TargetPoints.transform.GetChild(k).gameObject;
                k++;
            }
        }
    }

    public Vector3 Movement(bool _bot)
    {
        if (_bot == true)
        {
            
            rnd = (int)Random.Range(1, 700);
        }


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) || rnd == 1)
        {
            if (CurrentI > 0)
            {
                CurrentI--;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || rnd == 2)
        {
            if (CurrentI < 4)
            {
                CurrentI++;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || rnd == 3)
        {
            if (CurrentJ > 0)
            {
                CurrentJ--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || rnd == 4)
        {
            if (CurrentJ < 8)
            {
                CurrentJ++;
            }
        }

        return arrayOfPoints[CurrentI, CurrentJ].transform.position;

    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                CurrentI--;
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                CurrentI++;
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                CurrentJ++;
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                CurrentJ--;
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }


}
