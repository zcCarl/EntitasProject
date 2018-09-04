
// AddViewSystem.cs

using System.Collections.Generic;

using Entitas;

using Entitas.Unity;

using UnityEngine;



// 给每个拥有Sprite（该Component只保存了图片名称）的GameEntity添加一个View的GameObject

public class AddViewSystem : ReactiveSystem<GameEntity>

{

    // 为了好看，所有ViewGameObject都放在该父节点下

    readonly Transform _viewContainer = new GameObject("Game Views").transform;

    readonly GameContext _context;



    public AddViewSystem(Contexts contexts) : base(contexts.game)

    {

        _context = contexts.game;

    }



    // 创建Sprite的过滤器

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)

    {

        return context.CreateCollector(GameMatcher.Sprite);

    }



    // 第二次过滤，没有View，没有关联上GameObject的情况

    protected override bool Filter(GameEntity entity)

    {

        return entity.hasSprite && !entity.hasView;

    }



    // 创建一个View的GameObject，并进行关联

    protected override void Execute(List<GameEntity> entities)

    {

        foreach (GameEntity e in entities)

        {

            GameObject go = new GameObject("Game View");

            go.transform.SetParent(_viewContainer, false);

            e.AddView(go);  // Entity关联GameObject

            go.Link(e, _context);   // GameObject关联Entity

        }

    }

}
