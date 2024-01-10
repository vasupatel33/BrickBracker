using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    bool isRelease;
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
            Debug.Log("Over");
            SceneManager.LoadScene(0);
        }
    }
}
