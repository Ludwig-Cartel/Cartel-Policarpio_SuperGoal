using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    int life = 3;
    [SerializeField] private AudioSource deathSFX;
    private bool dead;

    private Rigidbody2D rigidBody;
    private Animator animate;
    // Start is called before the first frame update
    private void Start()
    {
        life = hearts.Length;
        rigidBody = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            deathCounter();
            //Debug.Log("Test");
        }
    }

    private void deathCounter() {
        if (life >=1) {
            life -= 1;
            deathSFX.Play();
            Destroy(hearts[life].gameObject);
            if (life == 0) 
            {
                dead = true;
                Die();
                Debug.Log("Test");
                //GameOver();
                Invoke("GameOver", 2f);
            }
        }
    }

    private void Die() {
        rigidBody.bodyType = RigidbodyType2D.Static;
        animate.SetTrigger("death");
    }



    private void GameOver() { 
        SceneManager.LoadScene("Game Over");
    }
}

