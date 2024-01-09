using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private void Update()
    {
        Vector3 nextPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        nextPos.z = 0;
        nextPos.y = transform.position.y;

        nextPos.x = Mathf.Clamp(nextPos.x, -GameManager.instance.screenSize.x + transform.GetComponent<BoxCollider2D>().size.x / 2, GameManager.instance.screenSize.x - transform.GetComponent<BoxCollider2D>().size.x / 2);
        transform.position = nextPos;
        Debug.Log("X is = "+ -GameManager.instance.screenSize.x);
        Debug.Log("Box is = "+ transform.GetComponent<BoxCollider2D>().size.x / 2);

    }
}