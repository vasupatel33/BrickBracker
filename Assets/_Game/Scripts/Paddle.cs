using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.isRelease)
        {
            Vector3 nextPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            nextPos.z = 0;
            nextPos.y = transform.position.y;

            nextPos.x = Mathf.Clamp(nextPos.x, -GameManager.instance.screenSize.x + transform.GetComponent<BoxCollider2D>().size.x / 2, GameManager.instance.screenSize.x - transform.GetComponent<BoxCollider2D>().size.x / 2);
            transform.position = nextPos;
        }
    }
}