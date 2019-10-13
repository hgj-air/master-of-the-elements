using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OSDScript : MonoBehaviour
{
    private Text Text;
    private float TimeLasted;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      if (StateManager.Instance.Lives != 0)
      {
        Text.text = $"Lives: {StateManager.Instance.Lives}        \nScore: {StateManager.Instance.Score.ToString("D8")}";
      }else{
        if (TimeLasted == default) {
          TimeLasted = Time.realtimeSinceStartup;
        }
        Text.text = $"Game Over!        \nYour Score: {StateManager.Instance.Score.ToString("D8")}        \nYou lasted: {(int)TimeLasted} seconds."
      }
    }
}
