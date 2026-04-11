using UnityEngine;
using UnityEngine.UI;
using System.Linq;
[RequireComponent(typeof(BoxCollider))]
public class PinManager : MonoBehaviour
{
    public Transform[] pins;
    public Text scoreText;
    private float[] initialHeights;
    private bool[] knockedPins;
    private int score = 0;

    private int ballCount;    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            ballCount++;
        }   
    }
    private Transform[] initialPosition;
    void Start()
    {
        ballCount = 0;

        initialHeights = new float[pins.Length];
        knockedPins = new bool[pins.Length];
        Debug.Log($"Кегли: {pins.Length}");

        for (int i = 0; i < pins.Length; i++)
        {
            initialHeights[i] = pins[i].position.y;
            initialPosition[i] = pins[i];
        }
    }

    public void Update()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (!knockedPins[i] && pins[i].position.y < initialHeights[i] - 0.01f)
            {
                knockedPins[i] = true;
                score++;
                scoreText.text = $"Score: {score}";
            }
        }
        if(ballCount == 2)
        {
            for(int i = 0; i < pins.Length; i++)
            {
                pins[i] = initialPosition[i];
            }
            ballCount = 0;
        }
        if(knockedPins)
    }
}
