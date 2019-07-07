using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IEntity 
{
    /// <summary>
    /// 销毁当前对象，并不会从内存上摧毁对象，而是通过管理器EntityManager 类回收
    /// </summary>
     void DestroyEntity();
    /// <summary>
    /// 对象初始化的方法
    /// </summary>
     void Init();
    /// <summary>
    /// 设置管理器，此处应由管理器在创建对象时调用，错误的使用会导致管理器出现混乱
    /// </summary>
    /// <param name="manager"></param>
    void SetManager(IEntityManager manager);
    /// <summary>
    /// 获得这个对象的管理器
    /// </summary>
    /// <returns></returns>
    IEntityManager GetManager();
    /// <summary>
    /// 当对象被销毁时调用
    /// </summary>
    void OnDestroyed();
}
