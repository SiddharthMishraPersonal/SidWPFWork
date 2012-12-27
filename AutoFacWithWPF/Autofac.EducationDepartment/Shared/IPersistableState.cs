using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacExample.EducationDepartment.Shared
{
    #region event handler delegates

    /// <summary>
    /// Event handler delegate for <see cref="IPersistableState.StateUpdated"/>.
    /// </summary>
    public delegate void StateUpdatedEventHandler(object sender, StateUpdatedEventArgs e);

    #endregion

    /// <summary>
    /// Defines an interface that specifies an instance where its internal state can be captured 
    /// and externalized so that it can be restored to that state at a later time.
    /// </summary>
    /// <seealso href="http://en.wikipedia.org/wiki/Memento_pattern"/>
    /// <author>Jeffrey Sadeli</author>
    public interface IPersistableState
    {
        #region events

        /// <summary>
        /// Raised when the state is updated (at the end of <see cref="SetState"/> method).
        /// </summary>
        event StateUpdatedEventHandler StateUpdated;

        #endregion

        /// <summary>
        /// Gets a new (or current) internal state of the instance.
        /// </summary>
        /// <remarks>
        /// Typically gets called by application during shutdown, but you should never assume that.
        /// </remarks>
        /// <returns>The current instance state to be persisted.</returns>
        string GetState();

        /// <summary>
        /// Sets the current internal state to the given <paramref name="state"/>.
        /// </summary>
        /// <remarks>
        /// Typically gets called by application during startup, but you should never assume that.
        /// </remarks>
        /// <param name="state">The last known persisted instance state.</param>
        void SetState(string state);
    }
}
