using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkCanvas : MonoBehaviourPunCallbacks
{
    public float interpolationSpeed;

    Vector3 position;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponent<PaintCanvas>().enabled = false;
        }
        else if (photonView.IsMine)
            GetComponent<PaintCanvasBounce>().isLocal = true;
    }

    public void SendBounceEvent(Vector2 velocity, Vector3 position)
    {
        photonView.RPC("SetVelocity", RpcTarget.Others, velocity, position);
    }

    [PunRPC]
    public void SetVelocity(Vector2 velocity, Vector3 position, PhotonMessageInfo info)
    {
        transform.position = position;
        GetComponent<PaintCanvasBounce>().SetVelocity(velocity);
    }
}
