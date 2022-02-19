using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    public Transform firePoint;
    [SerializeField]
    public GameObject bulletPrefab;
    public static int ammo = 0;
    [SerializeField]
    public Text ammoText;

    private void Awake() {
        if(ammoText.text != null)
        {
            ammoText.text = "Ammo: " + ammo;
        }
    }
    private void Start() {

        
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q) && ammo > 0)
        {
            shoot();
        }
    }

    public void shoot()
    { 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        updateAmmo(-1);
    }

    public void updateAmmo(int amount)
    {
        ammo += amount;
        ammoText = GameObject.Find("Canvas/Ammo").GetComponent<Text>();
        if(ammoText.text != null)
        {
            ammoText.text = "Ammo: " + ammo;
        }
        
    }
}
