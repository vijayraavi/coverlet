using System;
using System.Collections.Generic;

namespace Coverlet.Core.Reporters
{
    public class LcovReporter : IReporter
    {
        public string Format(CoverageResult result)
        {
            List<string> lcov = new List<string>();
            foreach (var module in result.Data)
            {
                foreach (var doc in module.Value)
                {
                    lcov.Add("SF:" + doc.Key);
                    foreach (var line in doc.Value)
                        lcov.Add($"DA:{line.Key},{line.Value}");

                    lcov.Add("end_of_record");
                }
            }

            return string.Join(Environment.NewLine, lcov);
        }
    }
}