using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float timeRemaining = 61;
    //public Text Time_value;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            rb.velocity = new Vector2(5f, -2f) * 50;
        }
        if(rand == 1)
        {
            rb.velocity = new Vector2(-5f, 2f) * 50;
        }
    }
}
