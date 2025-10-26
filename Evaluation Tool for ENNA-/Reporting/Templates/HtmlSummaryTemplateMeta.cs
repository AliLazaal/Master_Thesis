using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation_Tool_for_ENNA_.Enums;


namespace Evaluation_Tool_for_ENNA_.Reporting.Templates
{
    /// <summary>
    /// Partial class for the generation of the Summary report using the T4 Template
    /// </summary>
    public partial class HtmlSummaryTemplate : HtmlSummaryTemplateBase
    {
        /// <summary>
        /// The name of the test for which the report is generated
        /// </summary>
        public string TestName { get; set; }

        private IEnumerable<Testing_final.DatabaseMethods.Occurances1> testresults;
        private int testcase_count;
        private int failed_count;
        private int passed_count;
        private int open_count;

        private string failed_percentage;
        private string passed_percentage;
        private string open_percentage;

        /// <summary>
        /// A ctor using the testcases that will be displayed in the report
        /// </summary>
        /// <param name="testcases">The Testcases to include in the summary report</param>
        public HtmlSummaryTemplate(IEnumerable<Testing_final.DatabaseMethods.Occurances1> testcases, string testName)
        {
            this.TestName = testName;

            this.testresults = testcases;
            testcase_count = testcases.Count();

            failed_count = testcases.Count(r => r.Result == Convert.ToString(Enums.TestcaseResults.Failed));
            failed_percentage = (((float)failed_count / (float)testcase_count) * 100).ToString("0.##") + "%";

            passed_count = testcases.Count(r => r.Result == Convert.ToString(Enums.TestcaseResults.Passed));
            passed_percentage = (((float)passed_count / (float)testcase_count) * 100).ToString("0.##") + "%";

            open_count = testcases.Count(r => r.Result == Convert.ToString(Enums.TestcaseResults.Passed));
            open_percentage = (((float)open_count / (float)testcase_count) * 100).ToString("0.##") + "%";
        }

    }
}
