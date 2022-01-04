using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private AudioSource goalSFX;
    private bool complete = false;
    // Start is called before the first frame update
    void Start()
    {
        goalSFX = GetComponent<AudioSource>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !complete)
        {
            goalSFX.Play();
            complete = true;
            Invoke("levelCompleted", 2f);
            //levelCompleted();
        }
    }

    private void levelCompleted() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
