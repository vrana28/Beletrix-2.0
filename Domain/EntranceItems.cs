using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class EntranceItems : GeneralDomainObject
    {
        public int Num { get; set; }
        public int EntranceId { get; set; }
        public int RobaId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime DateOfManu { get; set; }
        public Roba Roba { get; set; }
        public bool Deadline { get; set; }
        public double NumOfBoxes { get; set; }

        public string GetAllValues()
        {
            return $"'{Num}','{EntranceId}','{RobaId}','{DeadlineDate}','{Deadline}','{NumOfBoxes}','{DateOfManu}'";
             
        }

        public string GetName()
        {
            return "EntranceItems";
        }

        public string GetWhereName()
        {
            throw new NotImplementedException();
        }

        public string GetWhereValues()
        {
            return $"where Num = {Num} and EntranceId = {EntranceId}";
        }

        public string SetValues()
        {
            return $" NumOfBoxes = {NumOfBoxes} where EntranceId = {EntranceId} and Num = {Num}";
        }
    }
}
