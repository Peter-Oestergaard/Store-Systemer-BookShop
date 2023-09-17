using BookStore.Models;
using System.Linq.Expressions;

namespace BookStore.Interfaces;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="clause"></param>
    /// <returns></returns>
    IEnumerable<T> Where(Func<T, bool> clause);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="clause"></param>
    /// <returns></returns>
    Genre? FirstOrDefault(Func<Genre, bool> clause);
}