using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _reflectionSide;

    private PlayerControl _playerControl;
    private Vector3 _vectorStop;
    private Vector3 _vectorMove;
    private Vector3 _previousMove;
    private float _speed;
    private float _yDirection;

    private void Awake()
    {
        _playerControl = GetComponent<PlayerControl>();

        _speed = 5;
    }

    private void FixedUpdate()
    {
        Move();
        Debug.Log(_previousMove);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wall wall))
        {
            _vectorStop = _vectorMove;
        }
        else if (collision.TryGetComponent(out Ball ball))
        {
            Vector3 reflection = Vector3.Reflect(ball.Direction, _reflectionSide.normalized);

            if (_vectorMove == Vector3.zero)
            {
                ball.Direction = (reflection + _previousMove + _reflectionSide).normalized;
            }
            else if( _vectorMove != Vector3.zero)
            {
                ball.Direction = (reflection + _vectorMove + _reflectionSide).normalized;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wall wall))
        {
            _vectorStop = Vector3.zero;
        }
    }

    private void Move()
    {
        _yDirection = _playerControl.Input.ReadValue<float>();
        _vectorMove = new Vector3(0, _yDirection, 0);

        if (_vectorStop == _vectorMove)
        {
            return;
        }

        if (_yDirection != 0)
        {
            _previousMove = _vectorMove;
        }

        transform.position += _vectorMove * _speed * Time.fixedDeltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _reflectionSide.normalized);
    }
}