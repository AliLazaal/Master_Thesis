using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Tool_for_ENNA_.Enums
{
    /// <summary>
    /// The bitmask enum type representing different diagnostic sessions
    /// </summary>
    [Flags]
    public enum Sessions : byte
    {

        /// <summary>
        /// Unknown session
        /// </summary>
        Unknown = 0x00,

        /// <summary>
        /// The Default session (0x01)
        /// </summary>
        Default = 0x01,

        /// <summary>
        /// The Programming session (0x02)
        /// </summary>
        Programming = 0x02,

        /// <summary>
        /// The extended session (0x03)
        /// Note: for the Bitmask to work the value of the Enum is not equal to the Hex Representation of the Session
        /// </summary>
        Extended = 0x04,

        /// <summary>
        /// Any non-default session
        /// </summary>
        NonDefault = Programming | Extended


    }
}
