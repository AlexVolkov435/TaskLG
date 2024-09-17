using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOneTrap : MonoBehaviour
{   
     [SerializeField] private PlayerController _playerController;
    private void OnCollisionEnter(Collision collision)
    {
        byte colorRed = 255; 
        byte colorGreen = 128; 
        byte colorBlue = 0; 
        byte transparency = 0; 

        gameObject.GetComponent<Renderer>().material.color = new Color32(colorRed, colorGreen, colorBlue, transparency);

        DoDamage();
    }

    private void DoDamage()
    {
        int damage = 10;

        _playerController.TakeDamage(damage);
    }
}
