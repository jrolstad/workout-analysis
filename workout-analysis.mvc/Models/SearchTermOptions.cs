using CommandLine;
using CommandLine.Text;

namespace workout_analysis.mvc.Models
{
    public class SearchTermOptions
    {
        [Option('u', "userid", HelpText = "User Id to search for")]
        public string UserId { get; set; }

        [Option('s', "started", HelpText = "Started on or after the specified day")]
        public string StartedAfter { get; set; }

        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("Search Terms"),
                AddDashesToOption = true
                
            };

            help.AddOptions(this);
            
            return help;
        }

    }
}