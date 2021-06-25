using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions
{
    North, South, West, East
}

public class Test : MonoBehaviour
{
    public string name;
    public Directions directions;

    void Start()
    {
        //<, >, ==, <=, >=
        //&& -> AND -> true && true -> true / false && true -> false
        //|| -> Or -> true || true -> true / false || true -> true / false || false -> false
        //!= -> Diferent 

        switch (directions)
        {
            case Directions.North:
                print("Your direction is north");
                break;
            case Directions.South:
            case Directions.East:
                print("Your direction is south or east");
                break;
            default:
                print("Your direction is west");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
