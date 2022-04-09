using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    public void ReturnToMenu(){
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Music"));
        SceneManager.LoadScene(0);
    }
}
