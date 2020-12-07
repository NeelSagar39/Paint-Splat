using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCanvasBounce : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Vector2 Lastvelocity;
    public float maxSpeed = 350f;

    public bool isLocal;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Lastvelocity = rb.velocity;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(isLocal)
        {
            //print("HELO");
            var speed = Mathf.Clamp(0, maxSpeed, Lastvelocity.magnitude + 20f);
            var direction = Vector2.Reflect(Lastvelocity.normalized, col.contacts[0].normal);
            rb.velocity = Mathf.Max(speed, 0f) * direction;
            GetComponent<NetworkCanvas>().SendBounceEvent(rb.velocity, transform.position);
        }
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
