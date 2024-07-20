using UnityEngine;

public class Mov : MonoBehaviour
{

    [SerializeField] private Vector2 startPos = Vector2.zero;
    [SerializeField] private Vector2 direction = Vector2.zero;

    [SerializeField] private int lane = 1;
    [SerializeField] private Transform[] down;
    [SerializeField] private Transform[] mid;

    private bool stun = false;

    private void Awake()
    {
        lane = 1;
        transform.position = mid[lane].position;
        VerificarDireccion();
    }

    private void Update()
    {
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
                    if(stun) { transform.position = down[lane].position; }
                    else { transform.position = mid[lane].position; }
                    break;
                case 2:
                    lane = 1;
                    if (stun) { transform.position = down[lane].position; }
                    else { transform.position = mid[lane].position; }
                    break;
            }
        }
        else if (startPos.x < direction.x)
        {
            switch (lane)
            {
                case 0:
                    lane = 1;
                    if (stun) { transform.position = down[lane].position; }
                    else { transform.position = mid[lane].position; }
                    break;
                case 1:
                    lane = 2;
                    if (stun) { transform.position = down[lane].position; }
                    else { transform.position = mid[lane].position; }
                    break;
                case 2:
                    
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazards"))
        {
            if (stun == false)
            {
                stun = true;
                transform.position = down[lane].position;
                Destroy(collision.gameObject);
                Invoke("Adelantar", 5);
            }
            if (stun == true)
            {
                Destroy(gameObject);
            }
        }
    }
    void Adelantar()
    {
        stun = false;
        transform.position = mid[lane].position;
    }
}
