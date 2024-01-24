using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int value = 2;//Random.Range(0,2);
        GameObject g;
        switch (value)
        {
            case 0:
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                        g.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                        g.transform.position = new Vector3(j * 1f, i * 0.9f, 0);
                    }
                }
                break;
            case 1:
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        if (i == 1 || i == 5 || j == 1 || j == 5 )
                        {
                            g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                            g.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            g.transform.position = new Vector3(j * 1f, i * 0.9f, 0);
                        }
                    }
                }
                break;
            case 2:

                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        if (i == 1 || i == 5 || j == 1 || j == 5)
                        {
                            if (i == 1)
                            {
                                // Instantiate the same object when i == 1
                                g = Instantiate(AllBricks[0], parent.transform);
                            }
                            else if (i == 5)
                            {
                                // Instantiate different objects when i == 5, j == 1, or j == 5
                                g = Instantiate(AllBricks[2], parent.transform);
                            }
                            else if(j == 5)
                            {
                                // For other cases, you can handle it accordingly
                                // For example, instantiate a default object or do nothing
                                g = Instantiate(AllBricks[3], parent.transform);
                            }
                            else if(j == 1)
                            {
                                g = Instantiate(AllBricks[1], parent.transform);
                            }
                            else
                            {
                                g = Instantiate(AllBricks[6], parent.transform);
                            }

                            g.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            g.transform.position = new Vector3(j * 1f, i * 0.9f, 0);
                        }
                    }
                }

                break;
            case 3:
                break;
            case 4:
                break;
            default: 
                break;
        }
        
        parent.transform.position = new Vector2(screenSize.x - (screenSize.x * 2 + 0.2f),screenSize.y - screenSize.y - 0.5f);
    }
    [SerializeField] List<GameObject> AllInstantiatedPref, AllReinstantiatedPref;
    float row, col;
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
                //Debug.Log("X val = " + currentPosX);
                //Debug.Log("YY val = " + currentPosY);
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
    int throwSpeed;
    public void ThrowBall()
    {
            throwSpeed = 200;
        if (currentPosY > 1.2f || currentPosX > 1.2f)
        {
            Debug.Log("Iff");
            throwSpeed = 250;
        }
        else if (currentPosY < 0.5f || currentPosX < 0.5f)
        {
            throwSpeed = 250;
        }
        else
        {
            Debug.Log("else");
            throwSpeed = 220;
        }
        //BallObject.GetComponent<Rigidbody2D>().velocity = new Vector3(currentPosX, currentPosY, 0);
        //BallObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(currentPosX, currentPosY, 0) * throwSpeed);
        Vector2 throwDirection = new Vector2(currentPosX, currentPosY).normalized;

        // Apply force with a fixed magnitude
        BallObject.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwSpeed);

        Debug.Log("X pos = "+currentPosX);
        Debug.Log("After = " + currentPosY);
    }
}
