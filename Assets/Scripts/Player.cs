using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     Rigidbody2D rb;
     public float speed;
     public float jumpHeight;
     public Transform groundCheck;
     private bool isGrounded;
     private Animator anim;
     private int curHp; //количество жизней
     private int maxHp =3; //максимальное кол-во жизней
     private bool isHit = false; //ударяет ли кто-то наш объект
     public Main main;
     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curHp = maxHp; //в начале игры количество жизней у нас равняется трем

    }

    // Update is called once per frame
    void Update() //метод графического движка (срабатывает каждый кадр)
    {

        CheckGround();

        if (Input.GetAxis("Horizontal") == 0 && (isGrounded)) //если ч стоит и на земле
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            Flip();
        if (isGrounded) //если герой на какой-то поверхности
        {
            anim.SetInteger("State", 2);
        }
    }
}

    private void FixedUpdate() //метод физического движка (не зависит от частоты кадров)
    //здесь мы прописываем движение объекта по горизонтали
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y); //задаем скорость
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(transform.up*jumpHeight, ForceMode2D.Impulse); //прыжок
    }

    private void Flip()//если объект идет влево, то он поворачивается на 180 градусов
    {
        if(Input.GetAxis("Horizontal")>0)
            transform.localRotation=Quaternion.Euler(0,0,0);
        if(Input.GetAxis("Horizontal")<0)
            transform.localRotation=Quaternion.Euler(0,180,0);
        
    }

    void CheckGround() //проверка: соприкасается ли герой с поверхностью
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;

        if (!isGrounded)
        {
            anim.SetInteger("State", 3);
        }
        
    }

    public void RecoundHp(int deltaHp) //метод для пересчета кол-ва жизней
    {
        curHp = curHp + deltaHp;
        
        if (deltaHp < 0)
        {
            isHit = true;
            StartCoroutine(onHit());
        }
        
        print(curHp);
        
        if (curHp <= 0)
        {
            GetComponent<CapsuleCollider2D>().enabled = false; //enable позволяет выключить или включить любой компонент у объекта. Деактивируем объект
            Invoke("Lose", 1.5f);//вызываем метод с задержкой 
        }
        
        
    }

    //onHIt = при ударе. Это карутина, мы ее можем вызывать через какой-то промежуток времени 
    IEnumerator onHit()
    {
        if(isHit==true)
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g-0.02f,GetComponent<SpriteRenderer>().color.b-0.02f); //задаем новый цвет
        else
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g+0.02f,GetComponent<SpriteRenderer>().color.b+0.02f);
        
        if(GetComponent<SpriteRenderer>().color.g==1)
            StopCoroutine(onHit());
        
        if (GetComponent<SpriteRenderer>().color.g <= 0)
            isHit = false;
        
        yield return new WaitForSeconds(0.02f); //сколько мы должны подождать перед сменой цвета
        StartCoroutine(onHit());
        
        
    }

    void Lose()
    {
        main.GetComponent<Main>().Lose();
    }
    
    
}


