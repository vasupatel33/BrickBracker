using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftBorder, RightBorder, UpBorder, DownBorder;

    [SerializeField] GameObject BallObject, BallTargetObject, paddleObject;
    public static GameManager instance;
    public Vector2 screenSize;
    bool isHold;
    private void Awake()
    {
        instance = this;
        Vector2 size = new Vector2(Screen.width, Screen.height);
        screenSize = Camera.main.ScreenToWorldPoint(size);

        LeftBorder.GetComponent<BoxCollider2D>().size = new Vector2(1, screenSize.y * 2);
        LeftBorder.transform.position = new Vector2(-screenSize.x + LeftBorder.GetComponent<BoxCollider2D>().size.x/2 - 1, 0);

        RightBorder.GetComponent<BoxCollider2D>().size = new Vector2(1, screenSize.y * 2);
        RightBorder.transform.position = new Vector2(screenSize.x + RightBorder.GetComponent<BoxCollider2D>().size.x/2 , 0);

        UpBorder.GetComponent<BoxCollider2D>().size = new Vector2(screenSize.x * 2, 1);
        UpBorder.transform.position = new Vector2(0, screenSize.y - UpBorder.GetComponent<BoxCollider2D>().size.y / 2 + 1);

        DownBorder.GetComponent<BoxCollider2D>().size = new Vector2(screenSize.x * 2, 1);
        DownBorder.transform.position = new Vector2(0, -screenSize.y + DownBorder.GetComponent<BoxCollider2D>().size.y / 2 - 1);
    }
    public bool isRelease;
    Vector3 currentPos;
    private void Update()
    {
        if (!isRelease)
        {
            BallTargetObject.transform.position = new Vector3(BallObject.transform.position.x, BallObject.transform.position.y + 0.5f, BallObject.transform.position.z);
            Debug.Log("Release called");
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float currentPosX = Mathf.Clamp(currentPos.x, -3, 3);
                float currentPosY = Mathf.Abs(currentPos.y);
                Debug.Log("X val = "+currentPosX);
                Debug.Log("YY val = "+currentPosY);
                BallTargetObject.transform.up = new Vector3(currentPosX, currentPosY, 0);
            }
            if (Input.GetMouseButtonUp(0))
            {
                ThrowBall();
                BallTargetObject.SetActive(false);
                isRelease = true;
            }
        }
    }
    public void ThrowBall()
    {
        BallObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(currentPos.x, currentPos.y, 0) * 200);
    }
}
