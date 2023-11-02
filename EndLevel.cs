using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OK
{
    public class EndLevel : MonoBehaviour
    {
        private AudioSource finishSound;
        private PlayerDeath playerDeath;
        private int endTrigger;
        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject goodEnd;
        [SerializeField] private GameObject badEnd;

        void Start()
        {
            finishSound = GetComponent<AudioSource>();
            playerDeath = player.GetComponent<PlayerDeath>();
        }

        void Update()
        {
            endTrigger = playerDeath.dimShards;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                finishSound.Play();
                
                rb.bodyType = RigidbodyType2D.Static;
                anim.SetTrigger("isWon");
                
                Invoke("CompleteLevel", 3.5f);
            }
        }

        private void CompleteLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                HandleEnding();
            }
        }

        private void HandleEnding()
        {
            if (endTrigger < 12)
            {
                badEnd.SetActive(true);
            }
            else
            {
                goodEnd.SetActive(true);
            }
        }
    }   
}