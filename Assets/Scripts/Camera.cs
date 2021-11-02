using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float speed = 3f;
    public Transform target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position= new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z); //позиция камеры
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.position;
        position.z = transform.position.z; //присвиваем позиции z позици. камеры 
        transform.position = Vector3.Lerp(transform.position, position,speed ); // с помощью этого метода мы сможем плавно перемещать камеру к игроку 
                                             // первое - это то, откуда мы начинаем двигаться. В нашем случае - это камера. Пишем ее позицию
                                             // второе - куда движется камерв
                                             //с ккакой скоростью будет приближение
    }
    
    /* I'm fine */
}
