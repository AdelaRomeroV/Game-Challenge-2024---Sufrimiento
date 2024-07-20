using UnityEngine;

public class Targert : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform PointA;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);
    }
}
