using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviourPun
{
    public Transform parent;
    Crosshair crosshair;
    public GameObject paintCanvas;
    public GameObject paint;
    public Collider2D coll;
    bool onTarget;
    Vector3 position;
    public void Start() {
        position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject Canvas = GameObject.Find("Canvas");
        this.transform.SetParent(Canvas.transform);
        paintCanvas = GameObject.Find("PaintCanvas");
        this.transform.position = position;
    }
    public void setCrosshair(Crosshair crosshair_tobe) {
        crosshair = crosshair_tobe;
        print(crosshair);
    }
    public void Shoot_paint() 
    {
        if (!paintCanvas)
            paintCanvas = FindObjectOfType<PaintCanvasBounce>().gameObject;
        coll = paintCanvas.GetComponent<Collider2D>();
        print("cavas");
        //print(new Vector3(crosshair.transform.position.x, crosshair.transform.position.y, -1));
        Debug.Log(coll.bounds.Contains(new Vector3(crosshair.transform.position.x, crosshair.transform.position.y, -1)));
        if (coll.bounds.Contains(new Vector3(crosshair.transform.position.x, crosshair.transform.position.y, -1)))
        {
                onTarget = true;
        }
    }
    void Update() {
        if (onTarget) {
            CanvasPaintHolder.instance.InstantiatePaintOnNetwork(paintCanvas.transform.InverseTransformPoint(new Vector3(crosshair.transform.position.x,crosshair.transform.position.y, -10)), FindObjectOfType<Crosshair>().playerColor());
            GameController.instance.IncrementScore();
            //NetworkServer.Spawn(p);
            onTarget = false;
        }
    }
}
