using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions.Collections.Generic;
using Extensions.XML;

namespace AutofacExample.EducationDepartment.Shared
{
    /// <summary>
    /// Serializable settings service.
    /// Thread safe implementation.
    /// </summary>
    /// <remarks>
    /// In order for this 'global' settings service to be useful, 
    /// this should be imported/exported by MEF as <c>Shared</c>.
    /// </remarks>
    /// <author>Jeffrey Sadeli</author>
    /// <status>Mature</status>
    public class XmlSettingsService : ISettingsService
    {
        #region events

        /// <summary>
        /// Called when the state is updated.
        /// Ending of <see cref="IPersistableState.SetState"/> method.
        /// </summary>
        public event StateUpdatedEventHandler StateUpdated;

        #endregion

        #region private fields

        private readonly object _lockObj = new object();
        private static SerializableDictionary<string, object> _sharedPreferences = new SerializableDictionary<string, object>();
        private static readonly XSerializer<SerializableDictionary<string, object>> _xSerializer
            = new XSerializer<SerializableDictionary<string, object>>();

        #endregion

        #region property getters and setters

        /// <summary>
        /// Gets the collection of keys.
        /// </summary>
        public ICollection<string> Keys
        {
            get
            {
                lock (_lockObj)
                {
                    return _sharedPreferences.Keys;
                }
            }
        }

        /// <summary>
        /// Gets the collection of values.
        /// </summary>
        public ICollection<object> Values
        {
            get
            {
                lock (_lockObj)
                {
                    return _sharedPreferences.Values;
                }
            }
        }

        /// <summary>
        /// Gets the number of key/value pairs contained.
        /// </summary>
        public int Count
        {
            get
            {
                lock (_lockObj)
                {
                    return _sharedPreferences.Count;
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the settings value of the specified key, 
        /// returns <paramref name="defaultValue"/> when unable to do so.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the settings value.</param>
        /// <param name="defaultValue">The default value to return in case of error.</param>
        /// <returns>The value from the specified key.</returns>
        public T Get<T>(string key, T defaultValue)
        {
            lock (_lockObj)
            {
                try
                {
                    return (T)_sharedPreferences[key];
                }
                catch (Exception)
                {
                    return defaultValue;
                }
            }
        }

        /// <summary>
        /// Gets the settings value of the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the settings value.</param>
        /// <returns>The value from the specified key.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the dictionary does not contain the requested key.</exception>
        /// <exception cref="InvalidCastException">Thrown if value is not of type <typeparamref name="T"/>.</exception>
        public T Get<T>(string key)
        {
            lock (_lockObj)
            {
                return (T)_sharedPreferences[key];
            }
        }

        /// <summary>
        /// Sets the settings value to the specified key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to store.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null.</exception>
        public void Set<T>(string key, T value)
        {
            lock (_lockObj)
            {
                _sharedPreferences.Set<string, T>(key, value);
            }
        }

        /// <summary>
        /// Determines whether the settings collection contains the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>True</c> if the specified key contains key; otherwise, <c>False</c>.</returns>
        public bool ContainsKey(string key)
        {
            lock (_lockObj)
            {
                return _sharedPreferences.ContainsKey(key);
            }
        }

        /// <summary>
        /// Determines whether the settings collection contains the specified <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> if the specified value contains value; otherwise, <c>False</c>.</returns>
        public bool ContainsValue<T>(T value)
        {
            lock (_lockObj)
            {
                return _sharedPreferences.ContainsValue(value);
            }
        }

        /// <summary>
        /// Removes the specified key from the settings collection.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>True</c> if removed successfully; otherwise <c>False</c>.</returns>
        public bool Remove(string key)
        {
            lock (_lockObj)
            {
                return _sharedPreferences.Remove(key);
            }
        }

        /// <summary>
        /// Removes all keys and values from the settings collection.
        /// </summary>
        public void Clear()
        {
            lock (this._lockObj)
            {
                _sharedPreferences.Clear();
            }
        }

        /// <summary>
        /// Gets a new (or current) internal state of the instance.
        /// </summary>
        /// <remarks>Typically gets called by application during shutdown, but you should never assume that.</remarks>
        /// <returns>The current instance state to be persisted.</returns>
        public string GetState()
        {
            lock (_lockObj)
            {
                return _xSerializer.ToXml(_sharedPreferences);
            }
        }

        /// <summary>
        /// Sets the current internal state to the given <paramref name="state"/>.
        /// </summary>
        /// <remarks>Typically gets called by application during startup, but you should never assume that.</remarks>
        /// <param name="state">The last known persisted instance state.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="state"/> is null.</exception>
        /// <exception cref="InvalidOperationException">An error occurred during deserialization. The original exception is available using the System.Exception.InnerException property.</exception>
        /// <exception cref="InvalidCastException">Thrown if unable to cast <paramref name="state"/> to this inner dictionary type.</exception>
        public void SetState(string state)
        {
            lock (_lockObj)
            {
                string previousState = _xSerializer.ToXml(_sharedPreferences);
                _sharedPreferences = _xSerializer.FromXml(state);

                if (StateUpdated != null)
                    StateUpdated(this, new StateUpdatedEventArgs(previousState, state));
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // nothing to dispose
        }
    }
}
