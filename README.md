# Quantity Conversion Library

A C# library implementing the Quantity design pattern for unit conversions. This library provides functionality to convert units for SignalLevel, Frequency, Distance, Ground Speed, Angle Speed, Angle, and Time.

## Table of Contents
- [Introduction](#Introduction)
- [Features](#Features)
- [Usage](#Usage)
- [Examples](#Examples)
- [License](#License)

## Introduction

The Quantity Conversion Library is designed to simplify the conversion of various physical quantities. It follows the Quantity design pattern, allowing for extensibility and flexibility in handling different unit conversions.

## Features

- Conversion of SignalLevel units
- Conversion of Frequency units
- Conversion of Distance units
- Conversion of Ground Speed units
- Conversion of Angle Speed units
- Conversion of Angle units
- Conversion of Time units
- Range option for any types

## Usage

To use the library, include the relevant headers in your project and utilize the provided conversion functions. Below are examples for SignalLevel and Frequency conversion in both C++ and C#.

## Examples

There is examples of each Quantity that is in the QuantityTest.cpp file.

### QFrequency Quantity Example

```cpp
﻿using CsQuantity;

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
```
### QSignalLevel Quantity Example

```cpp
﻿using CsQuantity;

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

```
### QTimes Quantity Example

```cpp
﻿using CsQuantity;

        public void QTimes_TEST()
        {
            QTimes t1 = new QTimes(1, QTimes.QuantityUnit.QT_S);
            Assert.AreEqual(1, t1.S());
            Assert.AreEqual(1e3, t1.mS());
            Assert.AreEqual(1e6, t1.uS());
            Assert.AreEqual(1e9, t1.nS());
            Assert.AreEqual(1e12, t1.pS());

            QTimes t2 = new QTimes(1e3, QTimes.QuantityUnit.QT_mS);
            Assert.AreEqual(1, t2.S());
            Assert.AreEqual(1e3, t2.mS());
            Assert.AreEqual(1e6, t2.uS());
            Assert.AreEqual(1e9, t2.nS());
            Assert.AreEqual(1e12, t2.pS());

            QTimes t3 = new QTimes(1e6, QTimes.QuantityUnit.QT_uS);
            Assert.AreEqual(t3.S(), 1);
            Assert.AreEqual(t3.mS(), 1e3);
            Assert.AreEqual(t3.uS(), 1e6);
            Assert.AreEqual(t3.nS(), 1e9);
            Assert.AreEqual(t3.pS(), 1e12);

            QTimes t4 = new QTimes(1e9, QTimes.QuantityUnit.QT_nS);
            Assert.AreEqual(1, t4.S());
            Assert.AreEqual(1e3, t4.mS());
            Assert.AreEqual(1e6, t4.uS());
            Assert.AreEqual(1e9, t4.nS());
            Assert.AreEqual(1e12, t4.pS());

            QTimes t5 = new QTimes(1e12, QTimes.QuantityUnit.QT_pS);
            Assert.AreEqual(1, t5.S(), 1e-3);
            Assert.AreEqual(1e3, t5.mS(), 1e-3);
            Assert.AreEqual(1e6, t5.uS(), 1e-3);
            Assert.AreEqual(1e9, t5.nS(), 1e-3);
            Assert.AreEqual(1e12, t5.pS(), 1e-3);
        }


```
### QAngleSpeed Quantity Example

```cpp
﻿using CsQuantity;

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
            Assert.AreEqual(as2.DpS(), 1, 1e-6);
            Assert.AreEqual(as2.mDpS(), 1000, 1e-6);
            Assert.AreEqual(as2.DpM(), 60, 1e-6);
            Assert.AreEqual(as2.mDpM(), 6e4, 1e-6);
            Assert.AreEqual(as2.DpH(), 3600, 1e-6);
            Assert.AreEqual(as2.mDpH(), 3.6e6, 1e-6);
            Assert.AreEqual(as2.RPM(), 1 / 6.0, 1e-6);

            QAngleSpeed as3 = new QAngleSpeed(60, QAngleSpeed.QuantityUnit.QT_DpM);
            Assert.AreEqual(as3.DpS(), 1, 1e-6);
            Assert.AreEqual(as3.mDpS(), 1000, 1e-6);
            Assert.AreEqual(as3.DpM(), 60, 1e-6);
            Assert.AreEqual(as3.mDpM(), 6e4, 1e-6);
            Assert.AreEqual(as3.DpH(), 3600, 1e-6);
            Assert.AreEqual(as3.mDpH(), 3.6e6, 1e-6);
            Assert.AreEqual(as3.RPM(), 1 / 6.0, 1e-6);

            QAngleSpeed as4 = new QAngleSpeed(6e4, QAngleSpeed.QuantityUnit.QT_mDpM);
            Assert.AreEqual(as4.DpS(), 1, 1e-6);
            Assert.AreEqual(as4.mDpS(), 1000, 1e-6);
            Assert.AreEqual(as4.DpM(), 60, 1e-6);
            Assert.AreEqual(as4.mDpM(), 6e4, 1e-6);
            Assert.AreEqual(as4.DpH(), 3600, 1e-6);
            Assert.AreEqual(as4.mDpH(), 3.6e6, 1e-6);
            Assert.AreEqual(as4.RPM(), 1 / 6.0, 1e-6);

            QAngleSpeed as5 = new QAngleSpeed(3600, QAngleSpeed.QuantityUnit.QT_DpH);
            Assert.AreEqual(as5.DpS(), 1, 1e-6);
            Assert.AreEqual(as5.mDpS(), 1000, 1e-6);
            Assert.AreEqual(as5.DpM(), 60, 1e-6);
            Assert.AreEqual(as5.mDpM(), 6e4, 1e-6);
            Assert.AreEqual(as5.DpH(), 3600, 1e-6);
            Assert.AreEqual(as5.mDpH(), 3.6e6, 1e-6);
            Assert.AreEqual(as5.RPM(), 1 / 6.0, 1e-6);

            QAngleSpeed as6 = new QAngleSpeed(3.6e6, QAngleSpeed.QuantityUnit.QT_mDpH);
            Assert.AreEqual(as6.DpS(), 1, 1e-6);
            Assert.AreEqual(as6.mDpS(), 1000, 1e-6);
            Assert.AreEqual(as6.DpM(), 60, 1e-6);
            Assert.AreEqual(as6.mDpM(), 6e4, 1e-6);
            Assert.AreEqual(as6.DpH(), 3600, 1e-6);
            Assert.AreEqual(as6.mDpH(), 3.6e6, 1e-6);
            Assert.AreEqual(as6.RPM(), 1 / 6.0, 1e-6);

            QAngleSpeed as7 = new QAngleSpeed(1 / 6.0, QAngleSpeed.QuantityUnit.QT_RPM);
            Assert.AreEqual(as7.DpS(), 1, 1e-6);
            Assert.AreEqual(as7.mDpS(), 1000, 1e-6);
            Assert.AreEqual(as7.DpM(), 60, 1e-6);
            Assert.AreEqual(as7.mDpM(), 6e4, 1e-6);
            Assert.AreEqual(as7.DpH(), 3600, 1e-6);
            Assert.AreEqual(as7.mDpH(), 3.6e6, 1e-6);
            Assert.AreEqual(as7.RPM(), 1 / 6.0, 1e-6);
        }

```
### QAngle Quantity Example

```cpp
﻿using CsQuantity;

        public void QAngle_TEST()
        {
            QAngle a1 = new QAngle(100, QAngle.QuantityUnit.QT_Deg);
            Assert.AreEqual(100, a1.Deg(), 1e-3);
            Assert.AreEqual(100e3, a1.mDeg(), 1e-3);
            Assert.AreEqual(1.745329251, a1.Rad(), 1e-3);

            QAngle a2 = new QAngle(100e3, QAngle.QuantityUnit.QT_mDeg);
            Assert.AreEqual(100, a2.Deg(), 1e-3);
            Assert.AreEqual(100e3, a2.mDeg(), 1e-3);
            Assert.AreEqual(1.745329251, a2.Rad(), 1e-3);

            QAngle a3 = new QAngle(1.7453292519943295, QAngle.QuantityUnit.QT_Rad);
            Assert.AreEqual(100, a3.Deg(), 1e-4);
            Assert.AreEqual(100e3, a3.mDeg(), 0.1);
            Assert.AreEqual(1.745329251, a3.Rad(), 1e-4);
        }

```
### QGroundSpeed Quantity Example

```cpp
﻿using CsQuantity;

        public void QGroundSpeed_TEST()
        {
            QGroundSpeed gs1 = new QGroundSpeed(10, QGroundSpeed.QuantityUnit.QT_KMPH);
            Assert.AreEqual(10, gs1.KMPh(),1e-3);
            Assert.AreEqual(10.0 / 3600.0, gs1.KMPs(), 1e-3);
            Assert.AreEqual(10e3, gs1.MPh(), 1e-3);
            Assert.AreEqual(100 / 36.0, gs1.MPs(), 1e-3);

            QGroundSpeed gs2 = new QGroundSpeed(10.0 / 3600.0, QGroundSpeed.QuantityUnit.QT_KMPS);
            Assert.AreEqual(10, gs2.KMPh(), 1e-3);
            Assert.AreEqual(10.0 / 3600.0, gs2.KMPs(), 1e-3);
            Assert.AreEqual(10000, gs2.MPh(), 1e-3);
            Assert.AreEqual(100 / 36.0, gs2.MPs(), 1e-3);

            QGroundSpeed gs3 = new QGroundSpeed(10000, QGroundSpeed.QuantityUnit.QT_MPH);
            Assert.AreEqual(10, gs3.KMPh(), 1e-3);
            Assert.AreEqual(10.0 / 3600.0, gs3.KMPs(), 1e-3);
            Assert.AreEqual(10000, gs3.MPh(), 1e-3);
            Assert.AreEqual(100 / 36.0, gs3.MPs(), 1e-3);

            QGroundSpeed gs4 = new QGroundSpeed(100 / 36.0, QGroundSpeed.QuantityUnit.QT_MPS);
            Assert.AreEqual(10, gs4.KMPh(), 1e-3);
            Assert.AreEqual(10.0 / 3600.0, gs4.KMPs(), 1e-3);
            Assert.AreEqual(10000, gs4.MPh(), 1e-3);
            Assert.AreEqual(100 / 36.0, gs4.MPs(), 1e-3);
        }

```
### QDistance Quantity Example

```cpp
﻿using CsQuantity;

        public void QDistance_TEST()
        {
            QDistance d1 = new QDistance(25, QDistance.QuantityUnit.QT_CM);
            Assert.AreEqual(25, d1.Cm(), 1e-3);
            Assert.AreEqual(0.82021, d1.Foot(), 1e-3);
            Assert.AreEqual(9.84252, d1.Inch(), 1e-3);
            Assert.AreEqual(0.00025, d1.Km(), 1e-3);
            Assert.AreEqual(0.25, d1.M(), 1e-3);
            Assert.AreEqual(0.000155343, d1.Mi(), 1e-3);
            Assert.AreEqual(250, d1.Mm(), 1e-3);

            QDistance d2 = new QDistance(0.82021, QDistance.QuantityUnit.QT_Foot);
            Assert.AreEqual(25, d2.Cm(), 1e-3);
            Assert.AreEqual(0.82021, d2.Foot(), 1e-3);
            Assert.AreEqual(9.84252, d2.Inch(), 1e-3);
            Assert.AreEqual(0.00025, d2.Km(), 1e-3);
            Assert.AreEqual(0.25, d2.M(), 1e-3);
            Assert.AreEqual(0.000155343, d2.Mi(), 1e-3);
            Assert.AreEqual(250, d2.Mm(), 1e-3);

            QDistance d3 = new QDistance(9.84252, QDistance.QuantityUnit.QT_INCH);
            Assert.AreEqual(25, d3.Cm(), 1e-3);
            Assert.AreEqual(0.82021, d3.Foot(), 1e-3);
            Assert.AreEqual(9.84252, d3.Inch(), 1e-3);
            Assert.AreEqual(0.00025, d3.Km(), 1e-3);
            Assert.AreEqual(0.25, d3.M(), 1e-3);
            Assert.AreEqual(0.000155343, d3.Mi(), 1e-3);
            Assert.AreEqual(250, d3.Mm(), 1e-3);

            QDistance d4 = new QDistance(0.00025, QDistance.QuantityUnit.QT_KM);
            Assert.AreEqual(25, d4.Cm(), 1e-3);
            Assert.AreEqual(0.82021, d4.Foot(), 1e-3);
            Assert.AreEqual(9.84252, d4.Inch(), 1e-3);
            Assert.AreEqual(0.00025, d4.Km(), 1e-3);
            Assert.AreEqual(0.25, d4.M(), 1e-3);
            Assert.AreEqual(0.000155343, d4.Mi(), 1e-3);
            Assert.AreEqual(250, d4.Mm(), 1e-3);

            QDistance d5 = new QDistance(0.25, QDistance.QuantityUnit.QT_M);
            Assert.AreEqual(25, d5.Cm(), 1e-3);
            Assert.AreEqual(0.82021, d5.Foot(), 1e-3);
            Assert.AreEqual(9.84252, d5.Inch(), 1e-3);
            Assert.AreEqual(0.00025, d5.Km(), 1e-3);
            Assert.AreEqual(0.25, d5.M(), 1e-3);
            Assert.AreEqual(0.000155343, d5.Mi(), 1e-3);
            Assert.AreEqual(250, d5.Mm(), 1e-3);

            QDistance d6 = new QDistance(0.000155343, QDistance.QuantityUnit.QT_Mile);
            Assert.AreEqual(25, d6.Cm(), 1e-4);
            Assert.AreEqual(0.82021, d6.Foot(), 1e-4);
            Assert.AreEqual(9.84252, d6.Inch(), 1e-4);
            Assert.AreEqual(0.00025, d6.Km(), 1e-4);
            Assert.AreEqual(0.25, d6.M(), 1e-4);
            Assert.AreEqual(0.000155343, d6.Mi(), 1e-4);
            Assert.AreEqual(250, d6.Mm(), 1e-1);

            QDistance d = new QDistance(250, QDistance.QuantityUnit.QT_MM);
            Assert.AreEqual(25, d.Cm(), 1e-3);
            Assert.AreEqual(0.82021, d.Foot(), 1e-3);
            Assert.AreEqual(9.84252, d.Inch(), 1e-3);
            Assert.AreEqual(0.00025, d.Km(), 1e-3);
            Assert.AreEqual(0.25, d.M(), 1e-3);
            Assert.AreEqual(0.000155343, d.Mi(), 1e-3);
            Assert.AreEqual(250, d.Mm(), 1e-3);
        }
```
## License
This project is licensed under the MIT License - see the LICENSE file for details.
