using UnityEngine;

public class Coin : MonoBehaviour
{
    //Polla 1
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().Coins++;
            Destroy(gameObject);
        }
    }
}
