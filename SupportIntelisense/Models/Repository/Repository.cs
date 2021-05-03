using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportIntelisense.Models.Repository
{
    public class Repository : IRepository
    {
        public string GeneratePRONumber()
        {
            string result = "";

            try
            {
                result = this.GenereateNumber("PR");
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public string GenerateTKNumber()
        {
            string result = "";

            try
            {
                result = this.GenereateNumber("TK");
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        private string GenereateNumber(string module)
        {
            string result = "";

            try
            {
                //result = Guid.NewGuid().ToString().Substring(0,3).ToUpper() + "-" + "#" + module;
                ////result = module + "-" + Guid.NewGuid().ToString().Substring(0,3).ToUpper();
                result = module + "-" + Guid.NewGuid().ToString().Substring(0, 1).ToUpper()+"-" + DateTime.UtcNow.ToString("ddMMyy");

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

    }
}
