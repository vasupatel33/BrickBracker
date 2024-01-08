using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftBorder, RightBorder, UpBorder, DownBorder;
    private void Awake()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(size);

        LeftBorder.GetComponent<BoxCollider2D>().size = new Vector2(1, screenSize.y * 2);
        LeftBorder.transform.position = new Vector2(-screenSize.x + LeftBorder.GetComponent<BoxCollider2D>().size.x/2 - 1, 0);

        RightBorder.GetComponent<BoxCollider2D>().size = new Vector2(1, screenSize.y * 2);
        RightBorder.transform.position = new Vector2(screenSize.x + RightBorder.GetComponent<BoxCollider2D>().size.x/2 , 0);

        UpBorder.GetComponent<BoxCollider2D>().size = new Vector2(screenSize.x * 2, 1);
        UpBorder.transform.position = new Vector2(0, screenSize.y - UpBorder.GetComponent<BoxCollider2D>().size.y / 2 + 1);

        DownBorder.GetComponent<BoxCollider2D>().size = new Vector2(screenSize.x * 2, 1);
        DownBorder.transform.position = new Vector2(0, screenSize.y - DownBorder.GetComponent<BoxCollider2D>().size.y / 2 + 1);
    }
}
