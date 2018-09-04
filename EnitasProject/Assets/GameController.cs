
// GameController.cs

using UnityEngine;

using Entitas;



public class GameController : MonoBehaviour
{
    Systems _systems;
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new Feature("System").Add(new TutorialSystems(contexts));
        _systems.Initialize();
    }



    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

}
