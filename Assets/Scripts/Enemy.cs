using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //данный метод срабатывает, когода объекты только сталкиваются
    {
        if (collision.gameObject.tag == "Player") //сравниваем тег пилы и тег персонажа
        {
            collision.gameObject.GetComponent<Player>().RecoundHp(-1); //отнимаем одну жизнь у персонажа
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up*5f, ForceMode2D.Impulse); //задаем гг импульс отталкивания при ударе
        }
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