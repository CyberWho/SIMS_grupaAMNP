using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DrugDTO
    {
        public Drug Drug { get; set; }
        public string Id { get; set; }
        public string Grams { get; set; }
        public string NeedsPrescription { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string InventoryItemID { get; set; }
        public string RejectionInfo { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Unit { get; set; }

        public DrugDTO(Drug drug)
        {
            Drug = drug;
            Id = drug.Id.ToString();
            Grams = drug.Grams.ToString();
            NeedsPrescription = drug.NeedsPerscription ? "Potreban" : "Nije potreban";
            Type = drug.drugType.Type;
            switch (drug.Status)
            {
                case DrugStatus.APPROVED:
                    Status = "Odobren";
                    break;
                case DrugStatus.PENDING:
                    Status = "Čeka odobrenje";
                    break;
                case DrugStatus.REJECTED:
                    Status = "Odbijen";
                    break;
            }
            InventoryItemID = drug.InventoryItemID.ToString();
            Name = drug.Name;
            Price = drug.Price.ToString();
            Unit = drug.Unit;
        }

        public DrugDTO()
        {

        }
    }
}
