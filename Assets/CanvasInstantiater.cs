using UnityEngine;
using Photon.Pun;

public class CanvasInstantiater : MonoBehaviour
{
    public static CanvasInstantiater instance;
    public GameObject canvasObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (PhotonNetwork.IsMasterClient)
            {
                GameObject canvas = PhotonNetwork.Instantiate("PaintCanvas", canvasObject.transform.position, canvasObject.transform.rotation);
                FindObjectOfType<Shoot>().paintCanvas = canvas;
            }
            GameObject crosshair = PhotonNetwork.Instantiate("Crosshair 1", Vector3.zero - Vector3.forward * 10, Quaternion.identity);
            FindObjectOfType<Shoot>().setCrosshair(crosshair.GetComponent<Crosshair>());
        }
        else if (instance != this)
            Destroy(gameObject);
    }
}
