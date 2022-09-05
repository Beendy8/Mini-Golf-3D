using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "ball_obj")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
    
}
