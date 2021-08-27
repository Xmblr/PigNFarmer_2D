using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private MoveScript MoveScript;

    public GameObject Player;
    //public GameObject TargetPoints;
    //private GameObject[,] arrayOfPoints = new GameObject[5, 9];
    //private int CurrentI;
    //private int CurrentJ;

    private void Awake()
    {
        MoveScript = GetComponent<MoveScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

        // move to strat point
        //Player.transform.position = TargetPoints.transform.GetChild(0).position;
        //CurrentI = 2;
        //CurrentJ = -1;

        // set multidimensional array of points
        //int k = 1;
        //for (int i = 0; i < 5; i++)
        //{
        //    for (int j = 0; j < 9; j++)
        //    {
        //        arrayOfPoints[i, j] = TargetPoints.transform.GetChild(k).gameObject;
        //        k++;
        //    }
        //}



    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, MoveScript.Movement(), Time.deltaTime * 5 );

    }

    //Vector3 Movement()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        if (CurrentI > 0)
    //        {
    //            CurrentI--;
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        if (CurrentI < 4)
    //        {
    //            CurrentI++;
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        if (CurrentJ > 0)
    //        {
    //            CurrentJ--;
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        if (CurrentJ < 8)
    //        {
    //            CurrentJ++;
    //        }
    //    }

    //    return arrayOfPoints[CurrentI, CurrentJ].transform.position;

    //}
}



