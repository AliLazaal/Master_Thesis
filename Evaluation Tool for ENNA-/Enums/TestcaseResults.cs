using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Tool_for_ENNA_.Enums
{

    /// <summary>
    /// A result state for testcases
    /// </summary>
    public enum TestcaseResults
    {
        /// <summary>
        /// For Testcases that do not have a decisive result
        /// </summary>
        Open = 0x01,

        /// <summary>
        /// For Testcases that are passed
        /// </summary>
        Passed = 0x02,

        /// <summary>
        /// For Testcases that are failed
        /// </summary>
        Failed = 0x04
    }
}
