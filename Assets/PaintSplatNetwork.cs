using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSplatNetwork : MonoBehaviourPun
{
    List<Color> colors;
    // Start is called before the first frame update
    void Start()
    {
        colors = FindObjectOfType<Crosshair>().colors;
        switch (photonView.OwnerActorNr)
        {
            case 0:
                GetComponent<SpriteRenderer>().color = colors[0];
                Debug.Log(photonView.ControllerActorNr);
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = colors[1];
                Debug.Log(photonView.ControllerActorNr);
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = colors[2];
                Debug.Log(photonView.ControllerActorNr);
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = colors[3];
                Debug.Log(photonView.ControllerActorNr);
                break;
            case 4:
                GetComponent<SpriteRenderer>().color = colors[4];
                Debug.Log(photonView.ControllerActorNr);
                break;
        }
        transform.parent = FindObjectOfType<PaintCanvasBounce>().transform;
    }
}
