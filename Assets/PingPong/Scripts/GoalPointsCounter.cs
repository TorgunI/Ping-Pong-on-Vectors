using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalPointsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPointsCounter;
    private int _points;

    private void Start()
    {
        _points = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            _points++;
            _textPointsCounter.text = _points.ToString();
        }
    }
}