using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public GameObject TargetPoints;
    public Sprite spriteU;
    public Sprite spriteD;
    public Sprite spriteL;
    public Sprite spriteR;

    private GameObject[,] arrayOfPoints = new GameObject[5, 9];
    private int CurrentI;
    private int CurrentJ;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private float SWIPE_THRESHOLD = 20f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPosition(int indexStartPoint)
    {

        // set multidimensional array of points
        int counter = 1;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                arrayOfPoints[i, j] = TargetPoints.transform.GetChild(counter).gameObject;
                if (indexStartPoint == counter)
                {
                    // move to strat point
                    transform.position = TargetPoints.transform.GetChild(counter).position;
                    CurrentI = i;
                    CurrentJ = j;
                }

                // move to strat point

                if (indexStartPoint == 0)
                {
                    transform.position = TargetPoints.transform.GetChild(indexStartPoint).position;
                    CurrentI = 2;
                    CurrentJ = -1;
                }
                counter++;
            }
        }
    }

    public Vector3 Movement(int direction)
    {
        try
        {

            // if touchscreen
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                }

                //Detects swipe after finger is released
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    direction = checkSwipe();
                }
            }


            // if keyboard
            if ((Input.GetKeyDown(KeyCode.UpArrow) || direction == 1) && CurrentI > 0)
            {
                CurrentI--;
                GetComponent<SpriteRenderer>().sprite = spriteU;
            }

            if ((Input.GetKeyDown(KeyCode.DownArrow) || direction == 2) && CurrentI < 4)
            {
                CurrentI++;
                GetComponent<SpriteRenderer>().sprite = spriteD;
            }

            if ((Input.GetKeyDown(KeyCode.LeftArrow) || direction == 3) && CurrentJ > 0)
            {
                CurrentJ--;
                GetComponent<SpriteRenderer>().sprite = spriteL;
            }

            if ((Input.GetKeyDown(KeyCode.RightArrow) || direction == 4) && CurrentJ < 8)
            {
                CurrentJ++;
                GetComponent<SpriteRenderer>().sprite = spriteR;
            }


            return arrayOfPoints[CurrentI, CurrentJ].transform.position;
        }
        catch (IndexOutOfRangeException ex)
        {
            return TargetPoints.transform.GetChild(0).position; ;
        }

    }

    int checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                return 1;
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                return 2;
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                return 4;
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                return 3;
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {

            //Debug.Log("No Swipe!");
        }

        return 0;
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
