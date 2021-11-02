using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
 public void Lose() //метод "проигрыш"
 {
  SceneManager.LoadScene(SceneManager.GetActiveScene().name); //загружаем текущую сцену
 } 
}
