using UnityEngine;

public class AdvancedEnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        Vector3 direction = _target.position - transform.position;
        transform.forward = direction;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
