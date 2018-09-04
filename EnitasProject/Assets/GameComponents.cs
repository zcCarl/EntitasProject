
// GameComponents.cs

using UnityEngine;

using Entitas;



// 当前GameObject所在的位置

[Game]

public sealed class PositionComponent : IComponent

{

    public Vector2 value;

}



// 当前GameObject朝向

[Game]

public class DirectionComponent : IComponent

{

    public float value;

}



// GameObject显示的图片

[Game]

public class ViewComponent : IComponent

{

    public GameObject gameObject;

}



// 显示图片的名称

[Game]

public class SpriteComponent : IComponent

{

    public string name;

}



// GameObject是否是Mover的标志

[Game]

public class MoverComponent : IComponent

{

}



// 移动的目标

[Game]

public class MoveComponent : IComponent

{

    public Vector2 target;

}



// 移动完成标志

[Game]

public class MoveCompleteComponent : IComponent

{

}
