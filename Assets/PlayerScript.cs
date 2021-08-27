using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject TargetPoints;
<<<<<<< HEAD
    public GameObject[] Arr;
=======
    private GameObject[,] arrayOfPoints = new GameObject[5, 9];
    private int CurrentI;
    private int CurrentJ;


>>>>>>> parent of 39223fe... Movement logic moved to another file.

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        Player.transform.position = TargetPoints.transform.GetChild(0).position;
        
=======


        // move to strat point
        Player.transform.position = TargetPoints.transform.GetChild(0).position;
        CurrentI = 2;
        CurrentJ = -1;

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



>>>>>>> parent of 39223fe... Movement logic moved to another file.
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player.transform.Translate(Arr[1].transform.position * 0.01f * Time.deltaTime);
        }

    }
=======

        transform.position = Vector3.MoveTowards(transform.position, Movement(), Time.deltaTime * 5 );

    }

    Vector3 Movement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurrentI > 0)
            {
                CurrentI--;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurrentI < 4)
            {
                CurrentI++;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CurrentJ > 0)
            {
                CurrentJ--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CurrentJ < 8)
            {
                CurrentJ++;
            }
        }

        return arrayOfPoints[CurrentI, CurrentJ].transform.position;



    }
>>>>>>> parent of 39223fe... Movement logic moved to another file.
}
