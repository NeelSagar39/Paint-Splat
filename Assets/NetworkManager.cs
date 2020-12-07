using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    bool shouldStart;
    public GameObject loadingSign;
    int maxPlayers = 4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(shouldStart && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel("GameScreen");
            //PhotonNetwork.CurrentRoom.IsOpen = false;
        }
    }

    public void ConnectToRoom()
    {
        Debug.Log("Started Connecting");
        loadingSign.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinRandomRoom(GetRoomProperties(), (byte)maxPlayers);
    }

    Hashtable GetRoomProperties()
    {
        Hashtable room = new Hashtable();
        return room;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        base.OnJoinedRoom();
        shouldStart = true;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Join Room Failed");
        RoomOptions o = new RoomOptions();
        o.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.CreateRoom("Room" + PhotonNetwork.Time + " // " + Random.Range(10, 99), o);
    }
}
