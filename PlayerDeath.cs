using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OK
{
    public class PlayerDeath : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Animator anim;
        //private Color ogColor;
        public int dimShards = 0;
        [SerializeField] private Transform playerTransform;
        //[SerializeField] private GameObject bg;
        [SerializeField] private AudioSource deathEffect;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            //ogColor = bg.GetComponent<SpriteRenderer>().color;
            //Debug.Log(dimShards);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Trap"))
            {
                HandleDeath();
                deathEffect.Play();
            }
        }

        private void HandleDeath()
        {
            anim.SetTrigger("isDead");     
        }

        private void HandleLevelRestart()
        {
            //bg.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            transform.position = new Vector3(-9f,-0.5f,0);
            dimShards = dimShards - 5;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("DimShard"))
            {
                Destroy(collision.gameObject);
                dimShards++;
            }
        }
    }
}
