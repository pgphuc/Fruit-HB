using System;
using UnityEngine;

public class Jar : MonoBehaviour
{
    private int count;
    private int tomatoCount = 14;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tomato>().isTomato)
        {
            count++;
            
        }
        if (count == tomatoCount)
            CanvasGameplay.instance.EndGame();
    }

    private void CloseLid()
    {
        //TODO: Close lid with DOMove
    }    
}
