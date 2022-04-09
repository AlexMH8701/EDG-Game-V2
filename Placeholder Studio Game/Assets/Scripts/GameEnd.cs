using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public PauseMenu Pause;

    public GameObject Player1;
    public GameObject Player2;

    public GameObject Player1UI;
    public GameObject Player2UI;

    GameObject Timer;
    // Start is called before the first frame update

    public void P1Win(){
        Debug.Log("Player 1 Wins!");
        Pause.Pause();
        Player1UI.SetActive(true);
    }
    public void P2Win(){
        Debug.Log("Player 2 Wins!");
        Pause.Pause();
        Player2UI.SetActive(true);
    }
}
