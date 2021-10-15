using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private bool gamePaused; // variavel para permitir ou não o clique de space para liberar a bola
    private float initialSpeed = 7.0f;
    public Rigidbody2D ballRB;
    public Vector3 startPosition;
    private AudioSource playerAudio;
    [SerializeField] private AudioClip ballBump;
    [SerializeField] private AudioClip goalSFX;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        startPosition = transform.position;
        playerAudio = gameObject.GetComponent<AudioSource>();
        Invoke("Launch", 1f);
    }

    private void Update()
    {
        if (gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Launch();
            }


        }
    }
    public void Reset()
    {
        
        ballRB.velocity = Vector2.zero;
        transform.position = startPosition;
        gamePaused = true;
    }

    private void Launch()
    {
        gamePaused = false;
        float x = Random.Range(0, 2) == 0 ? 1 : -1;
        float y = Random.Range(0, 2) == 0 ? 1 : -1;
        speed = initialSpeed;
        ballRB.velocity = new Vector2(initialSpeed * x, initialSpeed * y);
        
    }

    #region Increase Speed
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerAudio.PlayOneShot(ballBump, 0.5f);
        if (collision.gameObject.CompareTag("Player"))
        {
            speed += 2.5f;
            ballRB.AddForce(ballRB.velocity.normalized * speed, ForceMode2D.Force); // vetor normalizado mantém a direção porém com magnitude 1
        }
    }

    #endregion

    #region GoalSFX
    public void playGoalSFX()
    {
        playerAudio.PlayOneShot(goalSFX, 0.7f);
    }
    #endregion


}
