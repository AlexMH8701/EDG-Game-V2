using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public int WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndScene());
        
    }

    IEnumerator EndScene(){
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene(1);
    }
}
