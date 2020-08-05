using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Demo.Pages
{
    public class DynamicFormDisplaySampleModel : PageModel
    {
        public List<Sample> SampleObjectCollection { get; } = new List<Sample>();

        [BindProperty]
        public string AField { get; set; }
        [BindProperty]
        public string AList { get; set; }

        public string Message { get; set; }

        public void OnGet()  //initial
        {

            Message = "On Get";
            Sample SampleObject;

            SampleObject = new Sample();
            SampleObject.FirstProperty = "1";
            SampleObject.SecondProperty = "One";
            SampleObjectCollection.Add(SampleObject);


            SampleObject = new Sample();
            SampleObject.FirstProperty = "2";
            SampleObject.SecondProperty = "Two";
            SampleObjectCollection.Add(SampleObject);

            SampleObject = new Sample();
            SampleObject.FirstProperty = "3";
            SampleObject.SecondProperty = "Three";
            SampleObjectCollection.Add(SampleObject);
        }

        public void OnPost() //submit
        {
            Message = "*** On Post ***" + AField + "---" + AList;
        }
    }
}