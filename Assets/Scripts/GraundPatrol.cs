using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GraundPatrol : MonoBehaviour
{
    public float speed = 1f;
    public bool moveLeft = true;
    public Transform groundDetect; //точка, из который выходит луч для проверки 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);//червячок двигается влево с опр скоростью и плавно(Time.deltaTime)
        RaycastHit2D groundInfo= Physics2D.Raycast() // 1- объект столкновения луча в пространстве 
        
    }
}














