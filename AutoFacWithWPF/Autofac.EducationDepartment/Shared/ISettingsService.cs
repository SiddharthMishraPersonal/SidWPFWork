using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacExample.EducationDepartment.Shared
{
    /// <summary>
    /// The interface that will allow view models to store settings.
    /// </summary>
    /// <author>Jeffrey Sadeli</author>
    public interface ISettingsService : IPersistableState, IDisposable
    {
        #region property getters and setters

        /// <summary>
        /// Gets the collection of keys.
        /// </summary>
        ICollection<string> Keys { get; }

        /// <summary>
        /// Gets the collection of values.
        /// </summary>
        ICollection<object> Values { get; }

        /// <summary>
        /// Gets the number of key/value pairs contained.
        /// </summary>
        int Count { get; }

        #endregion

        /// <summary>
        /// Gets the settings value of the specified <paramref name="key"/>, 
        /// returns <paramref name="defaultValue"/> when unable to do so.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the settings value.</param>
        /// <param name="defaultValue">The default value to return in case of error.</param>
        /// <returns>The value from the specified key.</returns>
        T Get<T>(string key, T defaultValue);

        /// <summary>
        /// Gets the settings value of the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the settings value.</param>
        /// <returns>The value from the specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Sets the settings value to the specified key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to store.</param>
        void Set<T>(string key, T value);

        /// <summary>
        /// Determines whether the settings collection contains the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>True</c> if the specified key contains key; otherwise, <c>False</c>.</returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Determines whether the settings collection contains the specified <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> if the specified value contains value; otherwise, <c>False</c>.</returns>
        bool ContainsValue<T>(T value);

        /// <summary>
        /// Removes the specified key from the settings collection.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>True</c> if removed successfully; otherwise <c>False</c>.</returns>
        bool Remove(string key);

        /// <summary>
        /// Removes all keys and values from the settings collection.
        /// </summary>
        void Clear();
    }
}
