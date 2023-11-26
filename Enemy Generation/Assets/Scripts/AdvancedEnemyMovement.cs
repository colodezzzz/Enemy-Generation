using UnityEngine;

public class AdvancedEnemyMovement : MonoBehaviour
{
    [HideInInspector] public Transform Target;

    [SerializeField] private float _speed;

    private void Start()
    {
        Vector3 direction = Target.position - transform.position;
        transform.forward = direction;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, _speed * Time.deltaTime);

        if (transform.position == Target.position)
        {
            Destroy(gameObject);
        }
    }
}
