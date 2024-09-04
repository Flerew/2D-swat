using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowerFPS : MonoBehaviour
{
    private const float DisplayInterval = 0.2f;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        StartCoroutine(FramesPerSecond());
    }

    private IEnumerator FramesPerSecond()
    {
        while (true)
        {
            int fps = (int)(1f / Time.deltaTime);
            DisplayFPS(fps);

            yield return new WaitForSeconds(DisplayInterval);
        }
    }

    private void DisplayFPS(int fps)
    {
        _text.text = "fps " + fps.ToString();
    }
}
