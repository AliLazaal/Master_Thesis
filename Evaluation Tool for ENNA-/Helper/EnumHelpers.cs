using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation_Tool_for_ENNA_.Enums;

namespace Evaluation_Tool_for_ENNA_.Helper
{
    class EnumHelpers
    {
        /// <summary>
        /// Convert a result string into <see cref="TestcaseResults"/>
        /// </summary>
        /// <param name="result">the string to parse</param>
        /// <returns>the corresponding <see cref="TestcaseResults"/></returns>
        public static TestcaseResults ParseTestcaseResults(string result)
        {
            TestcaseResults ret = TestcaseResults.Open;

            if (result.IndexOf("PASS", StringComparison.OrdinalIgnoreCase) >= 0)
                ret = TestcaseResults.Passed;
            else if (result.IndexOf("FAIL", StringComparison.OrdinalIgnoreCase) >= 0)
                ret = TestcaseResults.Failed;

            return ret;
        }

        /// <summary>
        /// Identify functions and convert from string into <see cref="Function"/>cref 
        /// </summary>
        /// <param name="function">the string to parse</param>
        /// <returns>the corresponding <see cref="Function"></returns>
        public static Function IssueFunction (string function)
        {
            Function func = Function.Unkown;
            if (string.IsNullOrEmpty(function))
                func = Function.Unkown;

            else if (function.IndexOf("Dia_Cod_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.Adaption;

            else if (function.IndexOf("Dia_Anp_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.Adaption;

            else if (function.IndexOf("KSD-Anf_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.KSD;

            else if (function.IndexOf("Dia_Err_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.DTCs;

            else if (function.IndexOf("Dia_Rou_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.Routines;

            else if (function.IndexOf("Dia_Mes_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.Measurements;

            else if (function.IndexOf("Dia_Ident_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.Identification;

            else if (function.IndexOf("Dia_Ds_", StringComparison.OrdinalIgnoreCase) >= 0)
                func = Function.Datasets;

            return func;
        }

        /// <summary>
        /// Converts the Hex value of a session into its Enum Representation
        /// </summary>
        /// <param name="sessionHex">The hex value of the session (e.g. "03" for Extended Session)</param>
        /// <returns>The Enum Representation of the session</returns>
        public static Sessions ParseSessionFromHexString(string sessionHex)
        {
            Sessions session = Sessions.Unknown;

            if (sessionHex.Contains("01"))
                session = Sessions.Default;

            else if (sessionHex.Contains("02"))
                session = Sessions.Programming;

            else if (sessionHex.Contains("03"))
                session = Sessions.Extended;

            return session;
        }
    }
}
