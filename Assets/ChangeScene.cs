using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Cambiar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
