using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public int value; // Valores númericos sin punto decimal (-25550, 20, 0, -80, 9000)
    public float pointValue; //Valores númericos con punto decimal (-8505.9f, 100f, 8734.123f)
    public string wordChain; //Cadenas de palabras (Letras, números, signos, espacios en blanco, etc)
                             //"Aldhair Vera", "Mayra envíame tu pitch", "Heily hace buen pixel art"
                             //"Bryam le pone mucha fuerza al curso", "@ñpx1239]"
    public bool conditional; //Valor verdero o falso (true o false)

    // Start is called before the first frame update
    void Start()
    {
        value = 12+25;
        pointValue = 4%3;
        wordChain = "Me gustan los juegos de nintendo";
        conditional = true;

        print("Value " + value);
        print("Point Value " + pointValue);
        print("wordChain " + wordChain);
        print("Conditional " + conditional);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
