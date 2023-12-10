using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.DynamicContext.Api.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string MyClient { get; private set; }
        public string? MyText { get; private set; }
        public string? MyTest { get; private set; }

        private Report() { }

        public Report(string myClient, string? myText, string? myTest)
        {
            MyClient = myClient;
            MyText = myText;
            MyTest = myTest;
        }
    }
}
