using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //private Animator animator;
    [SerializeField] public float transitionTime = 1f;

    private void Start()
    {
        // Obtener el componente Animator autom ticamente
   

    }

    // Carga la escena del juego
    public void PlayGame()
    {
        // Restablecer la salud antes de iniciar el juego
        //PlayerHealth.ResetHealth();
        LoadNextScene();
    }

    // Salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    // Cargar la siguiente escena por  ndice
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    // Cargar una escena por nombre
    public void LoadSceneByName(string sceneName)
    {
        // PlayerHealth.ResetHealth(); // Restablecer la salud antes de cargar la escena
        StartCoroutine(SceneLoadByName(sceneName));
    }

    // Reiniciar la escena actual
    public void RestartScene()
    {
        //PlayerHealth.ResetHealth(); // Restablecer la salud antes de reiniciar la escena
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(SceneLoad(currentSceneIndex));
    }

    // Corrutina para cargar la escena por  ndice
    private IEnumerator SceneLoad(int nextSceneIndex)
    {
      
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Corrutina para cargar la escena por nombre
    private IEnumerator SceneLoadByName(string sceneName)
    {
    
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
