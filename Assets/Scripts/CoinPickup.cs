using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    GameObject[] coins;
    int i = 0;
   void Start() {
       coins = GameObject.FindGameObjectsWithTag("Coin");
       
   }

   void Update()
   {
       
       foreach (var coin in coins)
       {
           
           var distance = Vector3.Distance(transform.position, coin.transform.position);
           print(distance);
           /*
           if (coin != null)
           {
               

               print(string.Format("Transform: {0} Coin: {1}", transform.position, coin.transform.position));
           }*/
       }

       //print(coins.Length);
   }
}
