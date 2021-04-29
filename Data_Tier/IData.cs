using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Data_Tier
{
   public interface IData
   {
      public bool isUserRegistered(String socSecNb, String pw);

      //public List<DTO_ECG> getECGdata(String socsecNb);
   }
}
