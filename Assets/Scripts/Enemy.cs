using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isHit = false;
    private void OnCollisionEnter2D(Collision2D collision) //данный метод срабатывает, когода объекты только сталкиваются
    {
        if (collision.gameObject.tag == "Player" && !isHit) //сравниваем тег пилы и тег персонажа
        {
            collision.gameObject.GetComponent<Player>().RecoundHp(-1); //отнимаем одну жизнь у персонажа
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up*5f, ForceMode2D.Impulse); //задаем гг импульс отталкивания при ударе
        }
    }

    public IEnumerator Death()
    {
        isHit = true;
        GetComponent<Animator>().SetBool("dead", true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = false;
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false; 
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    
    
}

//еще два метода для обнаружения ошибки
    
// private void OnCollisionStay2D(Collision2D collision) //метод срабатывает, когда объекты соприкасаются
//{
//  if (collision.gameObject.tag == "Player") //сравниваем тег пилы и тег персонажа
//  {
//      print("Stay");
//  }
//}

//private void OnCollisionExit2D(Collision2D collision) //срабатывает, когда соприкосновения объектов прекращается
//{
//  if (collision.gameObject.tag == "Player") //сравниваем тег пилы и тег персонажа
//  {
//      print("Объекты разошлись");
//  }  
//}