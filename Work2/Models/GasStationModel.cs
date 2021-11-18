using System;
using System.Collections.Generic;
using Work2.Enums;
using Work2.Models.Base;

namespace Work2.Models
{
    public class GasStationModel : BaseModel
    {
        public string StreetName { get; set; }
        public string CompanyName { get; set; }
        public EGasoline GasolineBrand { get; set; }
        public double OneLiterGasolinePriceInRub { get; set; }

        public GasStationModel() => Id = RandomizeNewId();

        public static List<GasStationModel> Create(int count)
        {
            var gasStations = new List<GasStationModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                gasStations.Add(CreateRandom());
            }

            return gasStations;
        }

        public static GasStationModel Create(string streetName, string companyName,
            EGasoline gasolineBrand, double gasolinePrice) => new()
        {
            StreetName = streetName,
            CompanyName = companyName,
            GasolineBrand = gasolineBrand,
            OneLiterGasolinePriceInRub = gasolinePrice
        };

        public override string ToString() => 
            $"Street is {StreetName}, company is {CompanyName}, " + 
            $"gasoline is {GasolineBrand}, gasoline price is {OneLiterGasolinePriceInRub} rub.";

        private static GasStationModel CreateRandom() => new()
        {
            StreetName = RandomizeNewStreetName(),
            CompanyName = RandomizeNewCompanyName(),
            GasolineBrand = RandomizeGasolineBrand(),
            OneLiterGasolinePriceInRub = RandomizeOneLiterGasolinePrice()
        };

        private static string RandomizeNewStreetName() =>
            $"Street {new Random().Next(1,10)}";

        private static string RandomizeNewCompanyName() =>
            $"Company {new Random().Next(1,10)}";

        private static EGasoline RandomizeGasolineBrand()
        {
            int enumCount = Enum
                .GetNames(typeof(EGasoline)).Length;

            int randomValue = new Random().Next(0,enumCount);

            return (EGasoline) randomValue;
        }

        private static double RandomizeOneLiterGasolinePrice() =>
            new Random().Next(100,200);
    }
}