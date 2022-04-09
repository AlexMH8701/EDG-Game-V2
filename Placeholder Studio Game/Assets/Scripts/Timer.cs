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
    void Start()
    {
        StartCoroutine(countDown());
    }
    private void Update() {
        if (time == 0) {
            SceneManager.LoadScene("End Screen");
        }
    }

    IEnumerator countDown() {
        while (time != 0) {
            timer.text = "" + time;
            time -= 1;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
