using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  [SerializeField]
  float speed = 4;

    // Update is called once per frame
    void Update()
    {
        Vector2 movementX = new (speed,0);
        transform.Translate(movementX * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Edge"){
            speed = -speed;
        }
    }
}
