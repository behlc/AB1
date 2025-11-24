using UnityEngine;

public class Monster : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(ShouldDieFromCollision(collision))
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bird")
        {
            return true;
        }

        return false;
    }

}
