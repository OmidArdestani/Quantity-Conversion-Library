using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace QuantityUnitTEst
{
    [TestClass]
    public class QuantityTest
    {
        [TestMethod]
        public void QFrequency_TEST()
        {
            QFrequency f2 = new QFrequency(10e6, QFrequency.QuantityUnit.QT_Hz);
            Assert.IsTrue(f2.MHz() == 10);
            Assert.IsTrue(f2.GHz() == 0.01);
            Assert.IsTrue(f2.KHz() == 10e3);
            Assert.IsTrue(f2.Hz() == 10e6);

            QFrequency f3 = new QFrequency(10e3, QFrequency.QuantityUnit.QT_KHz);
            Assert.IsTrue(f3.MHz() == 10);
            Assert.IsTrue(f3.GHz() == 0.01);
            Assert.IsTrue(f3.KHz() == 10e3);
            Assert.IsTrue(f3.Hz() == 10e6);

            QFrequency f1 = new QFrequency(10); // default is mhz
            Assert.IsTrue(f1.MHz() == 10);
            Assert.IsTrue(f1.GHz() == 0.01);
            Assert.IsTrue(f1.KHz() == 10e3);
            Assert.IsTrue(f1.Hz() == 10e6);

            QFrequency f4 = new QFrequency(0.01, QFrequency.QuantityUnit.QT_GHz);
            Assert.IsTrue(f4.MHz() == 10);
            Assert.IsTrue(f4.GHz() == 0.01);
            Assert.IsTrue(f4.KHz() == 10e3);
            Assert.IsTrue(f4.Hz() == 10e6);
        }

        [TestMethod]
        public void QSignalLevel_TEST()
        {
            QSignalLevel s1 = new QSignalLevel(30);
            Assert.IsTrue(s1.dBm() == 30);
            Assert.IsTrue(s1.dB() == 0);
            Assert.IsTrue(s1.Wat() == 1);
            Assert.IsTrue(s1.mWat() == 1e3);
            Assert.IsTrue(s1.volt() == 1);

            QSignalLevel s2 = new QSignalLevel(1, QSignalLevel.QuantityUnit.QT_Wat);
            Assert.IsTrue(s2.dBm() == 30);
            Assert.IsTrue(s2.dB() == 0);
            Assert.IsTrue(s2.Wat() == 1);
            Assert.IsTrue(s2.mWat() == 1e3);
            Assert.IsTrue(s2.volt() == 1);

            QSignalLevel s3 = new QSignalLevel(1000, QSignalLevel.QuantityUnit.QT_mWat);
            Assert.IsTrue(s3.dBm() == 30);
            Assert.IsTrue(s3.dB() == 0);
            Assert.IsTrue(s3.Wat() == 1);
            Assert.IsTrue(s3.mWat() == 1e3);
            Assert.IsTrue(s3.volt() == 1);

            QSignalLevel s4 = new QSignalLevel(1, QSignalLevel.QuantityUnit.QT_Volt);
            Assert.IsTrue(s4.dBm() == 30);
            Assert.IsTrue(s4.dB() == 0);
            Assert.IsTrue(s4.Wat() == 1);
            Assert.IsTrue(s4.mWat() == 1e3);
            Assert.IsTrue(s4.volt() == 1);
        }

        [TestMethod]
        public void QTimes_TEST()
        {
            QTimes t1 = new QTimes(1, QTimes.QuantityUnit.QT_S);
            Assert.AreEqual(t1.S(), 1);
            Assert.AreEqual(t1.mS(), 1e3);
            Assert.AreEqual(t1.uS(), 1e6);
            Assert.AreEqual(t1.nS(), 1e9);
            Assert.AreEqual(t1.pS(), 1e12);

            QTimes t2 = new QTimes(1e3, QTimes.QuantityUnit.QT_mS);
            Assert.AreEqual(t2.S(), 1);
            Assert.AreEqual(t2.mS(), 1e3);
            Assert.AreEqual(t2.uS(), 1e6);
            Assert.AreEqual(t2.nS(), 1e9);
            Assert.AreEqual(t2.pS(), 1e12);

            QTimes t3 = new QTimes(1e6, QTimes.QuantityUnit.QT_uS);
            Assert.AreEqual(t3.S(), 1);
            Assert.AreEqual(t3.mS(), 1e3);
            Assert.AreEqual(t3.uS(), 1e6);
            Assert.AreEqual(t3.nS(), 1e9);
            Assert.AreEqual(t3.pS(), 1e12);

            QTimes t4 = new QTimes(1e9, QTimes.QuantityUnit.QT_nS);
            Assert.AreEqual(t4.S(), 1);
            Assert.AreEqual(t4.mS(), 1e3);
            Assert.AreEqual(t4.uS(), 1e6);
            Assert.AreEqual(t4.nS(), 1e9);
            Assert.AreEqual(t4.pS(), 1e12);

            QTimes t5 = new QTimes(1e12, QTimes.QuantityUnit.QT_pS);
            Assert.AreEqual(t5.S(), 1);
            Assert.AreEqual(t5.mS(), 1e3);
            Assert.AreEqual(t5.uS(), 1e6);
            Assert.AreEqual(t5.nS(), 1e9);
            Assert.AreEqual(t5.pS(), 1e12);
        }

        [TestMethod]
        public void QAngleSpeed_TEST()
        {
            QAngleSpeed as1 = new QAngleSpeed(1);
            Assert.AreEqual(as1.DpS(), 1);
            Assert.AreEqual(as1.mDpS(), 1000);
            Assert.AreEqual(as1.DpM(), 60);
            Assert.AreEqual(as1.mDpM(), 6e4);
            Assert.AreEqual(as1.DpH(), 3600);
            Assert.AreEqual(as1.mDpH(), 3.6e6);
            Assert.AreEqual(as1.RPM(), 1 / 6.0);

            QAngleSpeed as2 = new QAngleSpeed(1000, QAngleSpeed.QuantityUnit.QT_mDpS);
            Assert.AreEqual(as2.DpS(), 1);
            Assert.AreEqual(as2.mDpS(), 1000);
            Assert.AreEqual(as2.DpM(), 60);
            Assert.AreEqual(as2.mDpM(), 6e4);
            Assert.AreEqual(as2.DpH(), 3600);
            Assert.AreEqual(as2.mDpH(), 3.6e6);
            Assert.AreEqual(as2.RPM(), 1 / 6.0);

            QAngleSpeed as3 = new QAngleSpeed(60, QAngleSpeed.QuantityUnit.QT_DpM);
            Assert.AreEqual(as3.DpS(), 1);
            Assert.AreEqual(as3.mDpS(), 1000);
            Assert.AreEqual(as3.DpM(), 60);
            Assert.AreEqual(as3.mDpM(), 6e4);
            Assert.AreEqual(as3.DpH(), 3600);
            Assert.AreEqual(as3.mDpH(), 3.6e6);
            Assert.AreEqual(as3.RPM(), 1 / 6.0);

            QAngleSpeed as4 = new QAngleSpeed(6e4, QAngleSpeed.QuantityUnit.QT_mDpM);
            Assert.AreEqual(as4.DpS(), 1);
            Assert.AreEqual(as4.mDpS(), 1000);
            Assert.AreEqual(as4.DpM(), 60);
            Assert.AreEqual(as4.mDpM(), 6e4);
            Assert.AreEqual(as4.DpH(), 3600);
            Assert.AreEqual(as4.mDpH(), 3.6e6);
            Assert.AreEqual(as4.RPM(), 1 / 6.0);

            QAngleSpeed as5 = new QAngleSpeed(3600, QAngleSpeed.QuantityUnit.QT_DpH);
            Assert.AreEqual(as5.DpS(), 1);
            Assert.AreEqual(as5.mDpS(), 1000);
            Assert.AreEqual(as5.DpM(), 60);
            Assert.AreEqual(as5.mDpM(), 6e4);
            Assert.AreEqual(as5.DpH(), 3600);
            Assert.AreEqual(as5.mDpH(), 3.6e6);
            Assert.AreEqual(as5.RPM(), 1 / 6.0);

            QAngleSpeed as6 = new QAngleSpeed(3.6e6, QAngleSpeed.QuantityUnit.QT_mDpH);
            Assert.AreEqual(as6.DpS(), 1);
            Assert.AreEqual(as6.mDpS(), 1000);
            Assert.AreEqual(as6.DpM(), 60);
            Assert.AreEqual(as6.mDpM(), 6e4);
            Assert.AreEqual(as6.DpH(), 3600);
            Assert.AreEqual(as6.mDpH(), 3.6e6);
            Assert.AreEqual(as6.RPM(), 1 / 6.0);

            QAngleSpeed as7 = new QAngleSpeed(0.1666, QAngleSpeed.QuantityUnit.QT_RPM);
            Assert.AreEqual(as7.DpS(), 1);
            Assert.AreEqual(as7.mDpS(), 1000);
            Assert.AreEqual(as7.DpM(), 60);
            Assert.AreEqual(as7.mDpM(), 6e4);
            Assert.AreEqual(as7.DpH(), 3600);
            Assert.AreEqual(as7.mDpH(), 3.6e6);
            Assert.AreEqual(as7.RPM(), 1 / 6.0);
        }

        [TestMethod]
        public void QAngle_TEST()
        {
            QAngle a1 = new QAngle(100, QAngle.QuantityUnit.QT_Deg);
            Assert.AreEqual(a1.Deg(), 100);
            Assert.AreEqual(a1.mDeg(), 100e3);
            Assert.AreEqual(a1.Rad(), 1.74533);

            QAngle a2 = new QAngle(100e3, QAngle.QuantityUnit.QT_mDeg);
            Assert.AreEqual(a2.Deg(), 100);
            Assert.AreEqual(a2.mDeg(), 100e3);
            Assert.AreEqual(a2.Rad(), 1.74533);

            QAngle a3 = new QAngle(1.74533, QAngle.QuantityUnit.QT_Rad);
            Assert.AreEqual(a3.Deg(), 100);
            Assert.AreEqual(a3.mDeg(), 100e3);
            Assert.AreEqual(a3.Rad(), 1.74533);
        }

        [TestMethod]
        public void QGroundSpeed_TEST()
        {
            QGroundSpeed gs1 = new QGroundSpeed(10, QGroundSpeed.QuantityUnit.QT_KMPH);
            Assert.AreEqual(gs1.KMPh(), 10);
            Assert.AreEqual(gs1.KMPs(), 10.0 / 3600.0);
            Assert.AreEqual(gs1.MPh(), 0.01);
            Assert.AreEqual(gs1.MPs(), 0.01 / 3600.0);

            QGroundSpeed gs2 = new QGroundSpeed(10.0 / 3600.0, QGroundSpeed.QuantityUnit.QT_KMPS);
            Assert.AreEqual(gs2.KMPh(), 10);
            Assert.AreEqual(gs2.KMPs(), 10.0 / 3600.0);
            Assert.AreEqual(gs2.MPh(), 0.01);
            Assert.AreEqual(gs2.MPs(), 0.01 / 3600.0);

            QGroundSpeed gs3 = new QGroundSpeed(0.01, QGroundSpeed.QuantityUnit.QT_MPH);
            Assert.AreEqual(gs3.KMPh(), 10);
            Assert.AreEqual(gs3.KMPs(), 10.0 / 3600.0);
            Assert.AreEqual(gs3.MPh(), 0.01);
            Assert.AreEqual(gs3.MPs(), 0.01 / 3600.0);

            QGroundSpeed gs4 = new QGroundSpeed(0.01 / 3600.0, QGroundSpeed.QuantityUnit.QT_MPS);
            Assert.AreEqual(gs4.KMPh(), 10);
            Assert.AreEqual(gs4.KMPs(), 10.0 / 3600.0);
            Assert.AreEqual(gs4.MPh(), 0.01);
            Assert.AreEqual(gs4.MPs(), 0.01 / 3600.0);
        }

        [TestMethod]
        public void QDistance_TEST()
        {
            QDistance d1 = new QDistance(25, QDistance.QuantityUnit.QT_CM);
            Assert.AreEqual(d1.Cm(), 25);
            Assert.AreEqual(d1.Foot(), 0.82021);
            Assert.AreEqual(d1.Inch(), 9.84252);
            Assert.AreEqual(d1.Km(), 0.00025);
            Assert.AreEqual(d1.M(), 0.25);
            Assert.AreEqual(d1.Mi(), 0.000155343);
            Assert.AreEqual(d1.Mm(), 250);

            QDistance d2 = new QDistance(0.82021, QDistance.QuantityUnit.QT_Foot);
            Assert.AreEqual(d2.Cm(), 25);
            Assert.AreEqual(d2.Foot(), 0.82021);
            Assert.AreEqual(d2.Inch(), 9.84252);
            Assert.AreEqual(d2.Km(), 0.00025);
            Assert.AreEqual(d2.M(), 0.25);
            Assert.AreEqual(d2.Mi(), 0.000155343);
            Assert.AreEqual(d2.Mm(), 250);

            QDistance d3 = new QDistance(9.84252, QDistance.QuantityUnit.QT_INCH);
            Assert.AreEqual(d3.Cm(), 25);
            Assert.AreEqual(d3.Foot(), 0.82021);
            Assert.AreEqual(d3.Inch(), 9.84252);
            Assert.AreEqual(d3.Km(), 0.00025);
            Assert.AreEqual(d3.M(), 0.25);
            Assert.AreEqual(d3.Mi(), 0.000155343);
            Assert.AreEqual(d3.Mm(), 250);

            QDistance d4 = new QDistance(0.00025, QDistance.QuantityUnit.QT_KM);
            Assert.AreEqual(d4.Cm(), 25);
            Assert.AreEqual(d4.Foot(), 0.82021);
            Assert.AreEqual(d4.Inch(), 9.84252);
            Assert.AreEqual(d4.Km(), 0.00025);
            Assert.AreEqual(d4.M(), 0.25);
            Assert.AreEqual(d4.Mi(), 0.000155343);
            Assert.AreEqual(d4.Mm(), 250);

            QDistance d5 = new QDistance(0.25, QDistance.QuantityUnit.QT_M);
            Assert.AreEqual(d5.Cm(), 25);
            Assert.AreEqual(d5.Foot(), 0.82021);
            Assert.AreEqual(d5.Inch(), 9.84252);
            Assert.AreEqual(d5.Km(), 0.00025);
            Assert.AreEqual(d5.M(), 0.25);
            Assert.AreEqual(d5.Mi(), 0.000155343);
            Assert.AreEqual(d5.Mm(), 250);

            QDistance d6 = new QDistance(0.000155343, QDistance.QuantityUnit.QT_Mile);
            Assert.AreEqual(d6.Cm(), 25);
            Assert.AreEqual(d6.Foot(), 0.82021);
            Assert.AreEqual(d6.Inch(), 9.84252);
            Assert.AreEqual(d6.Km(), 0.00025);
            Assert.AreEqual(d6.M(), 0.25);
            Assert.AreEqual(d6.Mi(), 0.000155343);
            Assert.AreEqual(d6.Mm(), 250);

            QDistance d = new QDistance(250, QDistance.QuantityUnit.QT_MM);
            Assert.AreEqual(d.Cm(), 25);
            Assert.AreEqual(d.Foot(), 0.82021);
            Assert.AreEqual(d.Inch(), 9.84252);
            Assert.AreEqual(d.Km(), 0.00025);
            Assert.AreEqual(d.M(), 0.25);
            Assert.AreEqual(d.Mi(), 0.000155343);
            Assert.AreEqual(d.Mm(), 250);
        }
    }
}
