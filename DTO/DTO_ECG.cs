using System;

namespace DTO
{
   public class DTO_ECG
   {
      public double ECGVoltage { get; set; }
      public double Msec { get; set; }

      public DTO_ECG(double ecgvoltage,double msec)
      {
         ECGVoltage = ecgvoltage;
         Msec = msec;
      }
   }
}
