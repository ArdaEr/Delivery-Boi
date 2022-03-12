using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 8.5f;
    [SerializeField] float boostSpeed = 22;
    // Update is called once per frame
    void Update()
    {   
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // horizontal - left right a - d
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Vertical - up down w - s
        //Sürekli olarak değerlerin güncellenmesi için update içinde oyuncu hareket ediyor.
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "SpeedBoost")
        {
            moveSpeed = boostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }
}
