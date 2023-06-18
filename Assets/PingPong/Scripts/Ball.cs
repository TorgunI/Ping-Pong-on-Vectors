using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    public Vector3 Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value;
            //if(value.x != 0 && (value.y != 1 || value.y != -1)) 
            //{
            //    _direction = value;
            //}
        }
    }

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Initialize()
    {
        //_speed = 2;

        InitializeDirection();
    }

    private void InitializeDirection()
    {
        float x = Random.value > 0.5 ? -1 : 1;
        float y = Random.value > 0.5 ? 1 : -1;
        Direction = new Vector3(x, y, 0);
    }

    private void Move()
    {
        transform.position += _speed * Time.fixedDeltaTime * Direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, Direction);
    }
}
