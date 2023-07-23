using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericalIntegration
{
    public static class Integration
    {
        /// <summary>
        /// �ɽ� 1/3������ ������̰� �� ������ ª�� ���� ��Ȯ, �ݵ�� ������ ���� ¦������ ��
        /// float���ε� ��κ��� ���е� �䱸 ����
        /// </summary>
        /// <param name="Xs"></param>
        /// <param name="Ys"></param>
        /// <returns>Calculated value</returns>
        static float SimpsonOneDivThree(List<float> Xs, List<float> Ys)
        {
            if (IsEven(Xs.Count) || IsEven(Ys.Count)) return -999;      //����Ʈ�� Ȧ������ ���� ���� ¦���� ����

            float result = 0;
            float sumOdd = 0;
            float sumEven = 0;
            float intervalDivThree = (float)(Math.Abs(Xs.Max() - Xs.Min()) / (Xs.Count - 1) / 3);

            for (int i = 0; i < Ys.Count; i++) Ys[i] = Ys[i] > 0 ? Ys[i] : 0;   // ���� 0���� ó��

            for (int i = 1; i < Ys.Count - 1; i++)
            {
                if (IsEven(i)) sumEven += Ys[i]; 
                else sumOdd += Ys[i];
            }

            sumOdd = 4 * sumOdd;
            sumEven = 2 * sumEven;

            float YTotal = Ys[0] + Ys[Ys.Count - 1] + sumOdd + sumEven;

            result = intervalDivThree * YTotal;
            return result;
        }

        // ¦��, Ȧ�� ����
        public static bool IsEven(int count)=> count % 2 == 0 ? true : false;
    }
}