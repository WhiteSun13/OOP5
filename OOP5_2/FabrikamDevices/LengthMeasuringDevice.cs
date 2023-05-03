using DeviceControl;
using System;

namespace FabrikamDevices
{
    internal class LengthMeasuringDevice : IControllableDevice
    {
        Random random;

        /// <summary>
        /// Creates a new instance of the LengthMeasuringDevice class.
        /// </summary>
        public LengthMeasuringDevice()
        {
            random = new Random();
        }

        /// <summary>
        /// Starts the LengthMeasuringDevice 
        /// </summary>
        public void StartDevice()
        {
            // Start the device.           
        }

        /// <summary>
        /// Stops the LengthMeasuringDevice
        /// </summary>
        public void StopDevice()
        {
            // Stop the device.
        }

        /// <summary>
        /// Gets the latest measurement from the LengthMeasuringDevice.
        /// </summary>
        /// <returns>The latest measurment taken by the device.</returns>
        public int GetLatestMeasure()
        {
            return random.Next(1000);
        }
    }
}