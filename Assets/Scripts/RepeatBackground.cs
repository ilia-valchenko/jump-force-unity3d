using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWith;

    // Start is called before the first frame update
    void Start()
    {
        this.startPos = transform.position;
        this.repeatWith = this.GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < this.startPos.x - this.repeatWith)
        {
            transform.position = this.startPos;
        }
    }
}
