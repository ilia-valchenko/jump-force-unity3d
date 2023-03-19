using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float DefaultSpeed = 20;
    private const float MaxSpeed = DefaultSpeed * 2;

    private PlayerController playerController;
    private Animator playerAnimator;
    private float currentSpeed = DefaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        var playerGameObject = GameObject.Find("Player");
        this.playerController = playerGameObject.GetComponent<PlayerController>();
        this.playerAnimator = playerGameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.playerController.gameOver)
        {
            this.currentSpeed = Input.GetKey(KeyCode.W) && this.playerController.isOnGround
                ? MaxSpeed
                : DefaultSpeed;

            this.playerAnimator.SetFloat("Speed_f", this.currentSpeed);
            transform.Translate(Vector3.left * Time.deltaTime * this.currentSpeed);
        }

        if (this.transform.position.x < -15 && this.gameObject.CompareTag("obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
}
