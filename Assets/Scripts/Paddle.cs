using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public IEnumerator BallCollisionEnter2D(Transform ballTr, Rigidbody2D ballRg, Ball ballCs, GameObject gameObject, Transform gameObjectTr)
    {
        Debug.Log(gameObject);
        yield return null;
    }
}
