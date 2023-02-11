using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericalIntegration
{
    public static class Integration
    {
        /// <summary>
        /// ��ٸ����� �̻갪 �������� �������� ��Ȯ�� �ö�
        /// float���ε� ��κ��� ���е� �䱸 ����
        /// </summary>
        /// <param name="XList"></param>
        /// <param name="YList"></param>
        /// <returns>Calculated value</returns>
        public static float TrapezoidalRule(List<float> xList, List<float> yList)
        {
            float result = 0;

            for (int i = 0; i < yList.Count; i++) yList[i] = yList[i] > 0 ? yList[i] : 0;   // 0 ���� �� �ϰ� 0���� ó��

            // ���� ������ ������ ���
            for (int i = 0; i < xList.Count - 1; i++) result += Math.Abs(xList[i + 1] - xList[i]) * Math.Abs(yList[i + 1] + yList[i]) / 2;

            return result;
        }
    }
}