using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().flipped)
        {
            _rigidbody.velocity = new Vector2(-10, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector2(10, 0);
        }
        StartCoroutine(despawn());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

    IEnumerator despawn() {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        yield return null;
    }
}
