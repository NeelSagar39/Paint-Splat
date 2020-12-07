using Photon.Pun;
using UnityEngine;

public class CanvasPaintHolder : MonoBehaviourPun
{
    public static CanvasPaintHolder instance;
    public GameObject paint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    public void InstantiatePaintOnNetwork(Vector3 localPos, Color color)
    {
        photonView.RPC("InstantiatePaint", RpcTarget.All, localPos, color.r, color.g, color.b);
    }
    [PunRPC]
    public void InstantiatePaint(Vector3 localPos, float r, float g, float b)
    {
        GameObject go = Instantiate(paint);
        go.transform.parent = transform;
        go.transform.localPosition = localPos;
        go.GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1);
    }
}
