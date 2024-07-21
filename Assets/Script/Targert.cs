using UnityEngine;

public class Targert : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform pointA;
    [SerializeField] private GameObject parent;
    [SerializeField] private GetCoins puntaje;
    [SerializeField] private Spawn spawn;

    private void Awake()
    {
        puntaje = FindFirstObjectByType<GetCoins>();
        spawn = FindFirstObjectByType<Spawn>();
        if (puntaje == null) { Destroy(parent); }
    }
    void Update()
    {
        if (puntaje != null)
        {
            switch (puntaje.coins)
            {
                case >= 3000:
                    speed = 20;
                    spawn.spawnear = 2.5f;
                    break;
                case >= 2500:
                    speed = 17;
                    break;
                case >= 2000:
                    speed = 15;
                    spawn.spawnear = 3f;
                    break;
                case >= 1500:
                    speed = 12;
                    break;
                case >= 1000:
                    speed = 10;
                    spawn.spawnear = 3.5f;
                    break;
                case >= 500:
                    speed = 9;
                    break;
                case >= 250:
                    speed = 8;
                    spawn.spawnear = 4f;
                    break;
                case >= 100:
                    speed = 7;
                    break;
                case >= 50:
                    speed = 6;
                    spawn.spawnear = 4.5f;
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
    private void OnDestroy()
    {
        Destroy(parent);
    }
}
