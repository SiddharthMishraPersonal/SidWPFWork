using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacExample.EducationDepartment.Shared
{
    /// <summary>
    /// Event arguments for <see cref="StateUpdatedEventHandler"/>.
    /// </summary>
    /// <author>Jeffrey Sadeli</author>
    public class StateUpdatedEventArgs : EventArgs
    {
        #region property getters and setters

        /// <summary>
        /// Gets the previous state before being updated.
        /// </summary>
        public string PreviousState { get; private set; }

        /// <summary>
        /// Gets the current state after being updated.
        /// </summary>
        public string CurrentState { get; private set; }

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StateUpdatedEventArgs"/> class.
        /// </summary>
        public StateUpdatedEventArgs()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="previousState">State of the previous.</param>
        /// <param name="currentState">State of the current.</param>
        public StateUpdatedEventArgs(string previousState, string currentState)
            : this()
        {
            this.PreviousState = previousState;
            this.CurrentState = currentState;
        }

        #endregion
    }
}
