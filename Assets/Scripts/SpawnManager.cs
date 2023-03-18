using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly Vector3 spawnPosition = new Vector3(25, 0, 0);
    private readonly System.Random random = new System.Random();
    private readonly float startDelay = 3f;
    private readonly float repeatRate = 3f;

    private PlayerController playerControllerScript;

    public GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        this.playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", this.startDelay, this.repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        if (!this.playerControllerScript.gameOver)
        {
            // Note: If you want to change object's pivot point you can create a new empty object and put your
            // game object inside the new empty object.
            var obstacle = GetRandomObstacle();
            Instantiate(obstacle, this.spawnPosition, obstacle.transform.rotation);
        }
    }

    private GameObject GetRandomObstacle()
    {
        var randomIndex = random.Next(0, this.obstacles.Length);
        return this.obstacles[randomIndex];
    }
}
