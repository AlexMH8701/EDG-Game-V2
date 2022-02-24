using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(projectile, transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
        }
    }
}
