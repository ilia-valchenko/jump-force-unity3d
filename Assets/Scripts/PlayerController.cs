using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MaxNumberOfJumps = 2;
    private const float WalkSpeed = 1.5f;

    public const float PlayerStartPosition = -2f;

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource audioSource;

    private int numberOfJumps;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRb = this.GetComponent<Rigidbody>();
        this.playerAnim = this.GetComponent<Animator>();
        this.audioSource = this.GetComponent<AudioSource>();

        Physics.gravity = Physics.gravity * this.gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.CanDoJump())
        {
            this.numberOfJumps++;
            this.playerRb.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
            this.isOnGround = false;
            this.playerAnim.SetTrigger("Jump_trig");
            this.audioSource.PlayOneShot(this.jumpSound, 1.0f);
        }

        if (this.transform.position.x < PlayerStartPosition)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * WalkSpeed);
        }
    }

    // Will update the boolean flag once the player touched the ground.
    public void OnCollisionEnter(Collision collision)
    {
        if (this.transform.position.x >= PlayerStartPosition)
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                this.numberOfJumps = 0;
                this.isOnGround = true;
                this.dirtParticle.Play();
            }
            else if (collision.gameObject.CompareTag("obstacle"))
            {
                this.gameOver = true;
                Debug.Log("Game Over!");

                this.playerAnim.SetBool("Death_b", true);
                this.playerAnim.SetInteger("DeathType_int", 1);

                this.explosionParticle.Play();
                this.dirtParticle.Stop();

                this.audioSource.PlayOneShot(this.crashSound, 1.0f);
            }
            else
            {
                this.dirtParticle.Stop();
            }
        }
    }

    private bool CanDoJump()
    {
        return Input.GetKeyDown(KeyCode.Space)
            && (this.isOnGround || this.numberOfJumps < MaxNumberOfJumps)
            && !this.gameOver
            && this.transform.position.x >= PlayerStartPosition;
    }
}
