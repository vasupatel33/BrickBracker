using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    bool isRelease;
    // Update is called once per frame
    void Update()
    {
        if (!isRelease)
        {
            transform.position = new Vector3( paddle.transform.position.x, paddle.transform.position.y + 0.4f, paddle.transform.position.z);
        } 
    }
}
