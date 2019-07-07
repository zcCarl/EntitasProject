using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// 对象的回收复用管理
/// </summary>
/// <typeparam name="T"></typeparam>
internal abstract class AObjectManager<T> 
{
    /// <summary>
    /// 使用中的对象
    /// </summary>
    List<T> inUse = new List<T>();
    /// <summary>
    /// 废弃对象列表
    /// </summary>
    List<T> unUse = new List<T>();

    /// <summary>
    /// 获取正在使用的对象列表，由于返回的是一个临时列表并不是真的使用列表，所以修改无效
    /// </summary>
    /// <returns></returns>
    List<T> GetInUseList()
    {
        List<T> result = new List<T>(inUse);
        return result;
    }
    /// <summary>
    /// 当回收对象时的额外处理
    /// </summary>
    protected abstract void OnDestoryObject(T obj);

    /// <summary>
    /// 当创建对象时的额外处理
    /// </summary>
    protected abstract void OnCreatObject(T obj);

       /// <summary>
    /// 创建一个新对象
    /// </summary>
    /// <returns>新的对象</returns>
    protected abstract T CreatNew();
    /// <summary>
    /// 创建一个对象，如果回收列表有多余的对象则使用它
    /// </summary>
    /// <returns></returns>
    protected T CreatObject()
    {
        T result;
        if (unUse.Count > 0)
        {
            result = unUse[0];
            unUse.RemoveAt(0);
        }
        else
        {
            result = CreatNew();
        }
        inUse.Add(result);
        OnCreatObject(result);

        return result;
    }
    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="obj"></param>
    protected void DestoryObject(T obj)
    {
        if (inUse.Contains(obj))
        {
            inUse.Remove(obj);
        }
        OnDestoryObject(obj);
        if (!unUse.Contains(obj))
        {
            unUse.Add(obj);
        }
    }
    /// <summary>
    /// 回收所有对象
    /// </summary>
    protected void DestryAllObject()
    {
        while (GetInUseList().Count > 0)
        {
            DestoryObject(inUse[0]);
        }
    }
}
