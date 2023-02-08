using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 8f;
    [SerializeField] float verticalSpeed = 8f;
    [SerializeField] AudioClip beepSFX;
    [SerializeField] GameObject FollowPlayer;

    public bool isPlaying;

    void Start()
    {
        isPlaying = false;
    }

    void Update()
    {
        if (!isPlaying)
        {
            FollowPlayerX();
        }

        if (Input.GetKeyDown("space"))
        {
            isPlaying = true;
        }

        if (isPlaying)
        {
            Move();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        BounceBehavior(collision);
    }

    void BounceBehavior(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Computer")
        {
            GetComponent<AudioSource>().PlayOneShot(beepSFX);
            FlipX();
        }
        else
        {
            FlipY();
        }
    }

    void FollowPlayerX()
    {
        Vector3 followPlayerX = new Vector3(transform.position.x, FollowPlayer.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, followPlayerX, verticalSpeed * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.right * horizontalSpeed * Time.deltaTime;
        transform.position += transform.up * verticalSpeed * Time.deltaTime;
    }

    void FlipX()
    {
        horizontalSpeed *= -1f;
    }
    void FlipY()
    {
        verticalSpeed *= -1f;
    }

}
