using UnityEngine;

public class Targert : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform pointA;
    [SerializeField] private GameObject parent;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        if(transform.position == pointA.position)
        {
            Destroy(parent);
        }
    }
}
