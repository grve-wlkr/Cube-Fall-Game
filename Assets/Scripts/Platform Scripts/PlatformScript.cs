using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] private float move_Speed = 2f;
    [SerializeField] private float bound_Y = 6f;

    [SerializeField] private bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;

    private void Awake()
    {
        if (is_Breakable)
            anim = GetComponent<Animator>();
    }

    private void Start()
    {
        // Dynamic top deletion Y bound
        bound_Y = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.1f, 0)).y;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
            gameObject.SetActive(false);
    }

    private void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.35f);
    }

    private void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (is_Spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.GameOver();
            }
        }
    } // on trigger enter

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Breakable)
            {
                anim.Play("Break");
                SoundManager.instance.LandSound();
            }

            if (is_Platform)
            {
                SoundManager.instance.LandSound();
            }
        }
    } // on collision enter

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }

            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    } // on collision stay


    




} // class
