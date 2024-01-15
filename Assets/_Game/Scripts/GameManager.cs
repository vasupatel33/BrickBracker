using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftBorder, RightBorder, UpBorder, DownBorder, parent;
    [SerializeField] List<GameObject> AllBricks;

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
    private void Start()
    {
        for(int i= 1; i <= 5; i++)
        {
            for(int j=1; j <= 4; j++)
            {
                GameObject g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)],parent.transform);
                g.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
                g.transform.position = new Vector3(j * 1.2f,i,0);
            }
        }
        float val = Screen.height / 2;
        parent.transform.position = new Vector3();
    }
    public bool isRelease;
    Vector3 currentPos;
    float currentPosY;
    float currentPosX;
    private void Update()
    {
        if (!isRelease)
        {
            BallObject.transform.position = new Vector3(paddleObject.transform.position.x, paddleObject.transform.position.y + 0.5f, paddleObject.transform.position.z);
            BallTargetObject.transform.position = new Vector3(BallObject.transform.position.x, BallObject.transform.position.y + 0.5f, BallObject.transform.position.z);
            //Debug.Log("Release called");
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPosX = Mathf.Clamp(currentPos.x, -3, 3);
                currentPosY = Mathf.Abs(currentPos.y);
                Debug.Log("X val = "+currentPosX);
                Debug.Log("YY val = "+currentPosY);
                BallTargetObject.transform.up = new Vector3(currentPosX, currentPosY, 0);
            }
            if (Input.GetMouseButtonUp(0))
            {
                BallObject.transform.up = new Vector3(currentPos.x, currentPosY, 0);
                ThrowBall();
                BallTargetObject.SetActive(false);
                isRelease = true;
            }
        }
    }
    public void ThrowBall()
    {
        BallObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(currentPosX, currentPosY, 0) * 350);
    }
}
