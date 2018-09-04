using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystems : Feature {
    public TutorialSystems(Contexts contexts) : base("Tutorial Systems")
    {
        Add(new EmitInputSystem(contexts));
        Add(new CreateMoverSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new RenderDirectionSystem(contexts));
        Add(new CommandMoveSystem(contexts));
        Add(new MoveSystem(contexts));
        Add(new MiddleMouseKeyChangeSpriteSystem(contexts));
    }

    
}
