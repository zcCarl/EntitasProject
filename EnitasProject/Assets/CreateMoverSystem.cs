
// CreateMoverSystem.cs

using System.Collections.Generic;

using Entitas;

using UnityEngine;



// 监听的是InputContext中的右键数据，所以是InputEntity的ReactiveSystem

public class CreateMoverSystem : ReactiveSystem<InputEntity>

{

    readonly GameContext _gameContext;

    public CreateMoverSystem(Contexts contexts) : base(contexts.input)

    {

        _gameContext = contexts.game;

    }



    // 收集有RightMouse和MouseDown的InputEntity

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)

    {

        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));

    }



    // 第二过滤，直接返回true也无所谓

    protected override bool Filter(InputEntity entity)

    {

        return entity.hasMouseDown;

    }



    // 执行，每次按下右键，设置Mover标志，添加Position、Direction，并添加表现该Entity的图片名称

    protected override void Execute(List<InputEntity> entities)

    {

        foreach (InputEntity e in entities)

        {

            GameEntity mover = _gameContext.CreateEntity();

            mover.isMover = true;

            mover.AddPosition(e.mouseDown.position);

            mover.AddDirection(Random.Range(0, 360));

            mover.AddSprite("head1");

        }

    }

}
