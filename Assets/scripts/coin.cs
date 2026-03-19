using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioClip coinSFX;
 private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            
            Player player = collision.gameObject.GetComponent<Player>();
            player.coins += 1;
            player.PLaySFX(coinSFX);
            Destroy(gameObject);
            
        }
    }
}
