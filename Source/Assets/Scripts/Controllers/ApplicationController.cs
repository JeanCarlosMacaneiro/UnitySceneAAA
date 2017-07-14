using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplicationController : Singleton<ApplicationController>
{
    
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        this.gameObject.tag = Constants.TagObjectName.ApplicationController.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Método para cambiar la scene.
    /// </summary>
    /// <param name="scenename" type ="Constants.ScenesName"></param>
    internal void ChangeScene(Constants.ScenesName scenename)
    {
        SceneManager.LoadScene(scenename.ToString());
    }

    public void Quit()
    {
        Application.Quit();
    }
}
