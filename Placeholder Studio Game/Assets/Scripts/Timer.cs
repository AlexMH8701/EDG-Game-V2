using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

     public PauseMenu PauseMenu;
    public TextMeshProUGUI timer;
    public int time = 180;

   public GameEnd end;
    void Start()
    {
        StartCoroutine(countDown());
    }

    IEnumerator countDown() {
        while (time != 0) {
            timer.text = "" + time;
            time -= 1;
            yield return new WaitForSeconds(1);
            Debug.Log(time);
        }
        end.WhoWon();
        yield return null;
    }
}
