using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BrickManager : MonoBehaviour
{
    [SerializeField] Sprite BrockenSprite;
    [SerializeField] GameObject parent;
    [SerializeField] ParticleSystem particle;

    [SerializeField] Sprite SpecialSprite;
    public bool isTouch, isSpecialObj;

    private void Start()
    {
        parent = GameObject.Find("Bricks").transform.gameObject;
        particle = GameObject.Find("Particle").GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (!isTouch)
            {
                Debug.Log("COllide");
                isTouch = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BrockenSprite;
            }
            else
            {
                Vector3 collisionPosition = collision.contacts[0].point;

                particle.transform.position = collisionPosition;
                Debug.Log("Destroy");
                particle.Play();
                Destroy(this.gameObject);
            }
        }
    }
}
