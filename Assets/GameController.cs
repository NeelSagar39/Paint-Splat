using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviourPun
{
    public static GameController instance;
    public Text text;
    public GameObject window;
    public float time = 60f;
    public int actorNumber;
    Dictionary<int, int> scores = new Dictionary<int, int>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for(int i = 1; i < 5; i++)
        {
            scores.Add(i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            text.text = Mathf.FloorToInt(time).ToString();
        }
        else
        {
            PhotonNetwork.Disconnect();
            window.SetActive(true);
            showScore();
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void IncrementScore()
    {
        //showScore();
        actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        int score = scores[actorNumber] + 1;
        photonView.RPC("SetScoreNetwork", RpcTarget.All, actorNumber, score);
    }

    [PunRPC]
    public void SetScoreNetwork(int actorNumber, int score)
    {
        scores[actorNumber] = score;
        foreach(int key in scores.Keys)
        {
            Debug.Log(key + " ," + scores[key]);
        }
    }
    public void showScore() {
        GameObject txt = window.transform.Find("Text").gameObject;
        Text new_txt = txt.GetComponent<UnityEngine.UI.Text>();
        new_txt.text = "";
        foreach (int key in scores.Keys)
        {
           new_txt.text +="Player:"+key + " Score: " + scores[key] + "\n";
        }
        print(txt.GetComponent<UnityEngine.UI.Text>().text);
    }
}
