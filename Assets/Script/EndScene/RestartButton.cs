using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnButtonRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
