using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Mov : MonoBehaviour
{

    [SerializeField] private Vector2 startPos = Vector2.zero;
    [SerializeField] private Vector2 direction = Vector2.zero;

    [SerializeField] private int lane = 1;
    [SerializeField] private Transform[] down;
    [SerializeField] private Transform[] mid;
    [SerializeField] private Transform[] up;

    [SerializeField] private GameObject textoPanel;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject barco;
    [SerializeField] private GameObject endPoint;

    private Animator animator;

    private bool stun = false;
    private bool boost = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lane = 1;
        transform.position = mid[lane].position;
        textoPanel.SetActive(true);
        Invoke("IniciarJuego", 5f);
    }
    private void Update()
    {
        VerificarDireccion();
    }

    private IEnumerator BarcoSeAcerca()
    {
        while (true) 
        {
            barco.transform.position = Vector2.MoveTowards(barco.transform.position, endPoint.transform.position, 5 * Time.deltaTime);
            if(barco.transform.position.y < endPoint.transform.position.x) { break; }
            yield return null;        
        }
    }

    private void IniciarJuego()
    {
        textoPanel.SetActive(false);
        Spawn.SetActive(true);
        StartCoroutine(BarcoSeAcerca());
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
                    else if (boost) { transform.position = up[lane].position; }
                    else { transform.position = mid[lane].position; }
                    break;
                case 2:
                    lane = 1;
                    if (stun) { transform.position = down[lane].position; }
                    else if (boost) { transform.position = up[lane].position; }
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
                    else if (boost) { transform.position = up[lane].position; }
                    else { transform.position = mid[lane].position; }
                    break;
                case 1:
                    lane = 2;
                    if (stun) { transform.position = down[lane].position; }
                    else if (boost) { transform.position = up[lane].position; }
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
            if (boost) 
            {
                boost = false;
                transform.position = mid[lane].position;
                Destroy(collision.gameObject);
            }
            else if (stun == false)
            {
                stun = true;
                animator.SetBool("Sparrow", true);
                transform.position = down[lane].position;
                Destroy(collision.gameObject);
            }
            else if (stun == true)
            {
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("CoinsDoradas"))
        {
            if (stun == true)
            {
                stun = false;
                animator.SetBool("Sparrow", false);
                transform.position = mid[lane].position;
            }
            else 
            {
                boost = true;
                transform.position = up[lane].position;
            }
        }
    }
}
