using UnityEngine;

public class Mov : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 direction;
    public float longitud_minima = 20f;
    private float longitud_en_x;

    [SerializeField] private int lane;
    [SerializeField] private Transform top;
    [SerializeField] private Transform mid;
    [SerializeField] private Transform bot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lane = 0;
        transform.position = mid.position;
    }

    private void Update()
    {
        //Movimiento();
        VerificarDireccion();
    }

    void VerificarDireccion()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    direction = touch.position;
                    CambioDeCarriles(); 
                    break;
            }
        }
    }

    void CambioDeCarriles()
    {
        if (startPos.x > direction.x)
        {
            switch (lane)
            {
                case 0:

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
        else if (startPos.x < direction.x)
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
                    
                    break;
            }
        }
    }

    void Movimiento()
    {
        rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
    }
}
