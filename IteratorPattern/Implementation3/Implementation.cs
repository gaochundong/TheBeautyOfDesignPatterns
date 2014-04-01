using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.Implementation3
{
  /// <summary>
  /// 双值对
  /// </summary>
  /// <typeparam name="TFirst">第一个值的类型</typeparam>
  /// <typeparam name="TSecond">第二个值的类型</typeparam>
  [Serializable]
  public struct FirstSecondPair<TFirst, TSecond>
  {
    private TFirst first;
    private TSecond second;

    /// <summary>
    /// 第一个值
    /// </summary>
    public TFirst First
    {
      get
      {
        return this.first;
      }
    }

    /// <summary>
    /// 第二个值
    /// </summary>
    public TSecond Second
    {
      get
      {
        return this.second;
      }
    }

    /// <summary>
    /// 双值对
    /// </summary>
    /// <param name="first">第一个值</param>
    /// <param name="second">第二个值</param>
    public FirstSecondPair(TFirst first, TSecond second)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");

      this.first = first;
      this.second = second;
    }

    /// <summary>
    /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;

      FirstSecondPair<TFirst, TSecond> target = (FirstSecondPair<TFirst, TSecond>)obj;
      return this.First.Equals(target.First) && this.Second.Equals(target.Second);
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    /// </returns>
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    /// <summary>
    /// Returns a <see cref="System.String"/> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String"/> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append('[');

      if (this.First != null)
      {
        sb.Append(this.First.ToString());
      }

      sb.Append(", ");

      if (this.Second != null)
      {
        sb.Append(this.Second.ToString());
      }

      sb.Append(']');

      return sb.ToString();
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(FirstSecondPair<TFirst, TSecond> left, FirstSecondPair<TFirst, TSecond> right)
    {
      if (((object)left == null) || ((object)right == null))
      {
        return false;
      }

      return left.Equals(right);
    }

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(FirstSecondPair<TFirst, TSecond> left, FirstSecondPair<TFirst, TSecond> right)
    {
      return !(left == right);
    }
  }

  public class BidirectionalConcurrentDictionary<TFirst, TSecond> : IEnumerable<FirstSecondPair<TFirst, TSecond>>
  {
    #region Fields

    private ConcurrentDictionary<TFirst, TSecond> firstToSecond = new ConcurrentDictionary<TFirst, TSecond>();
    private ConcurrentDictionary<TSecond, TFirst> secondToFirst = new ConcurrentDictionary<TSecond, TFirst>();

    #endregion

    #region Public Methods

    public void Add(TFirst first, TSecond second)
    {
      if (firstToSecond.ContainsKey(first) || secondToFirst.ContainsKey(second))
        throw new ArgumentException("Duplicate first or second");

      firstToSecond.Add(first, second);
      secondToFirst.Add(second, first);
    }

    public bool ContainsFirst(TFirst first)
    {
      return firstToSecond.ContainsKey(first);
    }

    public bool ContainsSecond(TSecond second)
    {
      return secondToFirst.ContainsKey(second);
    }

    public TSecond GetByFirst(TFirst first)
    {
      TSecond second;
      if (!firstToSecond.TryGetValue(first, out second))
        throw new KeyNotFoundException("Cannot find second by first.");

      return second;
    }

    public TFirst GetBySecond(TSecond second)
    {
      TFirst first;
      if (!secondToFirst.TryGetValue(second, out first))
        throw new KeyNotFoundException("Cannot find first by second.");

      return first;
    }

    public void RemoveByFirst(TFirst first)
    {
      TSecond second;
      if (!firstToSecond.TryGetValue(first, out second))
        throw new KeyNotFoundException("Cannot find second by first.");

      firstToSecond.Remove(first);
      secondToFirst.Remove(second);
    }

    public void RemoveBySecond(TSecond second)
    {
      TFirst first;
      if (!secondToFirst.TryGetValue(second, out first))
        throw new KeyNotFoundException("Cannot find first by second.");

      secondToFirst.Remove(second);
      firstToSecond.Remove(first);
    }

    public bool TryAdd(TFirst first, TSecond second)
    {
      if (firstToSecond.ContainsKey(first) || secondToFirst.ContainsKey(second))
        return false;

      firstToSecond.Add(first, second);
      secondToFirst.Add(second, first);
      return true;
    }

    public bool TryGetByFirst(TFirst first, out TSecond second)
    {
      return firstToSecond.TryGetValue(first, out second);
    }

    public bool TryGetBySecond(TSecond second, out TFirst first)
    {
      return secondToFirst.TryGetValue(second, out first);
    }

    public bool TryRemoveByFirst(TFirst first)
    {
      TSecond second;
      if (!firstToSecond.TryGetValue(first, out second))
        return false;

      firstToSecond.Remove(first);
      secondToFirst.Remove(second);
      return true;
    }

    public bool TryRemoveBySecond(TSecond second)
    {
      TFirst first;
      if (!secondToFirst.TryGetValue(second, out first))
        return false;

      secondToFirst.Remove(second);
      firstToSecond.Remove(first);
      return true;
    }

    public int Count
    {
      get { return firstToSecond.Count; }
    }

    public void Clear()
    {
      firstToSecond.Clear();
      secondToFirst.Clear();
    }

    #endregion

    #region IEnumerable<FirstSecondPair<TFirst,TSecond>> Members

    IEnumerator<FirstSecondPair<TFirst, TSecond>> IEnumerable<FirstSecondPair<TFirst, TSecond>>.GetEnumerator()
    {
      foreach (var item in firstToSecond)
      {
        yield return new FirstSecondPair<TFirst, TSecond>(item.Key, item.Value);
      }
    }

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      foreach (var item in firstToSecond)
      {
        yield return new FirstSecondPair<TFirst, TSecond>(item.Key, item.Value);
      }
    }

    #endregion
  }

  public static class ConcurrentDictionaryExtensions
  {
    public static TValue Add<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> collection, TKey key, TValue @value)
    {
      TValue result = collection.AddOrUpdate(key, @value, (k, v) => { return @value; });
      return result;
    }

    public static TValue Update<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> collection, TKey key, TValue @value)
    {
      TValue result = collection.AddOrUpdate(key, @value, (k, v) => { return @value; });
      return result;
    }

    public static TValue Get<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> collection, TKey key)
    {
      TValue @value = default(TValue);
      collection.TryGetValue(key, out @value);
      return @value;
    }

    public static TValue Remove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> collection, TKey key)
    {
      TValue @value = default(TValue);
      collection.TryRemove(key, out @value);
      return @value;
    }
  }
}
