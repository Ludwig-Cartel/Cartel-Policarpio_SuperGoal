using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private int apples = 0;
    static int score;
    [SerializeField] private Text applesText;
    [SerializeField] private AudioSource collectSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            apples++;
            collectSFX.Play();
            score = apples;
            applesText.text = "Apples: " + score;

            //DontDestroyOnLoad(gameObject);
        }
    }
}
