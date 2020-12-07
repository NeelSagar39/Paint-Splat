using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviourPun
{
    public List<Color> colors;
    // Start is called before the first frame update
    Joystick joystick;
    GameObject shoot;

    private void Awake()
    {
        if (!photonView.IsMine)
            gameObject.SetActive(false);
    }
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        shoot = GameObject.Find("Button");
        shoot.GetComponent<Shoot>().setCrosshair(this);
        GetComponent<SpriteRenderer>().color = playerColor();

    }

    public Color playerColor()
    {
        Debug.Log(photonView.ControllerActorNr);
        switch (photonView.ControllerActorNr)
        {
            case 1:
                return colors[1];
            case 2:
                return colors[2];
            case 3:
                return colors[3];
            case 4:
                return colors[4];
        }
        return Color.white;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            MoveCrossHair(new Vector2(joystick.Horizontal, joystick.Vertical));
        }

    }

    void MoveCrossHair(Vector2 direction) {
        transform.Translate(direction * 300 * Time.deltaTime);
    }
}
