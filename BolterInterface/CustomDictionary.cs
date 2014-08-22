// file:	CustomDictionary.cs
//
// summary:	Implements the custom dictionary class

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolterInterface
{
   public class CustomDictionary : IDictionary
   {
       /// <summary>    List of key value pairs. </summary>
       public ArrayList KeyValuePairList = new ArrayList();

        /// <summary>
        ///     Adds an element with the provided key and value to the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="key">
        ///     The <see cref="T:System.Object" /> to use as the key of the element to add.
        /// </param>
        /// <param name="value">
        ///     The <see cref="T:System.Object" /> to use as the value of the element to add.
        /// </param>
        ///
        /// ### <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="key" /> is null.
        /// </exception>
        /// ### <exception cref="T:System.ArgumentException">
        ///     An element with the same key already exists in the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </exception>
        /// ### <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.IDictionary" /> is read-only.-or- The
        ///     <see cref="T:System.Collections.IDictionary" /> has a fixed size.
        /// </exception>

        public void Add(object key, object value)
        {
            KeyValuePairList.Add(new DictionaryEntry(key, value));
        }

        /// <summary>
        ///     Removes all elements from the <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// ### <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.IDictionary" /> object is read-only.
        /// </exception>

        public void Clear()
        {
            KeyValuePairList.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.IDictionary" /> object contains an
        ///     element with the specified key.
        /// </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="key">
        ///     The key to locate in the <see cref="T:System.Collections.IDictionary" /> object.
        /// </param>
        ///
        /// <returns>
        ///     true if the <see cref="T:System.Collections.IDictionary" /> contains an element with the
        ///     key; otherwise, false.
        /// </returns>
        ///
        /// ### <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="key" /> is null.
        /// </exception>

        public bool Contains(object key)
        {
            return !KeyValuePairList.OfType<DictionaryEntry>().FirstOrDefault(kvp => kvp.Key.Equals(key)).Equals(default(DictionaryEntry));
        }

        /// <summary>   A simple dictionary enumerator. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>

        private class SimpleDictionaryEnumerator : IDictionaryEnumerator
        {
            // A copy of the SimpleDictionary object's key/value pairs.
            /// <summary>   List of key value pairs. </summary>
            private readonly ArrayList KeyValuePairList;
            /// <summary>   Zero-based index of the. </summary>
            Int32 index = -1;

            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Revy, 8/11/2014. </remarks>
            ///
            /// <param name="sd" type="CustomDictionary">   The SD. </param>

            public SimpleDictionaryEnumerator(CustomDictionary sd)
            {
                KeyValuePairList = sd.KeyValuePairList;
            }

            // Return the current item. 

            /// <summary>   Gets the current. </summary>
            ///
            /// <value> The current. </value>

            public Object Current { get { ValidateIndex(); return KeyValuePairList[index]; } }

            // Return the current dictionary entry. 

            /// <summary>   Gets both the key and the value of the current dictionary entry. </summary>
            ///
            /// <value>
            ///     A <see cref="T:System.Collections.DictionaryEntry" /> containing both the key and the
            ///     value of the current dictionary entry.
            /// </value>
            ///
            /// ### <exception cref="T:System.InvalidOperationException">
            ///     The <see cref="T:System.Collections.IDictionaryEnumerator" /> is positioned before the
            ///     first entry of the dictionary or after the last entry.
            /// </exception>

            public DictionaryEntry Entry
            {
                get { return (DictionaryEntry)Current; }
            }

            // Return the key of the current item. 

            /// <summary>   Gets the key of the current dictionary entry. </summary>
            ///
            /// <value> The key of the current element of the enumeration. </value>
            ///
            /// ### <exception cref="T:System.InvalidOperationException">
            ///     The <see cref="T:System.Collections.IDictionaryEnumerator" /> is positioned before the
            ///     first entry of the dictionary or after the last entry.
            /// </exception>

            public Object Key { get { ValidateIndex(); return ((DictionaryEntry)KeyValuePairList[index]).Key; } }

            // Return the value of the current item. 

            /// <summary>   Gets the value of the current dictionary entry. </summary>
            ///
            /// <value> The value of the current element of the enumeration. </value>
            ///
            /// ### <exception cref="T:System.InvalidOperationException">
            ///     The <see cref="T:System.Collections.IDictionaryEnumerator" /> is positioned before the
            ///     first entry of the dictionary or after the last entry.
            /// </exception>

            public Object Value { get { ValidateIndex(); return ((DictionaryEntry)KeyValuePairList[index]).Value; } }

            // Advance to the next item. 

            /// <summary>   Determines if we can move next. </summary>
            ///
            /// <remarks>   Revy, 8/11/2014. </remarks>
            ///
            /// <returns>   true if it succeeds, false if it fails. </returns>

            public Boolean MoveNext()
            {
                if (index < KeyValuePairList.Count - 1) { index++; return true; }
                return false;
            }

            // Validate the enumeration index and throw an exception if the index is out of range. 

            /// <summary>   Validates the index. </summary>
            ///
            /// <remarks>   Revy, 8/11/2014. </remarks>
            ///
            /// <exception cref="InvalidOperationException">
            ///     Thrown when the requested operation is invalid.
            /// </exception>

            private void ValidateIndex()
            {
                if (index < 0 || index >= KeyValuePairList.Count)
                    throw new InvalidOperationException("Enumerator is before or after the collection.");
            }

            // Reset the index to restart the enumeration. 

            /// <summary>   Resets this object. </summary>
            ///
            /// <remarks>   Revy, 8/11/2014. </remarks>

            public void Reset()
            {
                index = -1;
            }
        }

        /// <summary>
        ///     Returns an <see cref="T:System.Collections.IDictionaryEnumerator" /> object for the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <returns>
        ///     An <see cref="T:System.Collections.IDictionaryEnumerator" /> object for the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </returns>

        public IDictionaryEnumerator GetEnumerator()
        {
            return new SimpleDictionaryEnumerator(this);
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="T:System.Collections.IDictionary" />
        ///     object has a fixed size.
        /// </summary>
        ///
        /// <value>
        ///     true if the <see cref="T:System.Collections.IDictionary" /> object has a fixed size;
        ///     otherwise, false.
        /// </value>

        public bool IsFixedSize { get { return false; } }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="T:System.Collections.IDictionary" />
        ///     object is read-only.
        /// </summary>
        ///
        /// <value>
        ///     true if the <see cref="T:System.Collections.IDictionary" /> object is read-only;
        ///     otherwise, false.
        /// </value>

        public bool IsReadOnly { get { return false; } }

        /// <summary>
        ///     Gets an <see cref="T:System.Collections.ICollection" /> object containing the keys of the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        ///
        /// <value>
        ///     An <see cref="T:System.Collections.ICollection" /> object containing the keys of the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </value>

        public ICollection Keys
        {
            get { return KeyValuePairList.OfType<DictionaryEntry>().Select(kvp => kvp.Key).ToList(); }
        }

        /// <summary>
        ///     Removes the element with the specified key from the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="key">  The key of the element to remove. </param>
        ///
        /// ### <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="key" /> is null.
        /// </exception>
        /// ### <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.IDictionary" /> object is read-only.-or- The
        ///     <see cref="T:System.Collections.IDictionary" /> has a fixed size.
        /// </exception>

        public void Remove(object key)
        {
            var keyIndex = KeyValuePairList.OfType<DictionaryEntry>().ToList().FindIndex(kvp => kvp.Key.Equals(key));
            KeyValuePairList.RemoveAt(keyIndex);
        }

        /// <summary>
        ///     Gets an <see cref="T:System.Collections.ICollection" /> object containing the values in
        ///     the <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        ///
        /// <value>
        ///     An <see cref="T:System.Collections.ICollection" /> object containing the values in the
        ///     <see cref="T:System.Collections.IDictionary" /> object.
        /// </value>

        public ICollection Values
        {
            get { return KeyValuePairList.OfType<DictionaryEntry>().Select(kvp => kvp.Value).ToList(); }
        }

        /// <summary>
        ///     Indexer to get or set items within this collection using array index syntax.
        /// </summary>
        ///
        /// <param name="key" type="object">    The key. </param>
        ///
        /// <returns>   The indexed item. </returns>

        public object this[object key]
        {
            get
            {
                var keyIndex = KeyValuePairList.OfType<DictionaryEntry>().ToList().FindIndex(kvp => kvp.Key.Equals(key));
                if (keyIndex > -1)
                    return ((DictionaryEntry)KeyValuePairList[keyIndex]).Value;
                return null;
            }
            set
            {
                var keyIndex = KeyValuePairList.OfType<DictionaryEntry>().ToList().FindIndex(kvp => kvp.Key.Equals(key));
                if (keyIndex > -1)
                    typeof (DictionaryEntry).GetProperty("Value").SetValue(KeyValuePairList[keyIndex], value);
                else
                    Add(key, value);
            }
        }

        /// <summary>   Copies to. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <exception cref="NotImplementedException">
        ///     Thrown when the requested operation is unimplemented.
        /// </exception>
        ///
        /// <param name="array" type="Array">   The array. </param>
        /// <param name="index" type="int">     Zero-based index of the. </param>

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>   Gets the number of.  </summary>
        ///
        /// <value> The count. </value>

        public int Count
        {
            get { return KeyValuePairList.Count; }
        }

        /// <summary>   Gets a value indicating whether this object is synchronized. </summary>
        ///
        /// <exception cref="NotImplementedException">
        ///     Thrown when the requested operation is unimplemented.
        /// </exception>
        ///
        /// <value> true if this object is synchronized, false if not. </value>

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>   Gets the synchronise root. </summary>
        ///
        /// <exception cref="NotImplementedException">
        ///     Thrown when the requested operation is unimplemented.
        /// </exception>
        ///
        /// <value> The synchronise root. </value>

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>   Gets the enumerator. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <returns>   The enumerator. </returns>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary)this).GetEnumerator();
        }
    }
}
