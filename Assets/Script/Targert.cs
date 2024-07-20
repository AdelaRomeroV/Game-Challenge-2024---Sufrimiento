using UnityEngine;

public class Targert : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
    }
}
