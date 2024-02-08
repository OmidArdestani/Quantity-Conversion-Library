using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsQuantity
{
    //-----------------------------------------------------------------------------
    //								Signal Frequency
    //-----------------------------------------------------------------------------
    public class QFrequency
    {
        public enum QuantityUnit
        {
            QT_GHz, QT_MHz, QT_KHz, QT_Hz, _NumberOfUnits
        };
        public QFrequency()
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QuantityUnit.QT_MHz, 0);
            InitConversionMatrix();
        }
        public QFrequency(double value, QuantityUnit QType = QuantityUnit.QT_MHz)
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QType, value);
            InitConversionMatrix();
        }
        public void GHz(double value) => ValueMap.Add(QuantityUnit.QT_GHz, value);
        public void MHz(double value) => ValueMap.Add(QuantityUnit.QT_MHz, value);
        public void KHz(double value) => ValueMap.Add(QuantityUnit.QT_KHz, value);
        public void Hz(double value) => ValueMap.Add(QuantityUnit.QT_Hz, value);

        public double GHz() => GetMount(QuantityUnit.QT_GHz);
        public double MHz() => GetMount(QuantityUnit.QT_MHz);
        public double KHz() => GetMount(QuantityUnit.QT_KHz);
        public double Hz() => GetMount(QuantityUnit.QT_Hz);

        private double GetMount(QuantityUnit return_mode)
        {
            // get the setting unit
            if (ValueMap.ContainsKey(return_mode))
                return ValueMap[return_mode];

            // check the available unit in map
            var first_item = ValueMap.First();
            double converted_value = first_item.Value * ConversionMatrix[(int)first_item.Key, (int)return_mode];

            return converted_value;
        }
        private Dictionary<QuantityUnit, double> ValueMap;

        private double[,] ConversionMatrix;
        private void InitConversionMatrix()
        {
            double[,] conversion_matrix =
            {
				//QT_GHz,  QT_MHz,  QT_KHz,   QT_Hz
				{ 1      , 1e3    , 1e6     , 1e9  }, //QT_GHz
				{ 1e-3   , 1      , 1e3     , 1e6  }, //QT_MHz
				{ 1e-6   , 1e-3   , 1       , 1e3  }, //QT_KHz
				{ 1e-9   , 1e-6   , 1e-3    , 1    }  //QT_Hz
			};

            ConversionMatrix = conversion_matrix;
        }

        public static QFrequency operator +(QFrequency a, QFrequency b) => new QFrequency(a.MHz() + b.MHz());
        public static QFrequency operator -(QFrequency a, QFrequency b) => new QFrequency(a.MHz() - b.MHz());
        public static double operator /(QFrequency a, QFrequency b) => a.MHz() / b.MHz();
        public static bool operator ==(QFrequency a, QFrequency b) => (a.MHz() == b.MHz());
        public static bool operator >(QFrequency a, QFrequency b) => (a.MHz() > b.MHz());
        public static bool operator <(QFrequency a, QFrequency b) => (a.MHz() < b.MHz());
        public static bool operator >=(QFrequency a, QFrequency b) => (a.MHz() >= b.MHz());
        public static bool operator <=(QFrequency a, QFrequency b) => (a.MHz() <= b.MHz());
        public static bool operator !=(QFrequency a, QFrequency b) => (a.MHz() != b.MHz());
        public static QFrequency operator /(QFrequency a, double b) => new QFrequency(a.MHz() / b);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode() => 0;
    };

    //-----------------------------------------------------------------------------
    //								Signal Level
    //-----------------------------------------------------------------------------
    public class QSignalLevel
    {
        public enum QuantityUnit
        {
            QT_dBm, QT_dB, QT_Wat, QT_mWat, QT_Volt, _NumberOfUnits
        };
        public QSignalLevel()
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QuantityUnit.QT_dB, 0);
            InitConversionMatrix();
        }
        public QSignalLevel(double value, QuantityUnit QType = QuantityUnit.QT_dBm)
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QType, value);
            InitConversionMatrix();
        }
        public void dBm(double value) => ValueMap.Add(QuantityUnit.QT_dBm, value);
        public void dB(double value) => ValueMap.Add(QuantityUnit.QT_dB, value);
        public void Wat(double value) => ValueMap.Add(QuantityUnit.QT_Wat, value);
        public void mWat(double value) => ValueMap.Add(QuantityUnit.QT_mWat, value);
        public void volt(double value) => ValueMap.Add(QuantityUnit.QT_Volt, value);
        public double dBm() => GetMount(QuantityUnit.QT_dBm);
        public double dB() => GetMount(QuantityUnit.QT_dB);
        public double Wat() => GetMount(QuantityUnit.QT_Wat);
        public double mWat() => GetMount(QuantityUnit.QT_mWat);
        public double volt() => GetMount(QuantityUnit.QT_Volt);

        private double GetMount(QuantityUnit return_mode)
        {
            // get the setting unit
            if (ValueMap.ContainsKey(return_mode))
                return ValueMap[return_mode];

            // check the available unit in map
            var first_item = ValueMap.First();
            var f = ConversionMatrix[(int)first_item.Key, (int)return_mode];
            double converted_value = f(first_item.Value);

            return converted_value;
        }
        private Dictionary<QuantityUnit, double> ValueMap;

        // I need a matrix of operand, as for calculating needs pow and offset, it's not a simple factor.
        Func<double, double>[,] ConversionMatrix;
        private void InitConversionMatrix()
        {
            Func<double, double>[,] conversion_matrix =
            {
                //QT_dBm,								            QT_dB,						                          QT_Wat,										        QT_mWat,									            QT_Volt
                {(double v)=>{ return v; },                         (double v)=>{ return v - 30; },                       (double v)=>{ return Math.Pow(10, (v - 30) / 10.0); },(double v)=>{ return Math.Pow(10, v / 10.0); },         (double v)=>{ return Math.Pow(10, (v - 30.0) / 20.0); } }, //QT_dBm
		        {(double v)=>{ return v + 30; },                    (double v)=>{ return v; },                            (double v)=>{ return Math.Pow(10, v / 10.0); },       (double v)=>{ return Math.Pow(10, v / 10.0) * 1000.0; },(double v)=>{ return Math.Pow(10, v / 20.0); } },          //QT_dB
		        {(double v)=>{ return Math.Log10(v) * 10.0 + 30; }, (double v)=>{ return Math.Log10(v) * 10.0; },         (double v)=>{ return v; },                            (double v)=>{ return v * 1000; },                       (double v)=>{ return Math.Sqrt(v); } },                    //QT_Wat
		        {(double v)=>{ return Math.Log10(v) * 10.0; },      (double v)=>{ return Math.Log10(v / 1000.0) * 10.0; },(double v)=>{ return v / 1000.0; },                   (double v)=>{ return v; },                              (double v)=>{ return Math.Sqrt(v / 1000.0); } },           //QT_mWat
		        {(double v)=>{ return Math.Log10(v) * 20.0 + 30; }, (double v)=>{ return Math.Log10(v) * 20.0; },         (double v)=>{ return v * v; },                        (double v)=>{ return v * v * 1000.0; },                 (double v)=>{ return v; } }                                //QT_Volt
            };
            ConversionMatrix = conversion_matrix;
        }

        // operators
        public static QSignalLevel operator +(QSignalLevel a, QSignalLevel b) => new QSignalLevel(a.dBm() + b.dBm());

        public static QSignalLevel operator -(QSignalLevel a, QSignalLevel b) => new QSignalLevel(a.dBm() - b.dBm());
        public static double operator /(QSignalLevel a, QSignalLevel b) => a.dBm() / b.dBm();
        public override int GetHashCode() => throw new NotImplementedException();
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public static bool operator ==(QSignalLevel a, QSignalLevel b) => (a.dBm() == b.dBm());
        public static bool operator >(QSignalLevel a, QSignalLevel b) => (a.dBm() > b.dBm());
        public static bool operator <(QSignalLevel a, QSignalLevel b) => (a.dBm() < b.dBm());
        public static bool operator >=(QSignalLevel a, QSignalLevel b) => (a.dBm() >= b.dBm());
        public static bool operator <=(QSignalLevel a, QSignalLevel b) => (a.dBm() <= b.dBm());
        public static bool operator !=(QSignalLevel a, QSignalLevel b) => (a.dBm() != b.dBm());
    };

    //-----------------------------------------------------------------------------
    //								Time
    //-----------------------------------------------------------------------------
    public class QTimes
    {
        public enum QuantityUnit
        {
            QT_S, QT_mS, QT_uS, QT_nS, QT_pS, _NumberOfUnits
        };
        public QTimes()
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QuantityUnit.QT_S, 0);
            InitConversionMatrix();
        }
        public QTimes(double value, QuantityUnit QType = QuantityUnit.QT_mS)
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QType, value);
            InitConversionMatrix();
        }
        public void S(double value) => ValueMap.Add(QuantityUnit.QT_S, value);
        public void mS(double value) => ValueMap.Add(QuantityUnit.QT_mS, value);
        public void uS(double value) => ValueMap.Add(QuantityUnit.QT_uS, value);
        public void nS(double value) => ValueMap.Add(QuantityUnit.QT_nS, value);
        public void pS(UInt64 value) => ValueMap.Add(QuantityUnit.QT_pS, value);

        public double S() => GetMount(QuantityUnit.QT_S);
        public double mS() => GetMount(QuantityUnit.QT_mS);
        public double uS() => GetMount(QuantityUnit.QT_uS);
        public double nS() => GetMount(QuantityUnit.QT_nS);
        public UInt64 pS() => (UInt64)GetMount(QuantityUnit.QT_pS);

        private double GetMount(QuantityUnit return_mode)
        {
            // get the setting unit
            if (ValueMap.ContainsKey(return_mode))
                return ValueMap[return_mode];

            // check the available unit in map
            var first_item = ValueMap.First();
            double converted_value = first_item.Value * ConversionMatrix[(int)first_item.Key, (int)return_mode];

            return converted_value;
        }

        private Dictionary<QuantityUnit, double> ValueMap;

        private double[,] ConversionMatrix;
        private void InitConversionMatrix()
        {
            double[,] conversion_matrix =
            {
                //QT_S,    QT_mS,   QT_uS,    QT_nS,   QT_pS
                { 1      , 1e3    , 1e6     , 1e9    , 1e12 }, //QT_S
		        { 1e-3   , 1      , 1e3     , 1e6    , 1e9  }, //QT_mS
		        { 1e-6   , 1e-3   , 1       , 1e3    , 1e6  }, //QT_uS
		        { 1e-9   , 1e-6   , 1e-3    , 1      , 1e3  }, //QT_nS
		        { 1e-12  , 1e-9   , 1e-6    , 1e-3   , 1    }  //QT_pS
            };

            ConversionMatrix = conversion_matrix;
        }

        // operators
        public static QTimes operator +(QTimes a, QTimes b) => new QTimes(a.mS() + b.mS());

        public static QTimes operator -(QTimes a, QTimes b) => new QTimes(a.mS() - b.mS());

        public static double operator /(QTimes a, QTimes b) => a.mS() / b.mS();

        public static bool operator ==(QTimes a, QTimes b) => (a.mS() == b.mS());

        public static bool operator >(QTimes a, QTimes b) => (a.mS() > b.mS());

        public static bool operator <(QTimes a, QTimes b) => (a.mS() < b.mS());

        public static bool operator >=(QTimes a, QTimes b) => (a.mS() >= b.mS());

        public static bool operator <=(QTimes a, QTimes b) => (a.mS() <= b.mS());

        public static bool operator !=(QTimes a, QTimes b) => (a.mS() != b.mS());
        public string GetTimeDurationString()
        {
            QTimes timeTemp = new QTimes(this.mS());
            double hours = timeTemp.S() / 3600;

            hours = hours < 0 ? 0 : hours;
            timeTemp.S(timeTemp.S() - (hours * 3600));
            double mins = timeTemp.S() / 60;

            mins = mins < 0 ? 0 : mins;
            timeTemp.S(timeTemp.S() - (mins * 60));

            double seconds = timeTemp.S();
            return string.Format("%1:%2:%3", hours, mins, seconds);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode() => 0;
    };

    //-----------------------------------------------------------------------------
    //								Angular Speed
    //-----------------------------------------------------------------------------
    public class QAngleSpeed
    {
        public enum QuantityUnit
        {
            QT_DpS, QT_mDpS, QT_DpM, QT_mDpM, QT_DpH, QT_mDpH, QT_RPM, _NumberOfUnits
        };
        public QAngleSpeed()
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QuantityUnit.QT_DpS, 0);
            InitConversionMatrix();
        }
        public QAngleSpeed(double value, QuantityUnit QType = QuantityUnit.QT_DpS)
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QType, value);
            InitConversionMatrix();
        }
        public void DpS(double value) => ValueMap.Add(QuantityUnit.QT_DpS, value);
        public void mDpS(double value) => ValueMap.Add(QuantityUnit.QT_mDpS, value);
        public void DpH(double value) => ValueMap.Add(QuantityUnit.QT_DpH, value);
        public void mDpH(double value) => ValueMap.Add(QuantityUnit.QT_mDpH, value);

        public double DpS() => GetMount(QuantityUnit.QT_DpS);
        public double DpM() => GetMount(QuantityUnit.QT_DpM);
        public double DpH() => GetMount(QuantityUnit.QT_DpH);
        public double mDpS() => GetMount(QuantityUnit.QT_mDpS);
        public double mDpM() => GetMount(QuantityUnit.QT_mDpM);
        public double mDpH() => GetMount(QuantityUnit.QT_mDpH);
        public double RPM() => GetMount(QuantityUnit.QT_RPM);

        private double GetMount(QuantityUnit return_mode)
        {
            // get the setting unit
            if (ValueMap.ContainsKey(return_mode))
                return ValueMap[return_mode];

            // check the available unit in map
            var first_item = ValueMap.First();
            double converted_value = first_item.Value * ConversionMatrix[(int)first_item.Key, (int)return_mode];

            return converted_value;
        }

        Dictionary<QuantityUnit, double> ValueMap;

        private double[,] ConversionMatrix;
        private void InitConversionMatrix()
        {
            double[,] conversion_matrix =
            {
                //QT_DpS,      QT_mDpS,     QT_DpM,    QT_mDpM,   QT_DpH,   QT_mDpH,   QT_RPM
                { 1            , 1e3        , 60       , 6e4      , 3600    , 3.6e6    , 1 / 6.0     }, //QT_DpS
		        { 1e-3         , 1          , 0.06     , 60       , 3.6     , 3.6e3    , 1e-3 / 6.0  }, //QT_mDpS
		        { 1.0 / 60.0   , 100 / 6.0  , 1        , 1e3      , 60.0    , 60e3     , 1 / 360.0   }, //QT_DpM
		        { 1.0 / 6e4    , 1.0 / 60   , 1e-3     , 1        , 6e-2    , 60.0     , 1.0 / 36e4  }, //QT_mDpM
		        { 1 / 3600.0   , 1 / 3.6    , 1 / 60.0 , 100 / 6.0, 1       , 1e3      , 1.0 / 2.16e4}, //QT_DpH
		        { 1.0 / 3.6e6  , 1.0 / 3.6e3, 1.0 / 6e4, 1 / 60.0 , 1e-3     , 1       , 1.0 / 2.16e7}, //QT_mDpH
		        { 6            , 6e3        , 360      , 36e4     , 21600   , 21.6e6   , 1           }  //QT_RPM
            };

            ConversionMatrix = conversion_matrix;
        }

        // operators
        public static QAngleSpeed operator +(QAngleSpeed a, QAngleSpeed b) => new QAngleSpeed(a.DpS() + b.DpS());
        public static QAngleSpeed operator -(QAngleSpeed a, QAngleSpeed b) => new QAngleSpeed(a.DpS() - b.DpS());
        public static QAngleSpeed operator *(QAngleSpeed a, QAngleSpeed b) => new QAngleSpeed(a.DpS() * b.DpS());
        public static QAngleSpeed operator /(QAngleSpeed a, QAngleSpeed b) => new QAngleSpeed(a.DpS() / b.DpS());
        public static bool operator ==(QAngleSpeed a, QAngleSpeed b) => (a.DpS() == b.DpS());
        public static bool operator >(QAngleSpeed a, QAngleSpeed b) => (a.DpS() > b.DpS());
        public static bool operator <(QAngleSpeed a, QAngleSpeed b) => (a.DpS() < b.DpS());
        public static bool operator >=(QAngleSpeed a, QAngleSpeed b) => (a.DpS() >= b.DpS());
        public static bool operator <=(QAngleSpeed a, QAngleSpeed b) => (a.DpS() <= b.DpS());
        public static bool operator !=(QAngleSpeed a, QAngleSpeed b) => (a.DpS() != b.DpS());
        public override int GetHashCode() => 0;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

    };

    //-----------------------------------------------------------------------------
    //								Angle
    //-----------------------------------------------------------------------------
    public class QAngle
    {
        public enum QuantityUnit
        {
            QT_Deg, QT_mDeg, QT_Rad, _NumberOfUnits
        };
        public QAngle()
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QuantityUnit.QT_Deg, 0);
            InitConversionMatrix();
        }
        public QAngle(double value, QuantityUnit QType = QuantityUnit.QT_Deg)
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QType, value);
            InitConversionMatrix();
        }
        public void Deg(double value) => ValueMap.Add(QuantityUnit.QT_Deg, value);
        public void Rad(double value) => ValueMap.Add(QuantityUnit.QT_Rad, value);
        public void mDeg(double value) => ValueMap.Add(QuantityUnit.QT_mDeg, value);

        public double Deg() => GetMount(QuantityUnit.QT_Deg);
        public double Rad() => GetMount(QuantityUnit.QT_Rad);
        public double mDeg() => GetMount(QuantityUnit.QT_mDeg);
        public static QAngle Wrap360(QAngle angle)
        {
            QAngle returnAngle = angle;

            while (returnAngle.Deg() >= 360)
            {
                returnAngle.Deg(returnAngle.Deg() - 360);
            }
            while (returnAngle.Deg() < 0)
            {
                returnAngle.Deg(returnAngle.Deg() + 360);
            }
            return returnAngle;
        }
        public static QAngle Wrap180(QAngle angle)
        {
            QAngle returnAngle = angle;

            while (returnAngle.Deg() >= 180)
            {
                returnAngle.Deg(returnAngle.Deg() - 180);
            }
            while (returnAngle.Deg() < 0)
            {
                returnAngle.Deg(returnAngle.Deg() + 180);
            }
            return returnAngle;
        }
        public static QAngle Wrap90(QAngle angle)
        {
            QAngle returnAngle = angle;

            while (returnAngle.Deg() >= 90)
            {
                returnAngle.Deg(returnAngle.Deg() - 90);
            }
            while (angle.Deg() < 0)
            {
                returnAngle.Deg(returnAngle.Deg() + 90);
            }
            return returnAngle;
        }

        private double GetMount(QuantityUnit return_mode)
        {
            // get the setting unit
            if (ValueMap.ContainsKey(return_mode))
                return ValueMap[return_mode];

            // check the available unit in map
            var first_item = ValueMap.First();
            double converted_value = first_item.Value * ConversionMatrix[(int)first_item.Key, (int)return_mode];

            return converted_value;
        }
        private Dictionary<QuantityUnit, double> ValueMap;
        private double[,] ConversionMatrix;
        private void InitConversionMatrix()
        {
            double[,] conversion_matrix =
            {
                //QT_Deg, QT_mDeg,  QT_Rad
                { 1      , 1e3    , 0.01745329251        }, //QT_Deg
		        { 1e-3   , 1      , 0.0000174532925199433}, //QT_mDeg
		        { 57.2958, 57295.8, 1                    }  //QT_Rad
            };

            ConversionMatrix = conversion_matrix;
        }

        // operators
        public static QAngle operator +(QAngle a, QAngle b) => new QAngle(a.Deg() + b.Deg());
        public static QAngle operator -(QAngle a, QAngle b) => new QAngle(a.Deg() - b.Deg());
        public static QAngle operator *(QAngle a, QAngle b) => new QAngle(a.Deg() * b.Deg());
        public static QAngle operator /(QAngle a, QAngle b) => new QAngle(a.Deg() / b.Deg());
        public static bool operator ==(QAngle a, QAngle b) => (a.Deg() == b.Deg());
        public static bool operator >(QAngle a, QAngle b) => (a.Deg() > b.Deg());
        public static bool operator <(QAngle a, QAngle b) => (a.Deg() < b.Deg());
        public static bool operator >=(QAngle a, QAngle b) => (a.Deg() >= b.Deg());
        public static bool operator <=(QAngle a, QAngle b) => (a.Deg() <= b.Deg());
        public static bool operator !=(QAngle a, QAngle b) => (a.Deg() != b.Deg());
        public override int GetHashCode() => 0;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

    };

    //-----------------------------------------------------------------------------
    //								Ground Speed
    //-----------------------------------------------------------------------------
    public class QGroundSpeed
    {
        public enum QuantityUnit
        {
            QT_MPS, QT_KMPS, QT_MPH, QT_KMPH, _NumberOfUnits
        };
        public QGroundSpeed()
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QuantityUnit.QT_KMPH, 0);
            InitConversionMatrix();
        }
        public QGroundSpeed(double value, QuantityUnit QType = QuantityUnit.QT_KMPH)
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QType, value);
            InitConversionMatrix();
        }
        public void KMPh(double value) => ValueMap.Add(QuantityUnit.QT_KMPH, value);
        public void MPh(double value) => ValueMap.Add(QuantityUnit.QT_MPH, value);
        public void KMPs(double value) => ValueMap.Add(QuantityUnit.QT_KMPS, value);
        public void MPs(double value) => ValueMap.Add(QuantityUnit.QT_MPS, value);

        public double KMPh() => GetMount(QuantityUnit.QT_KMPH);
        public double MPh() => GetMount(QuantityUnit.QT_MPH);
        public double KMPs() => GetMount(QuantityUnit.QT_KMPS);
        public double MPs() => GetMount(QuantityUnit.QT_MPS);

        private double GetMount(QuantityUnit return_mode)
        {
            // get the setting unit
            if (ValueMap.ContainsKey(return_mode))
                return ValueMap[return_mode];

            // check the available unit in map
            var first_item = ValueMap.First();
            double converted_value = first_item.Value * ConversionMatrix[(int)first_item.Key, (int)return_mode];

            return converted_value;
        }

        private Dictionary<QuantityUnit, double> ValueMap;

        double[,] ConversionMatrix;
        private void InitConversionMatrix()
        {
            double[,] conversion_matrix =
            {
                //QT_MPS,     QT_KMPS,    QT_MPH, QT_KMPH
                { 1         , 0.001     , 3600  , 3.6    }, //QT_MPS
		        { 1000      , 1         , 3.6e6 , 3600   }, //QT_KMPS
		        { 0.00027778, 2.7778e-7 , 1     , 0.001  }, //QT_MPH
		        { 0.27778   , 0.00027778, 1000  , 1      }  //QT_KMPH
            };

            ConversionMatrix = conversion_matrix;
        }

        // operators
        public static QGroundSpeed operator +(QGroundSpeed a, QGroundSpeed b) => new QGroundSpeed(a.KMPh() + b.KMPh());
        public static QGroundSpeed operator -(QGroundSpeed a, QGroundSpeed b) => new QGroundSpeed(a.KMPh() - b.KMPh());
        public static double operator /(QGroundSpeed a, QGroundSpeed b) => a.KMPh() / b.KMPh();
        public static bool operator ==(QGroundSpeed a, QGroundSpeed b) => (a.KMPh() == b.KMPh());
        public static bool operator >(QGroundSpeed a, QGroundSpeed b) => (a.KMPh() > b.KMPh());
        public static bool operator <(QGroundSpeed a, QGroundSpeed b) => (a.KMPh() < b.KMPh());
        public static bool operator >=(QGroundSpeed a, QGroundSpeed b) => (a.KMPh() >= b.KMPh());
        public static bool operator <=(QGroundSpeed a, QGroundSpeed b) => (a.KMPh() <= b.KMPh());
        public static bool operator !=(QGroundSpeed a, QGroundSpeed b) => (a.KMPh() != b.KMPh());
        public override int GetHashCode() => 0;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

    };

    //-----------------------------------------------------------------------------
    //								Distance
    //-----------------------------------------------------------------------------
    public class QDistance
    {
        public enum QuantityUnit
        {
            QT_MM, QT_CM, QT_M, QT_KM, QT_Mile, QT_INCH, QT_Foot, _NumberOfUnits
        };
        public QDistance()
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QuantityUnit.QT_M, 0);
            InitConversionMatrix();
        }
        public QDistance(double value, QuantityUnit QType = QuantityUnit.QT_M)
        {
            ValueMap = new Dictionary<QuantityUnit, double> { };
            ValueMap.Add(QType, value);
            InitConversionMatrix();
        }
        public void Mm(double value) => ValueMap.Add(QuantityUnit.QT_MM, value);
        public void Cm(double value) => ValueMap.Add(QuantityUnit.QT_CM, value);
        public void M(double value) => ValueMap.Add(QuantityUnit.QT_M, value);
        public void Km(double value) => ValueMap.Add(QuantityUnit.QT_KM, value);
        public void Mi(double value) => ValueMap.Add(QuantityUnit.QT_Mile, value);
        public void Inch(double value) => ValueMap.Add(QuantityUnit.QT_INCH, value);
        public void Foot(double value) => ValueMap.Add(QuantityUnit.QT_Foot, value);
        public double Mm() => GetMount(QuantityUnit.QT_MM);
        public double Cm() => GetMount(QuantityUnit.QT_CM);
        public double M() => GetMount(QuantityUnit.QT_M);
        public double Km() => GetMount(QuantityUnit.QT_KM);
        public double Mi() => GetMount(QuantityUnit.QT_Mile);
        public double Inch() => GetMount(QuantityUnit.QT_INCH);
        public double Foot() => GetMount(QuantityUnit.QT_Foot);

        private Dictionary<QuantityUnit, double> ValueMap;

        private double[,] ConversionMatrix;
        void InitConversionMatrix()
        {
            double[,] conversion_matrix =
            {     //QT_MM,    QT_CM,  QT_M,        QT_KM,     QT_Mile,     QT_INCH,  QT_Foot
                  { 1,        0.1,    1e-3,        1e-6,      6.2137e-7,   0.0393701,0.00328084},    // QT_MM
	              { 10,       1,      0.01,        1e-5,      6.21371e-6,  0.393701 ,0.0328084 },    // QT_CM
	              { 1e3,      1e2,    1,           1e-3,      0.000621371, 39.3701  ,3.28084   },    // QT_M
	              { 1e6,      1e5,    1e3,         1,         0.621371,    39370.1  ,3280.84   },    // QT_KM
	              { 1.609e+6, 160934, 1609.34,     1.60934,   1,           63360    ,5280      },    // QT_Mile
	              { 25.4,     2.54,   0.0254,      2.54e-5,   1.5783e-5,   1        ,0.0833333 },    // QT_Inch
	              { 304.8,    30.48,  0.3048 ,     0.0003048, 0.000189394, 12       ,1         }     // QT_Foot
            };

            ConversionMatrix = conversion_matrix;
        }

        double GetMount(QuantityUnit return_mode)
        {
            // get the setting unit
            if (ValueMap.ContainsKey(return_mode))
                return ValueMap[return_mode];

            // check the available unit in map
            var first_item = ValueMap.First();
            double converted_value = first_item.Value * ConversionMatrix[(int)first_item.Key, (int)return_mode];

            return converted_value;
        }

        // operators
        public static QDistance operator +(QDistance a, QDistance b) => new QDistance(a.M() + b.M());
        public static QDistance operator -(QDistance a, QDistance b) => new QDistance(a.M() - b.M());
        public static double operator /(QDistance a, QDistance b) => a.M() / b.M();
        public static bool operator ==(QDistance a, QDistance b) => a.M() == b.M();
        public static bool operator >(QDistance a, QDistance b) => a.M() > b.M();
        public static bool operator <(QDistance a, QDistance b) => a.M() < b.M();
        public static bool operator >=(QDistance a, QDistance b) => a.M() >= b.M();
        public static bool operator <=(QDistance a, QDistance b) => a.M() <= b.M();
        public static bool operator !=(QDistance a, QDistance b) => a.M() != b.M();
        public override int GetHashCode() => 0;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    };

    //-----------------------------------------------------------------------------
    //								Quantity Range
    //-----------------------------------------------------------------------------
    public class QRange<T>
    {
        public QRange() { }
        public QRange(T lower, T upper)
        {
            if (Comparer<T>.Default.Compare(lower, upper) < 0)
            {
                LowerValue = upper;
                UpperValue = lower;
            }
            else
            {
                LowerValue = lower;
                UpperValue = upper;
            }
        }

        public void SetLower(T lower) => LowerValue = lower;
        public void SetUpper(T upper) => UpperValue = upper;
        public void Expand(T includeCoord)
        {
            var diff = Comparer<T>.Default.Compare(LowerValue, includeCoord);
            if (diff > 0)
            {
                LowerValue = includeCoord;
            }

            diff = Comparer<T>.Default.Compare(UpperValue, includeCoord);
            if (diff < 0)
            {
                UpperValue = includeCoord;
            }
        }
        public void Expand(QRange<T> otherRange)
        {
            var diff = Comparer<T>.Default.Compare(LowerValue, otherRange.Lower());
            if (diff > 0)
            {
                LowerValue = otherRange.Lower();
            }

            diff = Comparer<T>.Default.Compare(UpperValue, otherRange.Upper());
            if (diff < 0)
            {
                UpperValue = otherRange.Upper();
            }
        }

        bool IsInRange(T value)
        {
            var lower_great = Comparer<T>.Default.Compare(value , Lower()) >= 0;
            var upper_lower = Comparer<T>.Default.Compare(value , Upper()) <= 0;
            return lower_great && upper_lower; 
        }
        bool Contains(T value)
        {
            return IsInRange(value);
        }
        bool Contains(QRange<T> range) 
        { 
            return Contains(range.Lower()) && Contains(range.Upper()); 
        }

        T Lower() => LowerValue;
        T Upper() => UpperValue;
        //T Center() => (Upper() + Lower()) / 2.0;
        //T Size() => (Upper() - Lower());

        T LowerValue;
        T UpperValue;

        //public static bool operator ==(QRange<T> a, QRange<T> b) { return (a.Lower() == b.Lower() && a.Upper() == b.Upper()); }
        //public static bool operator >(QRange<T> a, QRange<T> b) { return (a.Lower() > b.Lower() && a.Upper() > b.Upper()); }
        //public static bool operator <(QRange<T> a, QRange<T> b) { return (a.Lower() < b.Lower() && a.Upper() < b.Upper()); }
        //public static bool operator >=(QRange<T> a, QRange<T> b) { return (a.Lower() >= b.Lower() && a.Upper() >= b.Upper()); }
        //public static bool operator <=(QRange<T> a, QRange<T> b) { return (a.Lower() <= b.Lower() && a.Upper() <= b.Upper()); }
        //public static bool operator !=(QRange<T> a, QRange<T> b) { return (a.Lower() != b.Lower() && a.Upper() != b.Upper()); }
    };
}

