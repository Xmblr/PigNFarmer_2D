using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHelper : MonoBehaviour
{
    public GameObject Stone;

    private int countOfStones_X = 8;
    private int countOfStones_Y = 4;

    // Start is called before the first frame update
    void Start()
    {
        GameObject MyStones = new GameObject("MyStones");
        MyStones.transform.position = new Vector3(-8.3f, -3.1f, -1);
        float offsetX = 0;
        for (int i = 0; i < countOfStones_X; i++)
        {
            for (int j = 0; j < countOfStones_Y; j++)
            {
                
                Vector3 pos = new Vector3(MyStones.transform.position.x + i*2.2f + offsetX, MyStones.transform.position.y + j*2, -1);
                GameObject stone = Instantiate(Stone, pos, Quaternion.identity) as GameObject;
                stone.transform.parent = MyStones.transform;
                offsetX += 0.25f;
            }
            offsetX = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
