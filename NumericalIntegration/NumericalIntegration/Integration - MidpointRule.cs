using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericalIntegration
{
    public static class Integration
    {
        /// <summary>
        /// ���������� �� �׷��� ���¿��� ���� ��Ȯ�� ����
        /// float���ε� ��κ��� ���е� �䱸 ����
        /// </summary>
        /// <param name="Xs"></param>
        /// <param name="Ys"></param>
        /// <returns>Calculated value</returns>
        public static float MidpointRule(List<float> Xs, List<float> Ys)
        {
            float result = 0;

            for (int i = 0; i < Ys.Count; i++) Ys[i] = Ys[i] > 0 ? Ys[i] : 0;   // ���� 0���� ó��

            //  ���� ������ ������ ���
            for (int i = 0; i < Xs.Count - 1; i++)
            {
                float YMidpoint = Ys[i] < Ys[i + 1] ? Ys[i] + (Math.Abs(Ys[i + 1] - Ys[i])) / 2 : Ys[i + 1] + (Math.Abs(Ys[i + 1] - Ys[i])) / 2;
                result += YMidpoint * (float)Math.Abs(Xs[i + 1] - Xs[i]);
            }
            return result;
        }
    }
}