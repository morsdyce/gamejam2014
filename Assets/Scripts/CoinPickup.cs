using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    GameObject[] coins;

   void Start() {
       coins = GameObject.FindGameObjectsWithTag("Coin");

   }

   void FixedUpdate()
   {
       foreach (var coin in coins)
       {
           var distance = Vector3.Distance(transform.position, coin.transform.position);
           Debug.Log(distance);
       }
   }
}
