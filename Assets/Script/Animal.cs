using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float vida;
    [SerializeField] GameManager gm;
    float minX, maxX;
    [SerializeField] bool movingRight;

    [SerializeField] Spaceship tempL;

    float duracion = 0;
    float powerRate = 2;

    bool cantPoder = true;
    float contPoderNum = 0;
    bool poder= false ;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0), Space.World);
        }
        else
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0), Space.World);
        }
        if(transform.position.x > maxX)
        {
            movingRight = false;
        }
        else if(transform.position.x < minX)
        {
            movingRight = true;
        }

        if(cantPoder == true)
        {
            TiempoLento();
        } else
        {
            Time.timeScale = 1;
        }
            
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colision = collision.gameObject;
        if (colision.tag == "Bullet")
        {
            if (poder == true)
            {
                vida = 1;
            }
            vida--;
            if (vida == 0)
            {
                gm.ReducirNumEnemigos();
                Destroy(this.gameObject);
            }
           
        }
    }
     void TiempoLento()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.unscaledTime >= duracion && poder == false)
        {
            poder = true;
            Time.timeScale = 0.5f;
            duracion = Time.unscaledTime + powerRate;
            contPoderNum++;
            if(contPoderNum > 3)
            {
                cantPoder = false;
            }

            
        }
        if (duracion <= Time.unscaledTime && poder == true)
        {
            Time.timeScale = 1;
            poder = false;
        }




    }
}
