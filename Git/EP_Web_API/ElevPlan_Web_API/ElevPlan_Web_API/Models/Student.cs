using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ElevPlan_Web_API.Models
{
    [DataContract]
    public class Student
    {
        [DataMember]
        private string Name { get; set; }
        [DataMember]
        private string Occupation { get; set; }
        [DataMember]
        private string Education { get; set; }
        [DataMember]
        private string Specialization { get; set; }
        [DataMember]
        private string Activity { get; set; }
        [DataMember]
        private string Firm { get; set; }
        [DataMember]
        private DateTime PeriodStartDate { get; set; }
        [DataMember]
        private DateTime PeriodEndDate { get; set; }
        [DataMember]
        private DateTime InternshipStartDate { get; set; }
        [DataMember]
        private DateTime InternshipEndDate { get; set; }

        public Student(string name, string occupation, string education, string specialization, string activity, string firm, DateTime pStartDate, DateTime pEndDate, DateTime iStartDate, DateTime iEndDate)
        {
            Name = name;
            Occupation = occupation;
            Education = education;
            Specialization = specialization;
            Activity = activity;
            Firm = firm;
            PeriodStartDate = pStartDate;
            PeriodEndDate = pEndDate;            
            InternshipStartDate = iStartDate;
            InternshipEndDate = iEndDate;
        }
    }
}