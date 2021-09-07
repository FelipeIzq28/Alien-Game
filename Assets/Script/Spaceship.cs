using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject disparo;
    [SerializeField] GameObject disparo2;
    [SerializeField] float fireRate;
    bool disp=true;
    float minX, maxX, minY, maxY;
    float contador=0;
    float nextFire = 0;

    public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x -0.6f;
        maxY = esquinaSupDer.y -0.6f;
        minX = esquinaInfIzq.x + 0.6f;

        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.6f));

        minY = puntoX.y;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamePaused)
        {
            Mover();
            if (disp)
            {
                Disparar1();
            }
            else
            {
                Disparar2();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                disp = !disp;
            }
        }
        
       
     

    }
    void Mover()
    {

        float direcH = Input.GetAxis("Horizontal");
        float direcV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(direcH * Time.deltaTime * speed, direcV * Time.deltaTime * speed);
        transform.Translate(movimiento);

        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }


       
    }
    void Disparar1()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(disparo, transform.position - new Vector3(0,1,0), transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
    void Disparar2()
    {
        
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire && contador <5)
        {
            Instantiate(disparo2, transform.position - new Vector3(0, 1, 0), transform.rotation);
            contador++;
            Debug.Log(contador);
            if(contador == 5)
            {
                nextFire = Time.time + fireRate;
                contador = 0;
            }
            
        }
        
    }

}
