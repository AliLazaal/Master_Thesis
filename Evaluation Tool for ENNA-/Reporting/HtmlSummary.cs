using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation_Tool_for_ENNA_.Enums;
using Evaluation_Tool_for_ENNA_.Reporting.Templates;
using System.IO;
using DataModels;

namespace Evaluation_Tool_for_ENNA_.Reporting
{

    /// <summary>
    /// Class to create a Html summary report containing all the testcase and requirement Ids with their corresponding testresults.
    /// </summary>
    public class HtmlSummary
    {
        private string path;
        private string gTestCaseName;
        private IEnumerable<Testing_final.DatabaseMethods.Occurances1> testresults;

        /// <summary>
        /// A Ctor using a <see cref="IEnumerable{TestCaseSummary}"/> and the path to the Report file
        /// </summary>
        /// <param name="testresults">The testresults to write into the report.</param>
        /// <param name="FilePath">The path and Filename of the Report to generate.</param>
        public HtmlSummary(IEnumerable<Testing_final.DatabaseMethods.Occurances1> testresults, string directoryPath, string testCaseName)
        {
            this.gTestCaseName = testCaseName;
            this.testresults = testresults;
            this.path = Path.Combine(directoryPath, "SummaryReport.html");
        }

        public void GenerateHtmlSummaryReport()
        {
            HtmlSummaryTemplate template = new HtmlSummaryTemplate(this.testresults, this.gTestCaseName);

            string content = template.TransformText();

            File.WriteAllText(path, content);
        }

    }
}
