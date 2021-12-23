using TestingDemo.Application.Common.Exceptions;
using TestingDemo.Domain.Common.Constants;

namespace TestingDemo.Application.Services
{
    public class InvoiceService
    {
        public static double CalculatePrice(double baseRate, DateTime checkIn, DateTime checkOut)
        {
            var totalMinutes = checkOut.Subtract(checkIn).TotalMinutes;
            var totalHours = Math.Truncate(totalMinutes % 60 >= 15 ? (totalMinutes / 60) + 1 : totalMinutes / 60);

            double totalPrice = 0;

            for (var i = 0; i < totalHours; i++)
            {
                totalPrice += i switch
                {
                    < 3 => baseRate, // las primeras 3 horas tienen la tarifa completa
                    < 6 => baseRate * 0.75, // después de 3 horas y antes de las 6, se deduce el 25% por cada hora adicional
                    _ => baseRate * 0.5 // después de 6 horas se deduce el 50% por cada hora adicional
                };
            }

            return totalPrice;
        }

        public static string GenerateCode(string locationCode, int consecutive)
        {
            if (!Constants.ValidLocationCodes.Contains(locationCode))
                throw new InvalidLocationCodeException($"Location code \"{locationCode}\" is not valid");

            return $"{locationCode}_{consecutive}";
        }
    }
}
