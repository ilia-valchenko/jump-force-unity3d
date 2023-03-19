using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float DefaultSpeed = 20;
    private const float MaxSpeed = DefaultSpeed * 2;

    private GameObject playerGameObject;
    private PlayerController playerController;
    private Animator playerAnimator;
    private float currentSpeed = DefaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.playerGameObject = GameObject.Find("Player");
        this.playerController = this.playerGameObject.GetComponent<PlayerController>();
        this.playerAnimator = this.playerGameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.CanRun())
        {
            this.currentSpeed = Input.GetKey(KeyCode.W) && this.playerController.isOnGround
                ? MaxSpeed
                : DefaultSpeed;

            this.playerAnimator.SetFloat("Speed_f", this.currentSpeed);
            transform.Translate(Vector3.left * Time.deltaTime * this.currentSpeed);
        }

        if (this.CanDestroyObstacle())
        {
            Destroy(this.gameObject);
        }
    }

    private bool CanRun()
    {
        return !this.playerController.gameOver && this.playerGameObject.transform.position.x >= PlayerController.PlayerStartPosition;
    }

    private bool CanDestroyObstacle()
    {
        return this.transform.position.x < -15 && this.gameObject.CompareTag("obstacle");
    }
}
