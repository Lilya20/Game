using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
// червяк 
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
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 1f); // 1- объект столкновения луча в  2D пространстве / (1- откуда будет исходить луч.2-куда он будет направлен, 3- какой длины будет луч)

        if (groundInfo.collider == false)
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0,180,0); // eulerAngles - угол в градусах
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                moveLeft = true;
            }
        }

    }
}














