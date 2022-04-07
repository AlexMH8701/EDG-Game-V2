using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    Animator leftDoorAnimator;
    Animator rightDoorAnimator;
    private void Start() {
        leftDoorAnimator = leftDoor.GetComponent<Animator>();
        rightDoorAnimator = rightDoor.GetComponent<Animator>();
    }
    public void PlayGame() {
        StopAllCoroutines();
        StartCoroutine(OpenDoors());
    }

    public void QuitGame() {
        Application.Quit();
    }
    
    IEnumerator OpenDoors() {
        print("HI");
        leftDoorAnimator.SetTrigger("open");
        rightDoorAnimator.SetTrigger("open");
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(1);
    }
}
