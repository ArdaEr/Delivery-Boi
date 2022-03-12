using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 withPackageColor = new Color32(1, 1, 1, 255);
    [SerializeField] Color32 withoutPackageColor = new Color32(1, 1, 1, 255);
    [SerializeField] float destroyTime = 0.5f;
    private bool takePackage;
    SpriteRenderer spriteRenderer;
    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !takePackage)
        {
            takePackage = true;
            spriteRenderer.color = withPackageColor;
            Destroy(other.gameObject, destroyTime);
            
        }
        else if(other.tag == "Customer" && takePackage == true)
        {
            takePackage = false;
            spriteRenderer.color = withoutPackageColor;
        }
    }
    
}
