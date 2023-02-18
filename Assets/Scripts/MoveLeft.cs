using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        this.playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (this.transform.position.x < -15 && this.gameObject.CompareTag("obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
}
