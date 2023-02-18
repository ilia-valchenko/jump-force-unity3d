using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly Vector3 spawnPosition = new Vector3(25, 0, 0);
    private readonly float startDelay = 3f;
    private readonly float repeatRate = 3f;
    private PlayerController playerControllerScript;

    public GameObject obstaclePrefab;

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
            Instantiate(this.obstaclePrefab, this.spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
