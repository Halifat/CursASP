using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class BuildingContractorInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<BuildingContractorContext>
    {
        protected override void Seed(BuildingContractorContext context)
        {
            var kindWorkList = new List<KindWork>()
            {
                new KindWork(){ NumberLicense=1123, ExpirationLicense = DateTime.Parse("26.06.2018"), DateLicense= DateTime.Parse("26.06.2012"),PriceWork=120000,Discount=1000,Tax=100},
                new KindWork(){ NumberLicense=2368, ExpirationLicense = DateTime.Parse("11.04.2019"), DateLicense= DateTime.Parse("11.04.2013"),PriceWork=158600,Discount=1500,Tax=100},
                new KindWork(){ NumberLicense=1583, ExpirationLicense = DateTime.Parse("02.06.2018"), DateLicense= DateTime.Parse("02.06.2012"),PriceWork=2005000,Discount=2300,Tax=100},
                new KindWork(){ NumberLicense=4789, ExpirationLicense = DateTime.Parse("29.11.2017"), DateLicense= DateTime.Parse("29.11.2011"),PriceWork=145800,Discount=1800,Tax=100},
                new KindWork(){ NumberLicense=6954, ExpirationLicense = DateTime.Parse("13.03.2018"), DateLicense= DateTime.Parse("13.03.2018"),PriceWork=900000,Discount=6300,Tax=100},
            };
            kindWorkList.ForEach(s => context.KindWork.Add(s));
            

            var stockList = new List<Stock>()
            {
                new Stock(){ NameMaterial = "Steel", ReleaseDate=DateTime.Parse("15.12.2010"),Manufacturer="OAO SteelM",Certificate=14789,DateCertificate=DateTime.Parse("14.08.2008"),Price=14586,Provider="Zakup",Quantity=10,ExpirationDate=DateTime.Parse("20.03.2076"),Photo=""},
                new Stock(){ NameMaterial = "Concrete", ReleaseDate=DateTime.Parse("23.04.2014"),Manufacturer="OAO Бетон",Certificate=14789,DateCertificate=DateTime.Parse("17.08.2008"),Price=14586,Provider="Stroit",Quantity=25,ExpirationDate=DateTime.Parse("20.03.2176"),Photo=""},
                new Stock(){ NameMaterial = "Brick", ReleaseDate=DateTime.Parse("16.12.2010"),Manufacturer="OAO Bricks",Certificate=14789,DateCertificate=DateTime.Parse("21.06.2013"),Price=14586,Provider="Stroit",Quantity=10,ExpirationDate=DateTime.Parse("20.03.2176"),Photo=""},
            };
            stockList.ForEach(c => context.Stock.Add(c));
            

            var techEquipmentList = new List<TechnicalEquipment>()
            {
                new TechnicalEquipment(){ NameTech = "Bulldozer", UseTech="Digging",DatePurchase=DateTime.Parse("23.06.2016"),Exploitation=DateTime.Parse("23.06.2020")},
                new TechnicalEquipment(){ NameTech = "Truck", UseTech="Transport",DatePurchase=DateTime.Parse("23.06.2016"),Exploitation=DateTime.Parse("23.06.2021")},
                new TechnicalEquipment(){ NameTech = "Crane", UseTech="Hosting",DatePurchase=DateTime.Parse("23.06.2016"),Exploitation=DateTime.Parse("23.06.2025")},
            };
            techEquipmentList.ForEach(c => context.TechnicalEquipment.Add(c));
           

            var objectsList = new List<Objects>()
            {
               new Objects(){ NameObject = "T-Building", Customer="M. Genry",GeneralConstractor="Stroy BC",ContractConclusionDate=DateTime.Parse("12.03.2015"),DeliveryDate=DateTime.Parse("12.04.2017"),StartUp=DateTime.Parse("18.08.2018") },
               new Objects(){ NameObject = "Church", Customer="P. Nikel",GeneralConstractor="Stroy BC",ContractConclusionDate=DateTime.Parse("30.05.2016"),DeliveryDate=DateTime.Parse("24.04.2018"),StartUp=DateTime.Parse("26.10.2019") },
               new Objects(){ NameObject = "Pharmacy", Customer="H. Black",GeneralConstractor="Stroy BC",ContractConclusionDate=DateTime.Parse("12.03.2015"),DeliveryDate=DateTime.Parse("12.04.2017"),StartUp=DateTime.Parse("18.08.2018") }
            };
            objectsList.ForEach(e => context.Objects.Add(e));
           

            var works= new List<Works>()
            {
                new Works(){ KindWork = context.KindWork.FirstOrDefault(c => Equals(c.ExpirationLicense,1123)),  Objects= context.Objects.FirstOrDefault()},
                new Works(){ KindWork = context.KindWork.FirstOrDefault(c => Equals(c.ExpirationLicense,2368)),  Objects= context.Objects.FirstOrDefault(c=>c.NameObject=="Church")},
                new Works(){ KindWork = context.KindWork.FirstOrDefault(c => Equals(c.ExpirationLicense,6954)),  Objects= context.Objects.FirstOrDefault(c=>c.NameObject=="Pharmacy")},
            };
            works.ForEach(e => context.Works.Add(e));
            

            var materials = new List<Materials>()
            {
                new Materials(){ Stock = context.Stock.FirstOrDefault(c => c.NameMaterial=="Steel"),  Objects= context.Objects.FirstOrDefault()},
                new Materials(){ Stock = context.Stock.FirstOrDefault(c => c.NameMaterial=="Concrete"),  Objects= context.Objects.FirstOrDefault(c=>c.NameObject=="Church")},
                new Materials(){ Stock = context.Stock.FirstOrDefault(c => c.NameMaterial=="Brick"),  Objects= context.Objects.FirstOrDefault(c=>c.NameObject=="Pharmacy")},
            };
            materials.ForEach(e => context.Materials.Add(e));
            context.SaveChanges();

        }
    }
}