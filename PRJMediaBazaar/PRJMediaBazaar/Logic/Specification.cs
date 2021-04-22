using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public class Specification
    {
        
        public Specification(String name)
        {
            Name = name;
        }
        public void AddSpecification(String title,String text)
        {
            Title = title;
            Spec = text;
        }
       /* public List<String> GetSpecifications()
        {
            List<String> temp = new List<String>();
            for (int i=0;i<spec.Count;i++)
            {
                temp.Add(specTitle[i] + " : " + spec[i]);
            }
            return temp;
        } */

        public String Name
        {
            get; private set;
        }
        public String Title
        {
            get; private set;
        }
        public String Spec
        {
            get; private set;
        }
    }
}
