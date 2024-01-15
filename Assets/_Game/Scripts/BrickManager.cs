using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] Sprite BrockenSprite;
    [SerializeField] ParticleSystem particle;
    bool isTouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Collide");
            if (particle != null)
            {
                Vector3 collisionPosition = collision.GetContact(0).point;
                particle.transform.position = collisionPosition;
                particle.Play();
            }
            if (!isTouch)
            {
                isTouch = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BrockenSprite;
                
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
