using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Mov : MonoBehaviour
{
    [SerializeField] private LayerMask list;
    [SerializeField] private LayerMask voidlist;

    [SerializeField] private Vector2 startPos = Vector2.zero;
    [SerializeField] private Vector2 direction = Vector2.zero;

    private CircleCollider2D circleCollider;

    [SerializeField] private int lane = 1;
    [SerializeField] private Transform[] mid;
    [SerializeField] private Transform[] barcoPos;

    [SerializeField] private GameObject textoPanel;
    [SerializeField] private GameObject mano;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject barco;

    [SerializeField] private GameObject panelMenu;

    private SpriteRenderer sprite;

    private Animator animator;

    private bool stun = false;
    private bool boost = true;
    public bool muerto = false;
    private int num = 0;

    private bool timerActive;
    private float timer = 10;
    private float speed = 5f;
    public bool pause;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        lane = 1;
        transform.position = mid[lane].position;
        textoPanel.SetActive(true);
        Invoke("IniciarJuego", 5f);
    }
    private void Update()
    {
        if(!muerto && !pause)
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
        mano.SetActive(false);
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
        boost = true;
        stun = false;
        timerActive = false;
        timer = 10f;
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
        circleCollider.excludeLayers = list;
        sprite.color = Color.red;
        yield return new WaitForSeconds(1f);
        circleCollider.excludeLayers = voidlist;
        sprite.color = Color.white;
        circleCollider.enabled = true;
    }
    private void OnEnable()
    {
        muerto = false;
        boost = true;
        barco.transform.position = barcoPos[0].position;
        stun = false;
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
