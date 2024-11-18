using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] private float hSpeed;
    [SerializeField] private float vSpeed;
    [SerializeField] private GameObject puncher;
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float cooldown;
    private float cooldownStore;
    [SerializeField] private bool isPunching;

    void Start()
    {
        _rb2D.GetComponent<Rigidbody2D>();
        puncher.SetActive(false);
        cooldownStore = cooldown;
        isPunching = false;
    }



    void Update()
    {
        if (puncher == null)
        {
            Debug.Log("NOOOOO");
            return;
        }

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");


        _rb2D.velocity = new Vector2(xAxis * hSpeed, yAxis * vSpeed);

        if (Input.GetKey(KeyCode.L))
        {

            isPunching = true;

        }

        if (isPunching)
        {
            Debug.Log("punching");
            puncher.SetActive(true);
            
                Debug.Log("still punching");
                cooldown -= Time.deltaTime;
                puncher.SetActive(true);
            if (cooldown <= 0f)
            {
                puncher.SetActive(false);
                cooldown = cooldownStore;
                isPunching = false;
            }
            
        }

        if (_rb2D.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (_rb2D.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

        }
    }

}
