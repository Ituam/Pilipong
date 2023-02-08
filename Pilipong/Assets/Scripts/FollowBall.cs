using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    [SerializeField] float speed = 5f;

    void Update()
    {
        if (thingToFollow)
        {
            Follow();
        }
    }
    void Follow()
    {
        Vector3 followBallY = new Vector3(transform.position.x, thingToFollow.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, followBallY, speed * Time.deltaTime);
    }
}
