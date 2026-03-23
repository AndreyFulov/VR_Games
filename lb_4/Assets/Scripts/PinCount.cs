using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PinManager : MonoBehaviour
{
    public Transform[] pins;
    public Text scoreText;
    private float[] initialHeights;
    private bool[] knockedPins;
    private int score = 0;

    void Start()
    {
        pins = FindObjectsOfType<Transform>().Where(t => t.CompareTag("BowlingPin")).ToArray();
        initialHeights = new float[pins.Length];
        knockedPins = new bool[pins.Length];
        Debug.Log($"Кегли: {pins.Length}");

        for (int i = 0; i < pins.Length; i++)
        {
            initialHeights[i] = pins[i].position.y;
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
    }
}
