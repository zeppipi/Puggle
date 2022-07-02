using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeed : MonoBehaviour
{
    private PaddleFollow paddleFollow;

    private Vector2 paddlePosition;
    private Vector2 lastPaddlePosition;

    private Vector2 paddleSpeed;

    [SerializeField]
    private Vector2 speedExaggeration = new Vector2(1f,1f);

    // Start is called before the first frame update
    void Awake()
    {
        paddleFollow = this.GetComponent<PaddleFollow>();
    }

    void Start()
    {
        paddlePosition = paddleFollow.getMousePos();
        lastPaddlePosition = paddleFollow.getMousePos();
    }

    // Update is called once per frame
    void Update()
    {
        paddlePosition = paddleFollow.getMousePos();
        
        if(paddlePosition != lastPaddlePosition)
        {
            paddleSpeed = new Vector2((paddlePosition.x - lastPaddlePosition.x) * speedExaggeration.x, Mathf.Abs(paddlePosition.y - lastPaddlePosition.y) * speedExaggeration.y);
        }

        lastPaddlePosition = paddlePosition;
    }

    public Vector2 getSpeed()
    {
        return paddleSpeed;
    }
}
