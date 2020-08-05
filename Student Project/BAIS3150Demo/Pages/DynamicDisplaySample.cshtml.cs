using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Demo.Pages
{
    public class DynamicDisplaySampleModel : PageModel
    {
        //private List<Sample> _sampleObjectCollection = new List<Sample>();

        //public List<Sample> SampleObjectCollection
        //{
        //    get
        //    {
        //        return _sampleObjectCollection;
        //    }
        //}



        //public DynamicDisplaySampleModel()            //Constructor if _sampleObjectCollection not instantiated by = new List<Sample>();
        //{
        //    _sampleObjectCollection = new List<Sample>();
        //}


        //or not to do the whole upper part, only single line

        public List<Sample> SampleObjectCollection { get; } = new List<Sample>();

        public void OnGet()
        {
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
        
    }
}