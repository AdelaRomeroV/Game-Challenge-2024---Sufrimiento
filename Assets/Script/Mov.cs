using UnityEngine;
using UnityEngine.Android;

public class Mov : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    private int lane;
    [SerializeField] private Transform top;
    [SerializeField] private Transform mid;
    [SerializeField] private Transform bot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Movimiento();
        CambioDeCarriles();
    }

    void CambioDeCarriles()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (lane)
            {
                case 0:
                    lane = 0;
                    transform.position = top.position;
                    break;
                case 1:
                    lane = 0;
                    transform.position = top.position;
                    break;
                case 2:
                    lane = 1;
                    transform.position = mid.position;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (lane)
            {
                case 0:
                    lane = 1;
                    transform.position = mid.position;
                    break;
                case 1:
                    lane = 2;
                    transform.position = bot.position;
                    break;
                case 2:
                    lane = 2;
                    transform.position = bot.position;
                    break;
            }
        }
    }

    void Movimiento()
    {
        rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
    }
}
