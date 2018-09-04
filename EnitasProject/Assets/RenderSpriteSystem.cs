
// RenderSpriteSystem.cs

using System.Collections.Generic;

using Entitas;

using UnityEngine;



public class RenderSpriteSystem : ReactiveSystem<GameEntity>

{

    public RenderSpriteSystem(Contexts contexts) : base(contexts.game)

    {

    }



    // 过滤拥有Sprite的Entity

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)

    {

        return context.CreateCollector(GameMatcher.Sprite);

    }



    protected override bool Filter(GameEntity entity)

    {

        return entity.hasSprite && entity.hasView;

    }



    // 在这里的时候Entity已经创建了关联的节点，所以只要添加Sprite的渲染就OK了。

    // 所以当然也要注意，在添加程序组的时候要先添加AddViewSystem，在添加该System。

    // 不然GameObject都没有创建就执行该代码肯定报错的。

    protected override void Execute(List<GameEntity> entities)

    {

        foreach (GameEntity e in entities)

        {

            GameObject go = e.view.gameObject;



            // 先获取SpriteRenderer组件，没有获取到再添加，大家还记得只要改变Sprite的内容就会执行这边的代码吧？

            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();

            if (sr == null) sr = go.AddComponent<SpriteRenderer>();



            sr.sprite = Resources.Load<Sprite>(e.sprite.name);

        }

    }

}
