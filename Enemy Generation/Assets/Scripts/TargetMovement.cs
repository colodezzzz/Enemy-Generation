using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointsStorage;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPointIndex;

    private void Start()
    {
        _currentPointIndex = 0;
        _points = new Transform[_pointsStorage.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _pointsStorage.GetChild(i);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPointIndex].position, _speed * Time.deltaTime);

        if (transform.position == _points[_currentPointIndex].position)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
        }
    }
}
