using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    bool isFireBall;
    // Update is called once per frame
    void Update()
    {
        //if (!isRelease)
        //{
        //    transform.position = new Vector3( paddle.transform.position.x, paddle.transform.position.y + 0.4f, paddle.transform.position.z);
        //} 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Over")
        {
            Debug.Log("overr");
            if (GameManager.instance.AllBalls.Count == 0)
            {
                Debug.Log("Over");
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("Else called");
                Destroy(this.gameObject);
                GameManager.instance.AllBalls.Remove(this.gameObject);;
                GameManager.instance.CheckingAllBallExist();
                if (GameManager.instance.AllBalls.Count == 0)
                {
                    Debug.Log("Game Over");
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
    
}
