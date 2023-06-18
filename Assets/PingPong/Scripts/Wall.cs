using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Vector3 _reflectionSide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            ReflectBall(ball);
        }
    }

    private void ReflectBall(Ball ball)
    {
        Vector3 reflection = Vector3.Reflect(ball.Direction, _reflectionSide);
        ball.Direction = reflection.normalized;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, _reflectionSide);
    }
}