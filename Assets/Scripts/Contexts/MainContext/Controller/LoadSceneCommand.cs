using strange.extensions.command.impl;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : Command
{
    [Inject]
    public string sceneName { get; set; }

    public override void Execute()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
