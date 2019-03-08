using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock : MonoBehaviour
{
    [SerializeField] float knockDur;
    [SerializeField] float knockPwr;
    [SerializeField] GameObject platform;
    private CharacterController2D player;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(player.Knockback(knockDur, knockPwr, platform.transform.position));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
