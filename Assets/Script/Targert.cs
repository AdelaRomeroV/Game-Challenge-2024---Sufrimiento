using UnityEngine;

public class Targert : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform pointA;
    [SerializeField] private GameObject parent;
    [SerializeField] private GetCoins puntaje;

    private void Awake()
    {
        puntaje = FindFirstObjectByType<GetCoins>(); 
    }
    void Update()
    {
        if (puntaje != null)
        {
            switch (puntaje.coins)
            {
                case > 1000:
                    speed = 10;
                    break;
                case > 500:
                    speed = 9;
                    break;
                case > 250:
                    speed = 8;
                    break;
                case > 100:
                    speed = 7;
                    break;
                case > 50:
                    speed = 6;
                    break;
            }
        } 
        else { speed = 0; }
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        if(transform.position == pointA.position)
        {
            Destroy(parent);
        }
    }
}
