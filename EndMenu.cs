using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OK
{
    public class EndMenu : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void LevelScreen()
        {
            SceneManager.LoadScene("Level Select");
        }
    }
}