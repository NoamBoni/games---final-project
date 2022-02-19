using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coins : MonoBehaviour
{
    public Text coinText;
    public static int coins = 0;
    private void Start() {
        coinText = GameObject.Find("Canvas/Coins").GetComponent<Text>();
        coinText.text = "Coins: " + coins;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Ron the hero"){
            coins++;
            coinText.text = "Coins: " + coins;
            Destroy(this.gameObject);
        }
    }
}
