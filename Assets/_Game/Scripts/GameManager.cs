using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftBorder, RightBorder, UpBorder, DownBorder, parent;
    [SerializeField] List<GameObject> AllBricks, AllSelectedBricks, AllSelectAmongSelectedBricls, AllSpecialObjects;

    public List<GameObject> AllBalls;

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
        Debug.Log("Start called");
        if(GameObject.Find("Ball") != null)
        {
            GameObject ball = GameObject.Find("Ball");
            AllBalls.Add(ball);
        }

        AllSelectedBricks.Clear();
        int value = 6;
        Debug.Log("val = "+value);
        GameObject g;


        switch (value)
        {
            case 0:
                Debug.Log("11");
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                        g.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                        g.transform.position = new Vector3(j * 0.9f, i * 0.8f, 0);
                        AllSelectedBricks.Add(g);
                    }
                }
                break;
            case 1:
                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        if (i == 1 || i == 6 || j == 1 || j == 6 )
                        {
                            g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                            g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            g.transform.position = new Vector3(j * 0.8f, i * 0.65f, 0);
                            AllSelectedBricks.Add(g);
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
                            AllSelectedBricks.Add(g);
                        }
                    }
                }

                break;
            case 3:
                int pyramidHeight = 6;

                for (int i = 1; i <= pyramidHeight; i++)
                {
                    int numBricksInRow = i;

                    for (int j = 1; j <= numBricksInRow; j++)
                    {
                        g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                        g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        //g.transform.position = new Vector3((7 - numBricksInRow) * 0.45f + j * 0.9f, i * 0.7f, 0);
                        g.transform.position = new Vector3(j * 0.9f, i * 0.7f, 0);
                        AllSelectedBricks.Add(g);
                    }
                }
                break;

            case 4:
                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        // Create bricks in a diagonal pattern
                        if (i == j || i + j == 7 || i == 1 || i == 6 || j == 1 || j == 6)
                        {
                            g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                            g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            g.transform.position = new Vector3(j * 0.9f, i * 0.7f, 0);
                            AllSelectedBricks.Add(g);
                        }
                    }
                }
                break;
            case 5:
                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        // Create bricks in a zigzag pattern
                        if (i % 2 == 0)
                        {
                            g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                            g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            g.transform.position = new Vector3(j * 0.9f, i * 0.7f, 0);
                            AllSelectedBricks.Add(g);
                        }
                        else
                        {
                            g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                            g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            g.transform.position = new Vector3((7 - j) * 0.9f, i * 0.7f, 0);
                            AllSelectedBricks.Add(g);
                        }
                    }
                }
                break;
            case 6:
                int centerX = 4; // X-coordinate of the center
                int centerY = 4; // Y-coordinate of the center
                int radius = 3;  // Radius of the circular pattern
                int gapSize = 2; // Size of the gap in the center

                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        // Calculate the distance from the current position to the center
                        float distance = Mathf.Sqrt(Mathf.Pow(j - centerX, 2) + Mathf.Pow(i - centerY, 2));

                        // Create bricks in a circular pattern with a central gap
                        if ((distance <= radius || (i >= centerY - gapSize && i <= centerY + gapSize && j >= centerX - gapSize && j <= centerX + gapSize)) && !(i == centerY && j == centerX))
                        {
                            g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                            g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            g.transform.position = new Vector3(j * 0.9f, i * 0.7f, 0);
                            AllSelectedBricks.Add(g);
                        }
                    }
                }
                break;
            case 7:
                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        // Create diagonal lines with gaps
                        if ((i + j) % 2 == 0 || i % 2 != 0)
                        {
                            g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                            g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            g.transform.position = new Vector3(j * 0.9f, i * 0.7f, 0);
                            AllSelectedBricks.Add(g);
                        }
                    }
                }
                break;
            case 8:
                Debug.Log("8");
                for (int j = 1; j <= 6; j++)
                {
                    // Set a specific color for each column
                    Color columnColor = new Color(j / 6.0f, Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));

                    for (int i = 1; i <= 6; i++)
                    {
                        g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                        g.GetComponent<Renderer>().material.color = columnColor;
                        g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        g.transform.position = new Vector3(j * 0.9f, i * 0.7f, 0);
                        AllSelectedBricks.Add(g);
                    }
                }

                break;
            case 9:
                int pyramidHeight2 = 6;

                for (int i = 1; i <= pyramidHeight2; i++)
                {
                    int numBricksInRow = i;

                    for (int j = 1; j <= numBricksInRow; j++)
                    {
                        g = Instantiate(AllBricks[Random.Range(0, AllBricks.Count)], parent.transform);
                        g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        g.transform.position = new Vector3((6 - numBricksInRow) * 0.45f + j * 0.9f, i * 0.7f, 0);
                        AllSelectedBricks.Add(g);
                        //g.transform.position = new Vector3(j * 0.9f, i * 0.7f, 0);
                    }
                }
                break;

            default:
                break;
        }
        parent.transform.position = new Vector2(screenSize.x - (screenSize.x * 2 + 0.1f), screenSize.y - screenSize.y - 0.2f);

        for (int i = 0; i < 5; i++)
        {
            do
            {
                val = Random.Range(0, AllSelectedBricks.Count);
                Debug.Log("Val = " + val);
            } while (AllSelectAmongSelectedBricls.Contains(AllSelectedBricks[val]));
            AllSelectAmongSelectedBricls.Add(AllSelectedBricks[val]);
            AllSelectedBricks[val].GetComponent<BrickManager>().isSpecialObj = true;
        }
    }
    int val;
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
        AllBalls[0].GetComponent<Rigidbody2D>().AddForce(throwDirection * throwSpeed);

        Debug.Log("X pos = "+currentPosX);
        Debug.Log("After = " + currentPosY);
    }
    public void SpecialObjectSpawn(Vector3 spawnPos, GameObject parent)
    {
        int val = Random.Range(0, AllSpecialObjects.Count);
        GameObject g = Instantiate(AllSpecialObjects[val], spawnPos, Quaternion.identity, parent.transform);
    }
    public void GenerateBall()
    {
        Debug.Log("Ball generated");
        Vector2 spawnPos = new Vector2(screenSize.x / 2, screenSize.y / 2);
        GameObject obj = Instantiate(BallObject,spawnPos, Quaternion.identity);
        AllBalls.Add(obj);
        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
    }
    public void CheckingAllBallExist()
    {
        foreach (GameObject obj in AllBalls)
        {
            // Check if the object is null
            if (obj == null)
            {
                Debug.Log("Ball removed");
                AllBalls.Remove(obj);
            }
        }
    }
    public void CheckBrickAvailablity()
    {
        CheckingAllSelectedBrickExist();
        if (AllSelectedBricks.Count <= 0)
        {
            Debug.LogError("Game overrrrrrrrrrrrrr");
        }
        else
        {
            Debug.Log("Else called");
        }
    }
    public void CheckingAllSelectedBrickExist()
    {
        foreach (GameObject obj in AllSelectedBricks)
        {
            // Check if the object is null
            if (obj == null)
            {
                Debug.Log("Ball removed");
                AllSelectedBricks.Remove(obj);
            }
        }
    }
}