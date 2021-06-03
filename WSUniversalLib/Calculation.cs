using System;

namespace WSUniversalLib
{
    public class Calculation
    {
        float[] aProduction = { 1.1f, 2.5f, 8.43f };
        float[] aMaterial = { 1.003f, 1.0012f };

        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            try
            {
                if (productType > 3 || productType <= 0 || materialType > 2 || materialType <= 0)
                    return -1;
                if (count <= 0 || width <= 0f || length <= 0f)
                    return -1;

                return Convert.ToInt32(
                    Math.Ceiling(
                        aProduction[productType - 1] * aMaterial[materialType - 1] * count * width * length
                    )
                );
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }
    }
}
