using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStart : MonoBehaviour
{
    
    public GameObject start;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Wait());
        
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(.5f);
        start.SetActive(false);
    }

}
