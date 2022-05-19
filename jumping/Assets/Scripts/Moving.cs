using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float _velocityValue;
    [SerializeField] private bool FingerTap;
    [SerializeField] private GameObject MainButton;

    private void Start()
    {
        _velocityValue = 8; // минимальное придание ускорения, если игрок зажал палец и сразу отпустил
    }
    
    private void FixedUpdate()
    {
        if (FingerTap == true) // проверка, зажат ли палец 
        {
            if(_velocityValue < 48) // ограничитель (чтобы персонаж не улетел за карту)
            _velocityValue += Time.deltaTime*20; // оедленное наращивание силы
        }
        
    }
    public void FingerDown() // метод для отсеживания паоднятия пальца
    {
        FingerTap = true; 
        this.GetComponent<Animator>().SetBool("Tapped", true);
        this.GetComponent<Animator>().SetBool("Untapped", false);
    }
    public void FingerUp()// метод для зажатия  пальцем
    {
        MainButton.SetActive(false);// выключаем кнопку,чтобы игрок повторно не нажимал
        FingerTap = false;
        this.GetComponent<Animator>().SetBool("Tapped", false);
        this.GetComponent<Animator>().SetBool("Untapped", true); 
       
    }

    public void Jump() // скорость дается только после окончания анимации
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, _velocityValue);
    }

}
