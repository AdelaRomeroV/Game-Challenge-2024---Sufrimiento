using System;
using System.Collections;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class Mov : MonoBehaviour
{

    [SerializeField] private Vector2 startPos = Vector2.zero;
    [SerializeField] private Vector2 direction = Vector2.zero;

    private CircleCollider2D circleCollider;

    [SerializeField] private int lane = 1;
    [SerializeField] private Transform[] mid;
    [SerializeField] private Transform[] barcoPos;

    [SerializeField] private GameObject textoPanel;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject barco;

    [SerializeField] private GameObject panelMenu;

    private Animator animator;

    private bool stun = false;
    private bool boost = true;
    public bool muerto = false;
    private int num = 0;

    private bool timerActive;
    private float timer = 10;
    private float speed = 5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        lane = 1;
        transform.position = mid[lane].position;
        textoPanel.SetActive(true);
        Invoke("IniciarJuego", 5f);
    }
    private void Update()
    {
        if(!muerto)
        {
            VerificarDireccion();
        }
    }

    private IEnumerator BarcoSeAcerca()
    {
        while (true) 
        {
            barco.transform.position = Vector2.MoveTowards(barco.transform.position, barcoPos[num].transform.position, speed * Time.deltaTime);
            if(barco.transform.position.y < barcoPos[num].transform.position.x) { break; }
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
                    transform.position = mid[lane].position; 
                    break;
                case 2:
                    lane = 1;
                    transform.position = mid[lane].position;
                    break;
            }
        }
        else if (startPos.x < direction.x)
        {
            switch (lane)
            {
                case 0:
                    lane = 1;
                    transform.position = mid[lane].position;
                    break;
                case 1:
                    lane = 2;
                    transform.position = mid[lane].position;
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
            if (!timerActive) StartCoroutine(IniciarCronometroDeRegreso());
            else { timer += 5; }
            if (boost) 
            {
                boost = false;
                transform.position = mid[lane].position;
                num = 1;
                StartCoroutine(BarcoSeAcerca());
                StartCoroutine(DesactivarColision());
                Destroy(collision.gameObject);
            }
            else if (stun == false)
            {
                stun = true;
                num = 2;
                StartCoroutine(BarcoSeAcerca());
                animator.SetBool("Sparrow", true);
                StartCoroutine(DesactivarColision());
                Destroy(collision.gameObject);
            }
            else if (stun == true)
            {
                StartCoroutine(BarcoSeAcerca());
                Destroy(collision.gameObject);
                muerto = true;
                animator.SetTrigger("Muerto");
            }
        }
    }

    IEnumerator IniciarCronometroDeRegreso()
    {
        timerActive = true;
        while (timer >= 0)
        {          
            yield return new WaitForSeconds(1f);
            timer--;
        }
        timerActive = false;
        animator.SetBool("Sparrow", false);
        speed = 1.5f;
        num = 1;
        StartCoroutine(BarcoSeAcerca());
        yield return new WaitForSeconds(1f);
        num = 0;
        StartCoroutine(BarcoSeAcerca());
        yield return new WaitForSeconds(1f);
        speed = 5f;
    }

    IEnumerator DesactivarColision()
    {
        circleCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        circleCollider.enabled = true;
    }
    private void OnEnable()
    {
        muerto = false;
        lane = 1;
        transform.position = mid[lane].position;
    }
    public void Muerte()
    {
        gameObject.SetActive(false);
        panelMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
